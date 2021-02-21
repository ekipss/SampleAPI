CREATE SCHEMA university AUTHORIZATION dbo
GO

CREATE TABLE university.Students
(
	[Uid] UNIQUEIDENTIFIER NOT NULL,
	[Email] VARCHAR(255) NOT NULL,
	[Name] VARCHAR(200) NULL,
	CONSTRAINT [PK_university_Students_Uid] PRIMARY KEY ([Uid] ASC)
)
GO

INSERT INTO university.Students VALUES ('ef44ca8e-7227-11eb-9439-0242ac130002', 'vasya@mail.ru', 'Vasya');
INSERT INTO university.Students VALUES ('f69c6562-7227-11eb-9439-0242ac130002', 'petya@mail.ru', 'Petya');

CREATE TABLE university.Education
(
	[Uid] UNIQUEIDENTIFIER NOT NULL,
	[StudentUid] UNIQUEIDENTIFIER NOT NULL,
	[Price] DECIMAL (18, 2) NOT NULL,
	[StatusId] TINYINT NOT NULL,
	[CreateDate] DATETIME2 NOT NULL,
	[EditDate] DATETIME2 NULL,
	[IsRemoved] BIT NOT NULL,
	CONSTRAINT [PK_university_Education_Uid] PRIMARY KEY ([Uid] ASC)
)
GO

CREATE TABLE university.Courses
(
	[Uid] UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(200)
	CONSTRAINT [PK_university_Courses_Uid] PRIMARY KEY ([Uid] ASC)
)
GO

INSERT INTO university.Courses VALUES ('ea4cf1a4-7228-11eb-9439-0242ac130002', 'English');
INSERT INTO university.Courses VALUES ('f30a9c74-7228-11eb-9439-0242ac130002', 'Informatics');
GO

CREATE TABLE university.EducationCourses
(
	[EducationUid] UNIQUEIDENTIFIER NOT NULL,
	[CourseUid] UNIQUEIDENTIFIER NOT NULL,
	[Price] DECIMAL(18, 2),
	CONSTRAINT [PK_university_EducationCourses_EducationUid_CourseUid] PRIMARY KEY ([EducationUid] ASC, [CourseUid] ASC)
)
GO

CREATE TABLE university.CoursePrices
(
	[CourseUid] UNIQUEIDENTIFIER NOT NULL,
	[Price] DECIMAL(18, 2) NOT NULL,
	CONSTRAINT [PK_university_CoursePrices_CourseUid] PRIMARY KEY ([CourseUid] ASC)
)
GO

INSERT INTO university.CoursePrices VALUES ('ea4cf1a4-7228-11eb-9439-0242ac130002', 5000);
INSERT INTO university.CoursePrices VALUES ('f30a9c74-7228-11eb-9439-0242ac130002', 14580);


GO

CREATE VIEW university.v_Education
AS
(
	SELECT
		[Education].[Uid],
		[Education].[StudentUid],
		[Education].[Price],
		[Education].[IsRemoved]
	FROM university.Education AS [Education]
)
GO

CREATE VIEW university.v_EducationCourses
AS
(
	SELECT
		[EducationCourse].[EducationUid],
		[EducationCourse].[CourseUid],
		[EducationCourse].[Price],
		[Course].[Name]
	FROM university.EducationCourses AS [EducationCourse]
		INNER JOIN university.Courses AS [Course]
			ON [EducationCourse].CourseUid = [Course].[Uid]
)
GO



CREATE SCHEMA payments AUTHORIZATION dbo
GO

CREATE TABLE payments.Payments
(
	[Uid] UNIQUEIDENTIFIER NOT NULL,
	[CreateDate] DATETIME2 NOT NULL,
	[StatusId] TINYINT NOT NULL,
	[EducationUid] UNIQUEIDENTIFIER NOT NULL,
    [EmailNotificationIsSent] BIT NOT NULL
	CONSTRAINT [PK_payments_Payments_Uid] PRIMARY KEY ([Uid] ASC)
)