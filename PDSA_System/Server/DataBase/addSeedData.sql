-- Bruker

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (1, 'Tobias', 'Hansen', 'th@nordic.door',
        'tkCPEYD34Knu8Zzu2GYevDVSYIWtGvctF4xiNkxyBog=:nLlecKCqvoBfB/tfkHzMW4JSrTeIyODBGnxXcPI2JRg=', 'teamleder');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (2, 'Siddharth', 'Dushantha', 'sd@nordic.door',
        'RBUHHxBBHIklXSdij0CCSjuVkyn3LxRJqy3wF7KEPXU=:YXOQmENOyGzLItu94EGe0JZudB6BI6NE5qwPhFH1RiA=', 'ansatt', 2);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (3, 'Torkel', 'Ivarsøy', 'ti@nordic.door',
        't3U/gyQrZv1QWLwSAsyidRn1Z7wSZVOAAGRQ9FmukrM=:YwUVhu+4nJdF69avTVl02NAt4jLtvb9Uz/AqEeQBTt4=', 'teamleder');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (4, 'Victor', 'Rolf', 'vr@nordic.door',
        'MTpLT0uZAwxtRgaAackmK7+ALJM/QnI6pMf/egirRG8=:1W6dJEL9skOYSgA7w8O6Y7xShJamIu8VDEoGo2Sd1xU=', 'ansatt', 3);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (5, 'Magnus', 'Nymo', 'mn@nordic.door',
        'umc8fWUggqYn9KwHMgYaoznEzwyvvrziBcKxSmg6Zy8=:A000000000000000000000000000000000000000000=', 'teamleder');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (6, 'Eirik', 'Bakkestad', 'eb@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 5);

SELECT * FROM Bruker;


-- Team

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn)
VALUES (1, 1, 'Produksjon');

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (2, 1, 'fase1', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (3, 3, 'fase2', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (4, 5, 'fase3', 1);

SELECT * FROM Team;


-- Forslag

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (1, 2, 'Fresing av hull til lås', 'Kan dere øke diameteren på hullene med 3mm?', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (2, 1, 'Dørene må pakkes bedre', 'Dører ankommer ofte med hakk i kantene', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (3, 3, 'test', 'testing testing', null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (3, 2, "Test forslag", "testing testing", null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (5, 2, "Test forslag", "testing testing", null);

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (4, 1, "Test forslag", "testing testing", null, "do");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (6, 1, "Test forslag", "testing testing", null, "act");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (4, 3, "Test forslag", "testing testing", null, "do");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (1, 2, "Test forslag", "testing testing", null, "do");

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (5, 2, "Test forslag", "testing testing", null, "act");


-- Forslag hvor jeg eksplisitt setter inn dato for opprettet for å teste statistikkController

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (4, 3, "måned", "måned testing", null, "act", ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (4, 3, "måned", "måned testing", null, "act", ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (4, 3, "måned", "måned testing", null, "act", ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

INSERT INTO NordicDoor.Forslag (ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (4, 3, "måned", "måned testing", null, "act", ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

SELECT * FROM Forslag;

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

SELECT * FROM TeamMedlemskap;


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

-- Forslag som er 20 dager gamle.

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 11);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 12);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 13);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 14);

SELECT * FROM ForslagKobling;
