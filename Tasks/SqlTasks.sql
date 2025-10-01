CREATE TABLE Teacher (
    TeacherID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10),
    Subject VARCHAR(50),
);

CREATE TABLE Pupil (
    PupilID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10),
    Class VARCHAR(20)
)

-- ცალკე ცხრილს იმიტო ვაკეთებთ რადგანაც M - N ზეგვაქვს კავშირი
CREATE TABLE TeacherPupil (
    TeacherID INT,
    PupilID INT,
    PRIMARY KEY (TeacherID, PupilID),
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
    FOREIGN KEY (PupilID) REFERENCES Pupil(PupilID)
);

SELECT *
FROM Teacher t
         JOIN TeacherPupil tp ON t.TeacherID = tp.TeacherID
         JOIN Pupil p ON tp.PupilID = p.PupilID
WHERE p.FirstName = 'გიორგი';


