



--create database TestJC_Employee
--go
use TestJC_Employee;
go

select * from EmployeeRecord

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


CREATE or alter PROCEDURE GetEmployees
@EmployeeLastName nvarchar(150),
@EmployeePhone nvarchar(20)
as
BEGIN
	Select EmployeeId,EmployeeLastName,EmployeeFirstName,EmployeePhone,EmployeeZip,HireDate
	from EmployeeRecord with(nolock)
	where (EmployeeLastName like '%'+@EmployeeLastName+'%' or @EmployeeLastName = '') and (EmployeePhone like '%'+@EmployeePhone+'%' or @EmployeePhone = '')
END
go

CREATE OR ALTER PROCEDURE SetEmployee
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

CREATE OR ALTER PROCEDURE DeleteEmployee
@EmployeeId int
as
BEGIN
	DELETE EmployeeRecord where EmployeeId = @EmployeeId
END












