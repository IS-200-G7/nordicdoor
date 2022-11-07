CREATE DATABASE IF NOT EXISTS NordicDoor;
USE NordicDoor;

CREATE TABLE IF NOT EXISTS Bruker
(
    AnsattNr    INTEGER                 NOT NULL,
    Fornavn     VARCHAR(50)             NOT NULL,
    Etternavn   VARCHAR(50)             NOT NULL,
    Email       VARCHAR(254)            NOT NULL,
    PassordHash VARCHAR(200)            NOT NULL,
    Opprettet   DATETIME                DEFAULT CURRENT_TIMESTAMP,
    Rolle       VARCHAR(50),
    LederId     INTEGER                 DEFAULT NULL,
    KEY LederId (LederId),
    FOREIGN KEY (LederId) REFERENCES Bruker (AnsattNr),
    CONSTRAINT PK_Bruker PRIMARY KEY (AnsattNr)
);

DESC Bruker;

CREATE TABLE IF NOT EXISTS Team
(
    TeamId      INTEGER NOT NULL AUTO_INCREMENT,
    TeamLederId INTEGER NOT NULL,
    Navn        VARCHAR(50),
    AvdelingId  INTEGER,
    CONSTRAINT FK_Team_Bruker FOREIGN KEY (TeamLederId) REFERENCES Bruker (AnsattNr) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Team_Team FOREIGN KEY (AvdelingId) REFERENCES Team (TeamId) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT PK_Team PRIMARY KEY (TeamId)
);

DESC Team;

CREATE TABLE IF NOT EXISTS Forslag
(
    ForslagId     INTEGER                   NOT NULL AUTO_INCREMENT,
    ForfatterId   INTEGER                   NOT NULL,
    TeamId        INTEGER                   NOT NULL,
    Emne          VARCHAR(150)              NOT NULL,
    Beskrivelse   VARCHAR(2000)             NOT NULL,
    Bilde         MEDIUMBLOB,
    Status        VARCHAR(5)                DEFAULT "plan" NOT NULL,
    Opprettet     DATETIME                  DEFAULT CURRENT_TIMESTAMP,
    SistOppdatert DATETIME                  DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
    Frist         DATETIME,
    Kategori      VARCHAR(150),
    CONSTRAINT PK_Forslag PRIMARY KEY (ForslagId),
    CONSTRAINT FK_Forslag_Bruker FOREIGN KEY (ForfatterId) REFERENCES Bruker (AnsattNr) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Forlsag_Team FOREIGN KEY (TeamId) REFERENCES Team (TeamId) ON DELETE CASCADE ON UPDATE CASCADE
);

DESC Forslag;

CREATE TABLE IF NOT EXISTS TeamMedlemskap
(
    TeamId   INTEGER,
    AnsattNr INTEGER,
    CONSTRAINT PK_TeamMedlemskap PRIMARY KEY (TeamId, AnsattNr),
    CONSTRAINT FK_TeamMedlemskap_Team FOREIGN KEY (TeamId) REFERENCES Team (TeamId) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_TeamMedlemskap_Bruker FOREIGN KEY (AnsattNr) REFERENCES Bruker (AnsattNr) ON DELETE CASCADE ON UPDATE CASCADE
);

DESC TeamMedlemskap;


CREATE TABLE IF NOT EXISTS ForslagKobling
(
    AnsattNr  INTEGER NOT NULL,
    ForslagId INTEGER NOT NULL,
    CONSTRAINT PK_ForslagKobling PRIMARY KEY (AnsattNr, ForslagId),
    CONSTRAINT FK_ForslagKobling_Bruker FOREIGN KEY (AnsattNr) REFERENCES Bruker (AnsattNr) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_ForslagKobling_Forslag FOREIGN KEY (ForslagId) REFERENCES Forslag (ForslagId) ON DELETE CASCADE ON UPDATE CASCADE
);

DESC ForslagKobling;

SHOW TABLES;
