CREATE DATABASE IF NOT EXISTS nordicdoor;
USE nordicdoor;


CREATE TABLE IF NOT EXISTS Bruker(
  BrukerId INTEGER NOT NULL,
  ForNavn VARCHAR(50) NOT NULL,
  EtterNavn VARCHAR(50) NOT NULL,
  Email VARCHAR(150) NOT NULL,
  PassordHash VARCHAR(200) NOT NULL,
  Opprettet DATETIME NOT NULL,
  CONSTRAINT PK_Bruker PRIMARY KEY(BrukerId)
);
INSERT INTO NordicDoor.Bruker (BrukerId, ForNavn, EtterNavn, Email, PassordHash, Opprettet) VALUES (1, 'Tobias', 'Hansen', 'tob@mail.com', 'OTOiYdFITlCQGxI+/MGSUO3MGmK46v8LV45DgHFVHNg=:T4sen2e7YnMALZpNRTz5dQJfcg/RZBhnpxVKR2donyg=', '2022-10-10 10:19:40');
INSERT INTO NordicDoor.Bruker (BrukerId, ForNavn, EtterNavn, Email, PassordHash, Opprettet) VALUES (2, 'Siddharth', 'Dushantha', 'satan@sidd.no', '02BNAhz1nQOV6Rrdoyalqyug9xh5mJlWmUxgXerpO74=:2k5s/T2rgp0e8vB75+a9fhtUbQFWeWIanwgP/mEqy34=', '2022-10-01 23:25:21');


CREATE TABLE IF NOT EXISTS Team(
  TeamId INTEGER NOT NULL AUTO_INCREMENT,
  Navn VARCHAR(50),
  AvdelingsId INTEGER,
  CONSTRAINT PK_Team PRIMARY KEY (TeamId)
);
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingsId) VALUES (1, 'Produksjon', 3);
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingsId) VALUES (2, 'Salg', 2);


CREATE TABLE IF NOT EXISTS Forslag(
  ForslagsId INTEGER NOT NULL AUTO_INCREMENT,
  ForfatterId INTEGER NOT NULL,
  TeamId INTEGER NOT NULL,
  Emne VARCHAR(150) NOT NULL,
  Beskrivelse VARCHAR(2000) NOT NULL,
  Bilde MEDIUMBLOB,
  Status INTEGER DEFAULT 1 NOT NULL,
  Opprettet DATETIME,
  SistOppdatert DATETIME,
  Frist DATETIME,
  Kategori VARCHAR(150),
  CONSTRAINT PK_Forslag PRIMARY KEY (ForslagsId),
  CONSTRAINT FK_Forslag_Bruker FOREIGN KEY (ForfatterId) REFERENCES Bruker(BrukerId) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_Forslag_Team FOREIGN KEY (TeamId) REFERENCES Team(TeamId) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO NordicDoor.Forslag (ForslagsId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (1, 1, 2, '"Fresing av hull til lås"', '"Kan dere øke diameteren på hullene med 3mm?"', null, 1, '2022-10-08 23:35:27', '2022-10-10 23:35:32', null, null);
INSERT INTO NordicDoor.Forslag (ForslagsId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (2, 2, 1, '"Dørene må pakkes bedre"', '"Dører ankommer ofte med hakk i kantene"', null, 1, '2022-10-11 00:06:35', null, null, null);
INSERT INTO NordicDoor.Forslag (ForslagsId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (3, 1, 2, '"Test forslag"', '"testing testing"', null, 1, '2022-10-09 00:32:44', null, null, null);


CREATE TABLE IF NOT EXISTS TeamMedlemskap(
  Id INTEGER NOT NULL AUTO_INCREMENT,
  TeamId INTEGER,
  BrukerId INTEGER,
  CONSTRAINT PK_TeamMedlemskap PRIMARY KEY (Id),
  CONSTRAINT FK_TeamMedlemskap_Team FOREIGN KEY (TeamId) REFERENCES Team(TeamId) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_TeamMedlemskap_Bruker FOREIGN KEY (BrukerId) REFERENCES Bruker(BrukerId)
);
INSERT INTO NordicDoor.TeamMedlemskap (Id, TeamId, BrukerId) VALUES (1, 1, 2);
INSERT INTO NordicDoor.TeamMedlemskap (Id, TeamId, BrukerId) VALUES (2, 2, 1);


CREATE TABLE IF NOT EXISTS Rolle(
  RolleId INTEGER NOT NULL,
  RolleNavn VARCHAR(150),
  CONSTRAINT PK_Rolle PRIMARY KEY (RolleId)
);
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (1, 'Ansatt');
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (2, 'Teamleder');
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (3, 'Administrator');


CREATE TABLE IF NOT EXISTS BrukerRolle(
  BrukerId INTEGER NOT NULL,
  RolleId INTEGER NOT NULL,
  CONSTRAINT PK_BrukerRolle PRIMARY KEY (BrukerId, RolleId),
  CONSTRAINT FK_BrukerRolle_Rolle FOREIGN KEY (RolleId) REFERENCES Rolle(RolleId) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_BrukerRolle_Bruker FOREIGN KEY (BrukerId) REFERENCES Bruker(BrukerId) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO NordicDoor.BrukerRolle (BrukerId, RolleId) VALUES (1, 1);
INSERT INTO NordicDoor.BrukerRolle (BrukerId, RolleId) VALUES (2, 2);


CREATE TABLE IF NOT EXISTS ForslagKobling(
  BrukerId INTEGER NOT NULL,
  ForslagsId INTEGER NOT NULL,
  CONSTRAINT PK_ForslagKobling PRIMARY KEY (BrukerId, ForslagsId),
  CONSTRAINT FK_ForslagKobling_Bruker FOREIGN KEY (BrukerId) REFERENCES Bruker(BrukerId) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_ForslagKobling_Forslag FOREIGN KEY (ForslagsId) REFERENCES Forslag(ForslagsId) ON DELETE CASCADE ON UPDATE CASCADE
);
