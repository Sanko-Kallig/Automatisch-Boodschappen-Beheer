Drop TABLE Wijzingen cascade constraints;
DROP TABLE GROEP cascade constraints;
DROP TABLE Boodschappenlijst cascade constraints;
DROP TABLE Product cascade constraints;
DROP table Gebruiker cascade constraints;
DROP TABLE Boodschappenlijst_Producten cascade constraints;
DROP TABLE Groep_Gebruikers cascade constraints;
DROP TABLE GROEP_EIGENAAR cascade constraints;

Create TABLE Gebruiker(
ID			NUMBER(10)			PRIMARY KEY,
Email		VARCHAR2(30)		NOT NULL UNIQUE,
Wachtwoord 	VARCHAR2(30) 	NOT NULL,
Naam		VARCHAR2(30)	NOT NULL,
status 		NUMBER(1)       DEFAULT 1     CHECK (status BETWEEN 0 AND 1),
rol       VARCHAR2(10)    DEFAULT 'User'  CHECK(rol IN ('Admin', 'User'))

);

CREATE TABLE GROEP(
ID			NUMBER(10)		PRIMARY KEY,
Naam		VARCHAR2(30)	NOT NULL UNIQUE,  
status  NUMBER(1)     DEFAULT 1       CHECK (status BETWEEN 0 AND 1)
);

CREATE TABLE PRODUCT(
ID				NUMBER(10)		PRIMARY KEY,
Naam			VARCHAR2(30)	NOT NULL,
PRIJS			Decimal(10,2) 	NOT NULL,
Imgurl			VARCHAR2(50)	NULL,
LaastGewijzigd	DATE		NULL
);

CREATE TABLE BOODSCHAPPENLIJST(
ID				NUMBER(10)		PRIMARY KEY,
GROEP_ID		NUMBER(10)		NOT NULL,
TotaalPrijs		Decimal(10,2)	NULL,
STARTDATUM    DATE        NOT NULL,
EINDDATUM     DATE        NULL
);

CREATE TABLE GROEP_GEBRUIKERS(
GROEP_ID      NUMBER(10)		NOT NULL,
GEBRUIKER_ID  NUMBER(10)		NOT NULL,
CONSTRAINT  pk_GroepGebruiker PRIMARY KEY(GROEP_ID, GEBRUIKER_ID)
);

CREATE TABLE BOODSCHAPPENLIJST_PRODUCTEN(
BOODSCHAPPENLIJST_ID	NUMBER(10)	NOT NULL,
PRODUCT_ID		NUMBER(10)		NOT NULL,
GEBRUIKER_ID		NUMBER(10)		NOT NULL,
CONSTRAINT	pk_BOODSCHAPPRODUCT PRIMARY KEY(BOODSCHAPPENLIJST_ID, Gebruiker_ID)
);

CREATE TABLE WIJZINGEN(
ID				NUMBER(10)		PRIMARY KEY,
PRODUCT_ID		NUMBER(10)		NOT NULL,
GEBRUIKER_ID		NUMBER(10)		NOT NULL,
WIJZING			VARCHAR2(500)	NULL,
DATUM			DATE			NULL
);

CREATE TABLE GROEP_EIGENAAR(
GROEP_ID        NUMBER(10) NOT NULL,
GEBRUIKER_ID    NUMBER(10)  NOT NULL,
constraint pk_GroepEigenaar PRIMARY KEY(GROEP_ID, GEBRUIKER_ID)
);

ALTER TABLE GROEP_GEBRUIKERS				ADD FOREIGN KEY (GROEP_ID) REFERENCES GROEP(ID);
ALTER TABLE GROEP_GEBRUIKERS				ADD FOREIGN KEY (GEBRUIKER_ID) REFERENCES GEBRUIKER(ID);
ALTER TABLE BOODSCHAPPENLIJST_PRODUCTEN ADD FOREIGN KEY (BOODSCHAPPENLIJST_ID) REFERENCES BOODSCHAPPENLIJST(ID);
ALTER TABLE BOODSCHAPPENLIJST_PRODUCTEN ADD FOREIGN KEY (PRODUCT_ID) REFERENCES PRODUCT(ID);
ALTER TABLE BOODSCHAPPENLIJST_PRODUCTEN ADD FOREIGN KEY (GEBRUIKER_ID) REFERENCES GEBRUIKER(ID);
ALTER TABLE BOODSCHAPPENLIJST 			ADD FOREIGN KEY (GROEP_ID) REFERENCES GROEP(ID);
ALTER TABLE WIJZINGEN					ADD FOREIGN KEY(PRODUCT_ID)	REFERENCES PRODUCT(ID);
ALTER TABLE WIJZINGEN 					ADD FOREIGN KEY (GEBRUIKER_ID) REFERENCES GEBRUIKER(ID);
ALTER TABLE GROEP_EIGENAAR          ADD FOREIGN KEY (GROEP_ID) REFERENCES GROEP(ID);
ALTER TABLE GROEP_EIGENAAR          ADD FOREIGN KEY (GEBRUIKER_ID)  REFERENCES GEBRUIKER(ID);


INSERT INTO GEBRUIKER(ID, EMAIL, WACHTWOORD, NAAM, STATUS)	VALUES	(1, 'admin@admin.nl', 'Testwachtwoord', 'Admin', 1);
INSERT INTO GEBRUIKER(ID, EMAIL, WACHTWOORD, NAAM, STATUS)	VALUES	(2, 'annie@test.nl', 'Wachtwoord1', 'Annie', 1);
INSERT INTO GEBRUIKER(ID, EMAIL, WACHTWOORD, NAAM, STATUS)	VALUES	(3, 'Derick@test.nl', 'Wachtwoord2', 'Rick', 1);

INSERT INTO GROEP(ID, NAAM) VALUES (1, 'testgroep');

INSERT INTO GROEP_EIGENAAR(GROEP_ID, GEBRUIKER_ID) VALUES (1, 2);

INSERT INTO GROEP_GEBRUIKERS(GEBRUIKER_ID, GROEP_ID) VALUES (2,1);
INSERT INTO GROEP_GEBRUIKERS(GEBRUIKER_ID, GROEP_ID) VALUES (3, 1);