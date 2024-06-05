-- Active: 1717571314830@@behxw1kewheddraef7b1-mysql.services.clever-cloud.com@3306

CREATE TABLE Authors(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125),
    LastName VARCHAR(45),
    Email VARCHAR(125),
    Nacionality VARCHAR(125)
);

CREATE TABLE Editorials(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125),
    Address VARCHAR(125),
    Phone VARCHAR(35),
    Email VARCHAR(125)
);

CREATE TABLE Books(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(225),
    Pages INTEGER(10),
    Language VARCHAR(125),
    PublicationDate DATE,
    Description TEXT,
    AuthorId INT,
    EditorialId INT
);

SELECT * FROM Authors;

/* FOREIG KEY */
ALTER TABLE `books` ADD FOREIGN KEY (AuthorId) REFERENCES `authors`(Id);
ALTER TABLE `books` ADD FOREIGN KEY (EditorialId) REFERENCES `editorials`(Id);



INSERT INTO books(Title, Pages, Language, PublicationDate, Description, AuthorId, EditorialId)VALUES
('Book Title 6', 420, 'Portuguese', '2022-06-10', 'Description of Book 6', 1, 1),
('Book Title 7', 380, 'Russian', '2022-07-25', 'Description of Book 7', 2, 2),
('Book Title 8', 450, 'Chinese', '2022-08-15', 'Description of Book 8', 3, 3),
('Book Title 9', 300, 'Japanese', '2022-09-01', 'Description of Book 9', 4, 1),
('Book Title 10', 480, 'Arabic', '2022-10-30', 'Description of Book 10', 5, 2);

INSERT INTO authors(Name, LastName, Email, Nacionality)VALUES
('Author Name 1', 'Author LastName 1', 'author1@example.com', 'Nacionality 1'),
('Author Name 2', 'Author LastName 2', 'author2@example.com', 'Nacionality 2'),
('Author Name 3', 'Author LastName 3', 'author3@example.com', 'Nacionality 3'),
('Author Name 4', 'Author LastName 4', 'author4@example.com', 'Nacionality 4'),
('Author Name 5', 'Author LastName 5', 'author5@example.com', 'Nacionality 5'),
('Author Name 6', 'Author LastName 6', 'author6@example.com', 'Nacionality 6'),
('Author Name 7', 'Author LastName 7', 'author7@example.com', 'Nacionality 7'),
('Author Name 8', 'Author LastName 8', 'author8@example.com', 'Nacionality 8'),
('Author Name 9', 'Author LastName 9', 'author9@example.com', 'Nacionality 9'),
('Author Name 10', 'Author LastName 10', 'author10@example.com', 'Nacionality 10');

INSERT INTO editorials(Name, Address, Phone, Email)VALUES
('Editorial Name 1', 'Editorial Address 1', '+1234567890', 'editorial1@example.com'),
('Editorial Name 2', 'Editorial Address 2', '+9876543210', 'editorial2@example.com'),
('Editorial Name 3', 'Editorial Address 3', '+5555555555', 'editorial3@example.com');

ALTER TABLE authors RENAME TO Authors;
ALTER TABLE editorials RENAME TO Editorials;
ALTER TABLE books RENAME TO Books;


ALTER TABLE Books ADD Status VARCHAR(45) AFTER Description;

ALTER TABLE Authors ADD Status VARCHAR(45) AFTER Nacionality;

ALTER TABLE Editorials ADD Status VARCHAR(45) AFTER Email;