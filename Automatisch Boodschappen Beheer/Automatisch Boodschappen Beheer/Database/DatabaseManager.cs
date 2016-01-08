namespace Automatisch_Boodschappen_Beheer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    using System.Configuration;

    public static class DatabaseManager
    {
        private static OracleConnection Connection
        {
            get
            {
                return new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString);
            }
        }
        /// <summary>
        /// Creates an OracleCommand for the given query using the static OracleConnection field, and sets the CommandType to CommandType.Text (used for plain text queries).
        /// Used prior to adding parameters and executing the query.
        /// </summary>
        /// <param name="sql">Query string to run</param>
        /// <returns>OracleCommand with the query and Connection information set</returns>
        private static OracleCommand CreateOracleCommand(OracleConnection connection, string sql)
        {
            OracleCommand command = new OracleCommand(sql, connection);
            command.CommandType = System.Data.CommandType.Text;
            return command;
        }

        /// <summary>
        /// Runs the query of an OracleCommand, and returns an unread OracleDataReader with the results of the query.
        /// </summary>
        /// <param name="command">OracleCommand containing the data for the query</param>
        /// <returns>OracleDataReader with the result of the query</returns>
        private static OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        command.Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Debug.WriteLine("Database Connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Runs the command in the given OracleCommand with ExecuteNonQuery; which is used for queries where no data is returned (in an OracleDataReader).
        /// Return value indicates if any rows are updated.
        /// </summary>
        /// <param name="command">OracleCommand containing the data for the query.</param>
        /// <returns>True when at least one row is updated.</returns>
        private static bool ExecuteNonQuery(OracleCommand command)
        {
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
            }

            return command.ExecuteNonQuery() != 0;
        }
        public static List<Group> GetGroups()
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, @"select g.id as GroepID, g.naam as GroepNaam, a.ID as GebruikerID, a.Email, a.naam as GebruikerNaam, a.status, a.ROL from groep g, gebruiker a, groep_eigenaar e  where e.groep_ID = g.ID AND e.gebruiker_ID = a.ID;");

                    OracleDataReader reader = ExecuteQuery(command);
                    List<Group> Groups = new List<Group>();
                    while (reader.Read())
                    {
                        try
                        {
                            string groupid = reader["GroepID"].ToString();
                            string groupname = reader["GroepNaam"].ToString();
                            string email = reader["Email"].ToString();
                            string accountname = reader["Gebruikernaam"].ToString();
                            AccountType role = (AccountType)Enum.Parse(typeof(AccountType), reader["rol"].ToString());
                            Account owner = new Account(email, accountname, role);
                            Groups.Add(new Group(groupid, groupname, owner));
                        }
                        catch (Exception exc)
                        {
                            Debug.WriteLine(exc.Message);
                            continue;
                        }
                    }
                    connection.Close();
                    foreach(Group group in Groups)
                    {
                        group.Users = GetGroupAccounts(group);
                    }
                    return Groups;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static List<Account> GetGroupAccounts(Group group)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "SELECT ID, EMAIL, NAAM, ROL FROM GEBRUIKER, GROEP_GEBRUIKERS WHERE ID = GROEP_GEBRUIKERS.GEBRUIKER_ID AND GROEP_GEBRUIKERS.GROEP_ID = :GroupID;");
                    command.Parameters.Add(":GroupID", group.ID);
                    OracleDataReader reader = ExecuteQuery(command);
                    List<Account> Accounts = new List<Account>();
                    while(reader.Read())
                    {
                        try
                        {
                            string email = reader["Email"].ToString();
                            string name = reader["Naam"].ToString();
                            AccountType role = (AccountType) Enum.Parse(typeof(AccountType), reader["rol"].ToString());
                            Accounts.Add(new Account(email, name, role));
                        }
                        catch(Exception exc)
                        {
                            Debug.WriteLine(exc.Message);
                            continue;
                        }
                    }
                    return Accounts;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool AddGroupUser(Group group, Account account)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "INSERT INTO GROEP_GEBRUIKERS(GEBRUIKER_ID, GROEP_ID) VALUES (:userID, :groupID);");
                    command.Parameters.Add(":userID", account.ID);
                    command.Parameters.Add(":groupID", group.ID);

                    return ExecuteNonQuery(command);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool RemoveGroupUser(Group group, Account account)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "DELETE FROM GROEP_GEBRUIKERS WHERE GEBRUIKER_ID = :userID AND GROEP_ID = :groupID;");
                    command.Parameters.Add(":userID", account.ID);
                    command.Parameters.Add(":groupID", group.ID);

                    return ExecuteNonQuery(command);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool RemoveGroup(Group group)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "UPDATE GROEP SET status = '0' WHERE ID = :groupID");

                    command.Parameters.Add(":groupID", group.ID);

                    return ExecuteNonQuery(command);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool CreateGroup(Group group, Account account)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "INSERT INTO GROUP(ID, NAAM, EIGENAAR) VALUES(SEQ_GROEPNEXTVAL, :name, :accountID);");
                    command.Parameters.Add(":name", group.Name);
                    command.Parameters.Add(":accountID", account.ID);

                    return ExecuteNonQuery(command);

                }
                catch
                {
                    throw new Exception("The group could not be added to the database.");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static List<Product> GetProducts()
        {
            {
                using (OracleConnection connection = Connection)
                {
                    try
                    {
                        OracleCommand command = CreateOracleCommand(connection, @"SELECT * FROM PRODUCT");

                        OracleDataReader reader = ExecuteQuery(command);
                        List<Product> Products = new List<Product>();
                        while (reader.Read())
                        {
                            try
                            {
                                int id = Convert.ToInt32(reader["ID"].ToString());
                                string name = reader["Naam"].ToString();
                                string imageURL = reader["Imgurl"].ToString();
                                DateTime lastModified = Convert.ToDateTime(reader["laastgewijzigd"].ToString());
                                double price = Convert.ToDouble(reader["Prijs"].ToString());
                                AccountType rol = (AccountType)Enum.Parse(typeof(AccountType), reader["rol"].ToString());
                                Products.Add(new Product(id, name, price, imageURL, lastModified, null));
                            }
                            catch (Exception exc)
                            {
                                Debug.WriteLine(exc.Message);
                                continue;
                            }
                        }
                        connection.Close();
                        foreach(Product p in Products)
                        {
                            p.ModifiedBy = ProductModifiedBy(p);
                        }
                        return Products;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static Account ProductModifiedBy(Product product)
        {
            {
                using (OracleConnection connection = Connection)
                {
                    try
                    {
                        OracleCommand command = CreateOracleCommand(connection, "SELECT ID, EMAIL, WACHTWOORD, NAAM, ROL FROM GEBRUIKER, GROEP_GEBRUIKERS WHERE ID = WIJZIGINGEN.GEBRUIKER_ID AND WIJZIGINGEN.PRODUCT_ID = :productID;");
                        command.Parameters.Add(":ProductD", product.ID);
                        OracleDataReader reader = ExecuteQuery(command);

                        if (!reader.HasRows)
                        {
                            return null;
                        }

                        reader.Read();

                        return ParseAccount(reader);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static Product CreateProduct(Product product, Account account)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "UPDATE PRODUCT SET naam = :name, prijs = :price, imgurl = :imageURL, laastgewijzigd = :lastModified");
                    command.Parameters.Add(":name", product.Name);
                    command.Parameters.Add(":price", product.Price);
                    command.Parameters.Add("imageURL", product.ImageURL);
                    command.Parameters.Add(":lastModified", product.LastModified);

                    bool isAdded = ExecuteNonQuery(command);
                    if (!isAdded)
                    {
                        throw new Exception("The product could not be inserted into the database.");
                    }

                    OracleCommand modCommand = CreateOracleCommand(connection, "INSERT INTO WIJZIGINGEN(ID, PRODUCT_ID, GEBRUIKER_ID, WIJZING, DATUM) VALUES(SEQ_WIJZIGINGID.NEXTVAL, :productID, :accountID, :description, :date");
                    modCommand.Parameters.Add(":productID", product.ID);
                    modCommand.Parameters.Add(":accountID", account.ID);
                    modCommand.Parameters.Add(":change", null);
                    modCommand.Parameters.Add(":date", product.LastModified);

                    if (ExecuteNonQuery(modCommand))
                    {
                        return product;
                    }
                    else
                    {
                        return null;
                        throw new Exception("Product last modified by User could not be added to the database");
                    }
                }
                catch
                {
                    return null;
                    throw new Exception("The product could not be added to the database.");
                }
               finally
                {
                    connection.Close();
                }
            }
        }
        
        public static bool ModifyProduct(Product product, Account account)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "UPDATE PRODUCT SET naam = :name, prijs = :price, imgurl = :imageURL, laastgewijzigd = :lastModified");
                    command.Parameters.Add(":name", product.Name);
                    command.Parameters.Add(":price", product.Price);
                    command.Parameters.Add("imageURL", product.ImageURL);
                    command.Parameters.Add(":lastModified", product.LastModified);

                    bool isAdded = ExecuteNonQuery(command);
                    if (!isAdded)
                    {
                        throw new Exception("The product could not be updated in the database.");
                    }

                    OracleCommand modCommand = CreateOracleCommand(connection, "INSERT INTO WIJZIGINGEN(ID, PRODUCT_ID, GEBRUIKER_ID, WIJZING, DATUM) VALUES(SEQ_WIJZIGINGID.NEXTVAL, :productID, :accountID, :description, :date");
                    modCommand.Parameters.Add(":productID", product.ID);
                    modCommand.Parameters.Add(":accountID", account.ID);
                    modCommand.Parameters.Add(":change", null);
                    modCommand.Parameters.Add(":date", product.LastModified);

                    return ExecuteNonQuery(modCommand);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool DeleteProduct(Product product)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "");

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static int GetAccountID(string email, bool closeConnection = true)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, @"SELECT ""ID"" FROM GEBRUIKER WHERE ""Email"" = :Email");

                    command.Parameters.Add(":Email", email);

                    OracleDataReader reader = ExecuteQuery(command);

                    if (!reader.HasRows)
                    {
                        throw new Exception(string.Format("No account could be found in the database with this email ({0}).", email));
                    }

                    reader.Read();

                    return Convert.ToInt32(reader["ID"].ToString());
                }
                finally
                {
                    if (closeConnection)
                    {
                        connection.Close();
                    }
                }
            }
        }
        public static List<Account> GetAccounts(bool closeConnection = true)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, @"SELECT * FROM GEBRUIKER");

                    OracleDataReader reader = ExecuteQuery(command);
                    List<Account> Accounts = new List<Account>();
                    while(reader.Read())
                    {
                        try
                        {
                            string email = reader["Email"].ToString();
                            string name = reader["Naam"].ToString();
                            AccountType rol = (AccountType) Enum.Parse(typeof(AccountType), reader["rol"].ToString());
                            Accounts.Add(new Account(email, name, rol));
                        }
                        catch(Exception exc)
                        {
                            Debug.WriteLine(exc.Message);
                            continue;
                        }
                    }
                    return Accounts;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static Account CreateAccount(Account account, string password)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "INSERT INTO GEBRUIKER(ID, EMAIL, WACHTWOORD, NAAM, ROL) VALUES (SEQ_GEBRUIKERID.NEXTVAL, :email, :password, :name, :rol");

                    
                    command.Parameters.Add(":email", account.Email);
                    command.Parameters.Add(":password", password);
                    command.Parameters.Add(":name", account.Name);
                    command.Parameters.Add(":Role", account.Role.ToString());

                    bool isAdded = ExecuteNonQuery(command);

                if (!isAdded)
                {
                    throw new Exception("The account could not be added to the database.");
                }

                // Fetch database ID of account
                OracleCommand commandID = CreateOracleCommand(connection, "SELECT SEQ_GEBRUIKERID.CURRVAL AS ID FROM DUAL");

                OracleDataReader reader = ExecuteQuery(commandID);

                reader.Read();

                int id = Convert.ToInt32(reader["ID"].ToString());

                account.ID = id;


                return account;
            }
            finally
            {
                    connection.Close();
                }
            }
        }

        public static bool ModifyAccount(Account account)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "UPDATE GEBRUIKER SET email = :email, naam = :name, rol = :role WHERE ID = :AccountID");
                    command.Parameters.Add(":email", account.Email);
                    command.Parameters.Add(":naam", account.Name);
                    command.Parameters.Add(":role", account.Role.ToString());
                    command.Parameters.Add(":AccountID", account.ID);

                    return ExecuteNonQuery(command);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool DeleteAccount(Account account)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "UPDATE GEBRUIKER SET status = '0' WHERE ID = :AccountID");

                    command.Parameters.Add(":AccountID", account.ID);

                    return ExecuteNonQuery(command);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static List<Product> GetGroceryProducts(Grocerylist groceryList)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "SELECT * FROM PRODUCT WHERE ID = BOODSCHAPPENLIJST_PRODUCTEN.product_ID AND BOODSCHAPPENLIJST_PRODUCTEN.boodschappenlijst_ID = :groceryListID");
                    command.Parameters.Add(":groceryListID", groceryList.ID);
                    OracleDataReader reader = ExecuteQuery(command);
                    List<Product> products = new List<Product>();

                    while(reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"].ToString());
                        string name = reader["naam"].ToString();
                        string imageURL = reader["imgurl"].ToString();
                        double price = Convert.ToDouble(reader["prijs"].ToString());
                        DateTime lastModified = Convert.ToDateTime(reader["laastgewijzigd"].ToString());

                        products.Add(new Product(id, name, price, imageURL, lastModified, null));
                    }
                    return products;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static Product AddProductToGroceryList(Product product, Account account, GroceryList groceries)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "Insert INTO BOODSCHAPPENLIJST_PRODUCTEN(BOODSCHAPPENLIJST_ID, PRODUCT_ID, GEBRUIKER_ID) VALUES(:groceriesID, :productID, :accountID");
                    command.Parameters.Add(":groceriesID", groceries.ID);
                    command.Parameters.Add(":productID", product.ID);
                    command.Parameters.Add(":accountID", account.ID);

                    command.ExecuteNonQuery();
                    return product;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static Account AuthenticateAccount(string email, string password)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "SELECT ID, Email, naam, rol FROM ACCOUNT WHERE email = :Email AND status = '1' AND wachtwoord = :Password");
                    command.Parameters.Add(":Email", email);
                    command.Parameters.Add(":Password", password);

                    OracleDataReader reader = ExecuteQuery(command);

                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    reader.Read();

                    return ParseAccount(reader);
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }

        public static List<Product> GetCostsAccounts(Account account)
        {
            using(OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand command = CreateOracleCommand(connection, "");
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }


        private static Account ParseAccount(OracleDataReader reader)
        {
            int accountID = Convert.ToInt32(reader["ID"].ToString());
            string email = reader["email"].ToString();
            string name = reader["voornaam"].ToString();
            string role = reader["rol"].ToString();

            AccountType accountType;
            if (!Enum.TryParse(role, out accountType))
            {
                throw new ArgumentException("Account role could not be parsed as an AccountType");
            }

            return new Account(email, name, accountType);
        }

        internal static int GetAccountID(string Email)
        {
            throw new NotImplementedException();
        }
    
internal static bool ModifyGroup(Group Group,Account account)
{
 	throw new NotImplementedException();
}}
}