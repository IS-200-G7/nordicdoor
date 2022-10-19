-- Bruker
INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Opprettet, Rolle, LederId) VALUES (1, 'Tobias', 'Hansen', 'tob@mail.com', 'OTOiYdFITlCQGxI+/MGSUO3MGmK46v8LV45DgHFVHNg=:T4sen2e7YnMALZpNRTz5dQJfcg/RZBhnpxVKR2donyg=', '2022-10-10 10:19:40', 'teamleder', 1);
INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Opprettet, Rolle, LederId) VALUES (2, 'Siddharth', 'Dushantha', 'satan@sidd.no', '02BNAhz1nQOV6Rrdoyalqyug9xh5mJlWmUxgXerpO74=:2k5s/T2rgp0e8vB75+a9fhtUbQFWeWIanwgP/mEqy34=', '2022-10-01 23:25:21', 'ansatt', 2);

-- Team
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingsId) VALUES (1, 'Produksjon', 3);
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingsId) VALUES (2, 'Salg', 2);

-- Forslag
INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (1, 1, 2, '"Fresing av hull til lås"', '"Kan dere øke diameteren på hullene med 3mm?"', null, 1, '2022-10-08 23:35:27', '2022-10-10 23:35:32', null, null);
INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (2, 2, 1, '"Dørene må pakkes bedre"', '"Dører ankommer ofte med hakk i kantene"', null, 1, '2022-10-11 00:06:35', null, null, null);
INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (3, 1, 2, '"Test forslag"', '"testing testing"', null, 1, '2022-10-09 00:32:44', null, null, null);

-- TeamMedlemskap
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr) VALUES (1, 2);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr) VALUES (2, 1);

-- Rolle
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (1, 'Ansatt');
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (2, 'Teamleder');
=======
-- Bruker
INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Opprettet, Rolle, LederId) VALUES (1, 'Tobias', 'Hansen', 'tob@mail.com', 'OTOiYdFITlCQGxI+/MGSUO3MGmK46v8LV45DgHFVHNg=:T4sen2e7YnMALZpNRTz5dQJfcg/RZBhnpxVKR2donyg=', '2022-10-10 10:19:40', 'teamleder', 1);
INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Opprettet, Rolle, LederId) VALUES (2, 'Siddharth', 'Dushantha', 'satan@sidd.no', '02BNAhz1nQOV6Rrdoyalqyug9xh5mJlWmUxgXerpO74=:2k5s/T2rgp0e8vB75+a9fhtUbQFWeWIanwgP/mEqy34=', '2022-10-01 23:25:21', 'ansatt', 2);

-- Team
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingId) VALUES (1, 'Produksjon', 3);
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingId) VALUES (2, 'Salg', 2);

-- Forslag
INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (1, 1, 2, '"Fresing av hull til lås"', '"Kan dere øke diameteren på hullene med 3mm?"', null, 1, '2022-10-08 23:35:27', '2022-10-10 23:35:32', null, null);
INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (2, 2, 1, '"Dørene må pakkes bedre"', '"Dører ankommer ofte med hakk i kantene"', null, 1, '2022-10-11 00:06:35', null, null, null);
INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (3, 1, 2, '"Test forslag"', '"testing testing"', null, 1, '2022-10-09 00:32:44', null, null, null);

-- TeamMedlemskap
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr) VALUES (1, 2);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr) VALUES (2, 1);

-- Rolle
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (1, 'Ansatt');
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (2, 'Teamleder');
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (3, 'Administrator');
