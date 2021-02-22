DELETE FROM payments.Payments
GO

DELETE FROM university.EducationCourses
GO

DELETE FROM university.Education
GO

DELETE FROM university.Students
WHERE Id NOT IN ('ef44ca8e-7227-11eb-9439-0242ac130002', 'f69c6562-7227-11eb-9439-0242ac130002')
