-- Add new questions
SET IDENTITY_INSERT Questions ON;
INSERT INTO Questions (Id, Text) VALUES (5, 'Is it a feline?');
INSERT INTO Questions (Id, Text) VALUES (6, 'Is it dangerous to humans?');
SET IDENTITY_INSERT Questions OFF;

-- Add answers for "Is it a feline?" (QuestionId = 5)
-- Values: 0 = No, 1 = Maybe, 2 = Yes
SET IDENTITY_INSERT AnimalAnswers ON;
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (33, 1, 5, 0);  -- Penguin - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (34, 2, 5, 0);  -- Dog - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (35, 3, 5, 0);  -- Eagle - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (36, 4, 5, 0);  -- Shark - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (37, 5, 5, 2);  -- Cat - Yes!
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (38, 6, 5, 0);  -- Whale - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (39, 7, 5, 0);  -- Bat - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (40, 8, 5, 0);  -- Salmon - No

-- Add answers for "Is it dangerous to humans?" (QuestionId = 6)
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (41, 1, 6, 0);  -- Penguin - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (42, 2, 6, 1);  -- Dog - Maybe (some can be)
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (43, 3, 6, 1);  -- Eagle - Maybe (can attack)
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (44, 4, 6, 2);  -- Shark - Yes!
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (45, 5, 6, 0);  -- Cat - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (46, 6, 6, 0);  -- Whale - No
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (47, 7, 6, 1);  -- Bat - Maybe (rabies)
INSERT INTO AnimalAnswers (Id, AnimalId, QuestionId, Value) VALUES (48, 8, 6, 0);  -- Salmon - No
SET IDENTITY_INSERT AnimalAnswers OFF;