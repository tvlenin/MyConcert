CREATE TABLE COUNTRY(
	PK_ID_COUNTRY INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30) NOT NULL 
)

CREATE TABLE UNIVERSITY(
	PK_ID_UNIVERSITY INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name varchar(30)
)

CREATE TABLE MCUSER(
	PK_ID_MCUSER INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	FK_ID_Country INT NOT NULL,
	Residence VARCHAR(100),
	FK_ID_University INT,
	Email VARCHAR(50) NOT NULL,
	Phone VARCHAR(15) NOT NULL,
	Photo VARCHAR(30),
	RegistrationDate date NOT NULL,
	MCPassword varchar(8) NOT NULL,
	PersonalDescription varchar(300) NOT NULL,
	Birthdate date,
	FK_ID_State int
)

CREATE TABLE USER_STATE(
	PK_ID_USER_STATE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name varchar(30)
)

CREATE TABLE USER_GENRE_LIST(
	PK_ID_USER_GENRE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_User INT,
	FK_ID_Genre INT
)

CREATE TABLE MCUSER_ADMIN(
	PK_ID_MCUSER_ADMIN INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30)NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	MCpassword VARCHAR(8) NOT NULL,
	FK_ID_State INT NOT NULL,
	RegistrationDate DATE NOT NULL
)

CREATE TABLE PLACE(
	PK_ID_PLACE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30)
)

CREATE TABLE BILLBOARD(
	PK_ID_BILLBOARD INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30),
	StartVotingDate DATE,
	EndVotingDate DATE,
	FK_ID_Place INT,
	FK_ID_UserVote INT,
	FK_ID_EventState int
)

CREATE TABLE USER_VOTE(
	PK_ID_VOTE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Billboard INT,
	FK_ID_User INT
)

CREATE TABLE CATEGORY_LIST(
	PK_ID_CATEGORY INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Billboard INT,
	FK_ID_BillboardCategory INT
)

CREATE TABLE BILLBOARD_CATEGORY(
	PK_ID_BILLBOARD_CATEGORY INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Category INT
)

CREATE TABLE CATEGORY(
	PK_ID_CATEGORY INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30)
)

CREATE TABLE BILLBOARD_BANDS_LIST(
	PK_ID_BILLBOARD_BANDS_LIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_BillboardCategory INT,
	FK_ID_Band INT,
	Money INT,
	FK_ID_User_Vote INT
)

CREATE TABLE BAND(
	PK_ID_BAND INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30),
	Calification FLOAT,
	N_Calification INT,
	FK_ID_GenreList INT
)

CREATE TABLE BAND_GENRE_LIST(
	PK_ID_BAND_GENRE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Band INT,
	FK_ID_Genre INT
)

CREATE TABLE BAND_ARTIST(
	PK_ID_BAND_ARTIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Band INT,
	FK_ID_Artist INT
)

CREATE TABLE ARTIST(
	PK_ID_ARTIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30)
)

CREATE TABLE GENRE(
	PK_ID_GENRE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30)
)

CREATE TABLE COMMENT(
	PK_ID_COMMENTS INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Comment VARCHAR(300),
	Score int,
	FK_ID_User INT
)

CREATE TABLE COMMENT_LIST(
	PK_ID_COMMENT_LIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Band INT,
	FK_ID_Comment INT
)

CREATE TABLE FESTIVAL(
	PK_ID_FESTIVAL INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Billboard INT,
	FK_ID_Category_List INT,
	FestivalStart Date,
	FestivalEnd Date,
	FK_ID_Place INT,
	FK_ID_EventState INT
)

CREATE TABLE FESTIVAL_CATEGORY_LIST(
	PK_ID_FESTIVAL_CATEGORY_LIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Festival INT,
	FK_ID_FestivalCategory INT,
)

CREATE TABLE FESTIVAL_BANDS_LIST(
	PK_ID_FESTIVAL_BANDS_LIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_FestivalCategory INT,
	FK_ID_Band INT
)

CREATE TABLE FESTIVAL_CATEGORY(
	PK_ID_FESTIVAL_CATEGORY INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Category INT
)

CREATE TABLE EVENT_STATE(
	PK_ID_EVENT_STATE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(30)
)

CREATE TABLE SONG_LIST(
	PK_ID_SONG_LIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Band INT,
	FK_ID_Song INT
)

CREATE TABLE SONG(
	PK_ID_SONG INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(100)
)


CREATE TABLE SONG_LIST(
	PK_ID_SONG_LIST INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FK_ID_Band INT,
	FK_ID_Song INT
)

CREATE TABLE SONG(
	PK_ID_SONG INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(100)
)