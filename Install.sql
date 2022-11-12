

create database TestJC_Employee
GO

use TestJC_Employee;
GO

IF OBJECT_ID('[dbo].[DeleteEmployee]', 'P') IS NOT NULL  
  DROP PROCEDURE dbo.DeleteEmployee;
GO

IF OBJECT_ID('[dbo].[SetEmployee]', 'P') IS NOT NULL  
  DROP PROCEDURE dbo.SetEmployee;
GO

IF OBJECT_ID('[dbo].[GetEmployees]', 'P') IS NOT NULL  
  DROP PROCEDURE dbo.GetEmployees;
GO

IF OBJECT_ID('[dbo].[EmployeeRecord]', 'U') IS NOT NULL  
  DROP TABLE dbo.EmployeeRecord

CREATE TABLE EmployeeRecord
(
EmployeeId int not null primary key identity,
EmployeeLastName nvarchar(150) not null,
EmployeeFirstName nvarchar(150) not null,
EmployeePhone nvarchar(20) not null,
EmployeeZip char(5),
HireDate date
)
go

CREATE PROCEDURE GetEmployees
@EmployeeLastName nvarchar(150),
@EmployeePhone nvarchar(20)
as
BEGIN
	Select EmployeeId,EmployeeLastName,EmployeeFirstName,EmployeePhone,EmployeeZip,HireDate
	from EmployeeRecord with(nolock)
	where (EmployeeLastName like '%'+@EmployeeLastName+'%' or @EmployeeLastName = '') and (EmployeePhone like '%'+@EmployeePhone+'%' or @EmployeePhone = '')
END
go

CREATE PROCEDURE SetEmployee
@EmployeeLastName nvarchar(150),
@EmployeeFirstName nvarchar(150),
@EmployeePhone nvarchar(20),
@EmployeeZip char(5),
@EmployeeId int
as
BEGIN
	
	IF NOT EXISTS(SELECT EmployeeId FROM EmployeeRecord where EmployeeId = @EmployeeId)
	BEGIN
	INSERT INTO EmployeeRecord (EmployeeLastName,EmployeeFirstName,EmployeePhone,EmployeeZip,HireDate) 
	VALUES (@EmployeeLastName,@EmployeeFirstName,@EmployeePhone,@EmployeeZip,FORMAT(GETDATE(),'MM-dd-yyyy'))
	END
	ELSE
	BEGIN 
		UPDATE EmployeeRecord set 
			EmployeeLastName = @EmployeeLastName,
			EmployeeFirstName = @EmployeeFirstName,
			EmployeePhone = @EmployeePhone,
			EmployeeZip = @EmployeeZip
			WHERE 
			EmployeeId = @EmployeeId;
	END

END
go

CREATE PROCEDURE DeleteEmployee
@EmployeeId int
as
BEGIN
	DELETE EmployeeRecord where EmployeeId = @EmployeeId
END












