-- Bruker

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (1, 'Tobias', 'Hansen', 'th@nordic.door',
        'OTOiYdFITlCQGxI+/MGSUO3MGmK46v8LV45DgHFVHNg=:T4sen2e7YnMALZpNRTz5dQJfcg/RZBhnpxVKR2donyg=', 'teamleder');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (2, 'Siddharth', 'Dushantha', 'sd@nordic.door',
        '02BNAhz1nQOV6Rrdoyalqyug9xh5mJlWmUxgXerpO74=:2k5s/T2rgp0e8vB75+a9fhtUbQFWeWIanwgP/mEqy34=', 'ansatt', 2);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (3, 'Torkel', 'Ivarsøy', 'ti@nordic.door',
        'rcxg5TQUaKneWcQjWwhgZylnkMy46ttyZ9tCEbzKj2w=:tLc7dr65HJ4BeHgQmGTXmnDqsMseTMOMPu/0Sb1Bxy0=', 'teamleder');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (4, 'Victor', 'Rolf', 'vr@nordic.door',
        'cptkiQca0OoHQpIwTOkKs74ybtm6iuYCNw6439BZFgU=:CFdyXnCgT9XnYYAhTUBTKZ/jyfjMg8XuIJIxyO4Gyhc=', 'ansatt', 3);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (5, 'Magnus', 'Menyo', 'mn@nordic.door',
        'njY0hbuir7OBNCcWMDS1th2n3iniWeMEpotApDXDoXo=:D65mEE3hNhijmxLPSrNQcQMhmnV1Auid0hmaS31TqFM=', 'teamleder');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (6, 'Eirik', 'Bakkestad', 'eb@nordic.door',
        '2l0P/sn5eTgi8i5tJ5fOOXCzJEaU+wVtO+MODE3QlnQ=:H2g9Zs3JYAftr+3vVjV+edFrPO0kpV5OHgwuFToq71A=', 'ansatt', 5);


-- Team
INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn)
VALUES (1, 1, 'Produksjon');

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (2, 1, 'fase1', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (3, 3, 'fase2', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (4, 5, 'fase3', 1);

-- Forslag
INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (1, 2, 'Fresing av hull til lås', 'Kan dere øke diameteren på hullene med 3mm?', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (2, 1, 'Dørene må pakkes bedre', 'Dører ankommer ofte med hakk i kantene', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (3, 3, 'test', 'testing testing', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (3, 2, 'Test forslag', 'testing testing', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (5, 2, 'Test forslag', 'testing testing', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (4, 1, 'Test forslag', 'testing testing', null, "do");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (6, 1, 'Test forslag', 'testing testing', null, "act");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (4, 3, 'Test forslag', 'testing testing', null, "do");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (1, 2, 'Test forslag', 'testing testing', null, "do");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (5, 2, 'Test forslag', 'testing testing', null, "act");

-- TeamMedlemskap

INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (2, 1);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (2, 2);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (3, 3);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (3, 4);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (4, 5);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (4, 6);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 1);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 2);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 3);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 4);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 5);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 6);


-- ForslagKobling

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (1, 1);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (2, 2);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 3);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 4);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (5, 5);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 6);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (6, 7);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 8);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (1, 9);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (5, 10);
