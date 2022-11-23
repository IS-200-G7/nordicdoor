-- Bruker

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (1, 'Tobias', 'Hansen', 'th@nordic.door',
        'tkCPEYD34Knu8Zzu2GYevDVSYIWtGvctF4xiNkxyBog=:nLlecKCqvoBfB/tfkHzMW4JSrTeIyODBGnxXcPI2JRg=', 'admin');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (2, 'Siddharth', 'Dushantha', 'sd@nordic.door',
        'RBUHHxBBHIklXSdij0CCSjuVkyn3LxRJqy3wF7KEPXU=:YXOQmENOyGzLItu94EGe0JZudB6BI6NE5qwPhFH1RiA=', 'ansatt', 1);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (3, 'Torkel', 'Ivarsøy', 'ti@nordic.door',
        't3U/gyQrZv1QWLwSAsyidRn1Z7wSZVOAAGRQ9FmukrM=:YwUVhu+4nJdF69avTVl02NAt4jLtvb9Uz/AqEeQBTt4=', 'teamleder',1);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (4, 'Victor', 'Rolf', 'vr@nordic.door',
        'MTpLT0uZAwxtRgaAackmK7+ALJM/QnI6pMf/egirRG8=:1W6dJEL9skOYSgA7w8O6Y7xShJamIu8VDEoGo2Sd1xU=', 'ansatt', 3);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (5, 'Magnus', 'Nymo', 'mn@nordic.door',
        'umc8fWUggqYn9KwHMgYaoznEzwyvvrziBcKxSmg6Zy8=:A000000000000000000000000000000000000000000=', 'teamleder', 1);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (6, 'Eirik', 'Bakkestad', 'eb@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 5);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (7, 'Terje', 'Gjøsæter', 'tg@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'teamleder', 1);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (8, 'Bonde', 'Produksjon-fase4', 'bs8@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 5);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle)
VALUES (9, 'Salg-sjef', 'salg', 'SS-9@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'admin');

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (10, 'Bonde', 'salg', 'bs10@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 9);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (11, 'teamleder', 'salg-fase1', 'SF01-11@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'teamleder', 9);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (12, 'Bonde', 'Sjakk', 'bs12@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 11);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (13, 'teamleder', 'salg-fase2', 'SF02-13@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'teamleder', 9);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (14, 'Bonde', 'Sjakk', 'bs14@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 13);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (15, 'teamleder', 'salg-fase3', 'SF03-15@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'teamleder', 9);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (16, 'Bonde', 'Sjakk', 'bs16@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 15);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (17, 'teamleder', 'Salg-fase4', 'SF04-17@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'teamleder', 9);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (18, 'Bonde', 'Sjakk', 'bs18@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 17);
--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (19, 'teamleder', 'salg-fase5', 'SF05-19@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'teamleder', 9);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (20, 'Bonde', 'Sjakk', 'bs20@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 19);

--

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (21, 'Bonde', 'Sjakk', 'bs21@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 19);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (22, 'Bonde', 'Sjakk', 'bs22@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 17);

INSERT INTO NordicDoor.Bruker (AnsattNr, Fornavn, Etternavn, Email, PassordHash, Rolle, LederId)
VALUES (23, 'Bonde', 'Sjakk', 'bs23@nordic.door',
        '+fYelAfl/XEsrNFKaz40NTinKJ05FiygAUuNXjLscV4=:XrK/qvypFfQKnaY+3OUWdds87RkZOF5UmOto9V6y5VY=', 'ansatt', 15);



SELECT * FROM NordicDoor.Bruker;


-- Team
-- Avdelig produksjon
INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn)
VALUES (1, 1, 'Produksjon');

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (2, 1, 'produksjon-fase1', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (3, 3, 'produksjon-fase2', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (4, 5, 'produksjon-fase3', 1);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (5, 7, 'produksjon-fase4', 1);

-- Avdeling salg

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn)
VALUES (6, 9, 'Salg');

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (7, 11, 'salg-fase1', 6);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (8, 13, 'salg-fase2', 6);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (9, 15, 'salg-fase3', 6);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (10, 17, 'salg-fase4', 6);

INSERT INTO NordicDoor.Team (TeamId, TeamLederId, Navn, AvdelingId)
VALUES (11, 19, 'salg-fase5', 6);

SELECT * FROM NordicDoor.Team;


-- Forslag

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (1, 1, 2, 'Fresing av hull til lås', 'Kan dere øke diameteren på hullene med 3mm?', null);

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (2, 2, 2, 'Dørene må pakkes bedre', 'Dører ankommer ofte med hakk i kantene', null);

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (3, 3, 3, 'Pussing', 'pussemaskiner trenger service', null);

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (4, 3, 3, 'Posisjon av Lås', 'Kan vi sette posisjonen for lås 5 mm opp?', null);

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde)
VALUES (5, 5, 4, 'Effektivitet', 'Kan vi rullere sekvensielt gjennom fasene i produksjonen?', null);

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (6, 4, 3, 'Pause', 'Fordi arbeidet er fysisk krevende forslår jeg at vi en fordeling på 50:10 - (jobb:pause)', null, 'do');

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (7, 6, 4, 'Vask', 'Garderobe menn - behov for retningslijer/normer', null, 'act');

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (8, 4, 3, 'Miljø', 'Er veldig hektisk om dagen og det merkes på samtlige ansatte. Kan noe gøyt sosialt være motiverde?', null, 'do');

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (9, 1, 2, 'Flaskehals', 'Fase 3 må ofte vente på at fase 2 blir ferdig. Dersom vi endrer rekkefølgen mellom fase 3 og fase 2, kan det potensielt øke effektiviteten.', null, 'do');

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status)
VALUES (10, 5, 4, 'HMS', 'Det er mye støv fra pussing av både treverk og stål. Dermed kan det være hensiktmessig å bruke maske innpå områdene som er mest utsatt.', null, 'act');


-- Forslag som er 20 dager gamle. For Testing.

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (11, 4, 3, 'Test', '20 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (12, 4, 3, 'Test', '20 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (13, 4, 3, 'Test', '20 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (14, 4, 3, 'Test', '20 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -20 DAY));

-- Forslag som er 10 dager gamle . For Testing.

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (15, 12, 7, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (16, 12, 7, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (17, 12, 7, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (18, 12, 7, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (19, 13, 8, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (20, 13, 8, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (21, 14, 8, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

INSERT INTO NordicDoor.Forslag (ForslagId, ForfatterId, TeamId, Emne, Beskrivelse, Bilde, Status, Opprettet)
VALUES (22, 14, 8, 'Test', '10 dager gammel', null, 'act', ADDDATE(CURRENT_TIMESTAMP, INTERVAL -10 DAY));

SELECT * FROM NordicDoor.Forslag;

-- TeamMedlemskap
-- Avdeling Produksjon
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
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 7);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (1, 8);

-- Produksjon fase 1
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (2, 1);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (2, 2);

-- Produksjon fase 2
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (3, 3);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (3, 4);

-- Produksjon fase 3
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (4, 5);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (4, 6);

-- Produksjon fase 4
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (5, 7);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (5, 8);

-- Avdeling Salg
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 9);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 10);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 11);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 12);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 13);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 14);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 15);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 16);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 17);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 18);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 19);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 20);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 21);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 22);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (6, 23);

-- Salg fase 1
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (7, 11);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (7, 12);

-- Salg fase 2
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (8, 13);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (8, 14);

-- Salg fase 3
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (9, 15);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (9, 16);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (9, 23);

-- Salg fase 4
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (10, 17);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (10, 18);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (10, 22);

-- Salg fase 5
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (11, 19);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (11, 20);
INSERT INTO NordicDoor.TeamMedlemskap (TeamId, AnsattNr)
VALUES (11, 21);




SELECT * FROM NordicDoor.TeamMedlemskap;


-- ForslagKobling

-- Team 2
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (1, 1);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (2, 1);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (1, 2);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (2, 2);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (1, 9);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (2, 9);

-- Team 3
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 3);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 3);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 4);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 4);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 6);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 6);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 8);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 8);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 11);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 11);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 12);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 12);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 13);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 13);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (3, 14);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (4, 14);


-- Team 4
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (5, 5);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (6, 5);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (5, 7);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (6, 7);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (5, 10);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (6, 10);

-- Team 7
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (11, 15);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (12, 15);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (11, 16);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (12, 16);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (11, 17);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (12, 17);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (11, 18);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (12, 18);


-- Team 8
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (13, 19);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (14, 19);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (13, 20);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (14, 20);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (13, 21);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (14, 21);

INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (13, 12);
INSERT INTO NordicDoor.ForslagKobling (AnsattNr, ForslagId)
VALUES (14, 12);

SELECT * FROM NordicDoor.ForslagKobling;
