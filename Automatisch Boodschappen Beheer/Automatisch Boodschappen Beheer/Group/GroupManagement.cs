using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace Automatisch_Boodschappen_Beheer
{
    public class GroupManagement
    {
        public List<Group> Groups { get; set; }
        public GroupManagement()
        {
            this.Groups = this.RequestGroups();
        }

        private List<Group> RequestGroups()
        {
            return DatabaseManager.GetGroups();
        }

        [Obsolete]
        public List<Group> SelectGroups()
        {
            return null;
        }

        [Obsolete]
        public Group SelectGroup()
        {
            return null;
        }

        public bool CreateGroup(Group group, Account account)
        {
            Random random = new Random();
            group.ID = GenerateKey(8, random);
            try
            {
                DatabaseManager.CreateGroup(group, account);
                this.Groups = this.RequestGroups();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateGroup(Group Group, Account account)
        {

            if (DatabaseManager.ModifyGroup(Group, account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Group> OwnerGroups(Account account)
        {
            List<Group> tempGroups = new List<Group>();
            foreach(Group g in Groups)
            {
                if(g.Owner == account)
                {
                    tempGroups.Add(g);
                }
            }
            return tempGroups;
        }
        public bool RemoveGroup(Group Group)
        {
            if (DatabaseManager.RemoveGroup(Group))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GenerateKey(int length, Random random)
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public List<double> CalculateGroupStatistics(Group group, string type)
        {
            return null;
        }
    }
}