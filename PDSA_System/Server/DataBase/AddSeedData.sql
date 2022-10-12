-- Bruker
INSERT INTO NordicDoor.Bruker (BrukerId, ForNavn, EtterNavn, Email, PassordHash, Opprettet) VALUES (1, 'Tobias', 'Hansen', 'tob@mail.com', 'hashhash', '2022-10-10 10:19:40');
INSERT INTO NordicDoor.Bruker (BrukerId, ForNavn, EtterNavn, Email, PassordHash, Opprettet) VALUES (2, 'Siddharth', 'Dushantha', 'satan@sidd.no', 'passordhash', '2022-10-01 23:25:21');

-- BrukerRolle
INSERT INTO NordicDoor.BrukerRolle (BrukerId, RolleId) VALUES (1, 1);
INSERT INTO NordicDoor.BrukerRolle (BrukerId, RolleId) VALUES (2, 2);

-- Forslag
INSERT INTO NordicDoor.Forslag (ForslagsId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (1, 1, 2, '"Fresing av hull til lås"', '"Kan dere øke diameteren på hullene med 3mm?"', null, plan, '2022-10-08 23:35:27', '2022-10-10 23:35:32', null, null);
INSERT INTO NordicDoor.Forslag (ForslagsId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (2, 2, 1, '"Dørene må pakkes bedre"', '"Dører ankommer ofte med hakk i kantene"', null, plan, '2022-10-11 00:06:35', null, null, null);
INSERT INTO NordicDoor.Forslag (ForslagsId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet, SistOppdatert, Frist, Kategori) VALUES (3, 1, 2, '"Test forslag"', '"testing testing"', null, plan, '2022-10-09 00:32:44', null, null, null);

-- Team
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingsId) VALUES (1, 'Produksjon', 3);
INSERT INTO NordicDoor.Team (TeamId, Navn, AvdelingsId) VALUES (2, 'Salg', 2);

-- TeamMedlemskap
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, BrukerId) VALUES (1, 2);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, BrukerId) VALUES (2, 1);

-- Rolle
// Rolle entitet skal bli fjernet. 
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (2, 'Teamleder');
INSERT INTO NordicDoor.Rolle (RolleId, RolleNavn) VALUES (3, 'Administrator');
