DROP TABLE Task
DROP TABLE List
DROP TABLE Users

CREATE TABLE Users
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(40) not null,
	Email varchar(100) not null,
	Password varchar(40) not null
)

CREATE TABLE List
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(40) not null,
	TaskCount int null,
	AccountID int not null REFERENCES Users(Id)
)

CREATE TABLE Task
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(40) not null,
	Description varchar(200) null,
	ListId int not null REFERENCES List(Id)
)

SELECT * FROM Users
SELECT * FROM Task
SELECT * FROM List