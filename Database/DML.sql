Insert Into Areas (area,zipcode ) values('BBB','12345')
Insert into Areas values('CCC','54321')
Insert Into Areas (area,zipcode ) values('AAA','12355')
--!Primary key cannot be duplicated
Insert Into Areas (area,zipcode ) values('AAA','13355')

select * from Areas

Insert into Skills values('C','PLT')
Insert into Skills values('C++','OOPS'),('Java','Web'),('SQL','RDBMS')

select * from Skills

insert into Employees(name,age,area) values('Ramu',23,'AAA')
insert into Employees(name,age,area) values('Somu',34,'BBB'),('Bimu',56,'AAA')
--!will not get inserted
insert into Employees(name,age,area) values('Ramu',23,'ABA')

select * from Employees

Insert into EmployeesSkills values(101, 'C',7)
Insert into EmployeesSkills values(101, 'C++',7)
Insert into EmployeesSkills values(101, 'Java',6)
Insert into EmployeesSkills values(102, 'Java',7)
Insert into EmployeesSkills values(102, 'SQL',8)

select * from EmployeesSkills

update EmployeesSkills SET skill_level=8 WHERE employee_id=101 and skill_name='C'

update Employees Set age=29 where name='Bimu'

update Employees set name='Komu', age=22 where employee_id=102

select * from Employees

--!cant delete from parent table
delete from Skills where skill='C'

--!delete from chiled to delete from parent
delete from EmployeesSkills where skill_name='C'
delete from Skills where skill ='C'


use dbCompany26Oct2023

select * from EmployeesSkills

create trigger trgInsertEmployeeSkill
on EmployeesSkills
instead of insert
as
begin
   declare 
	 @skillName varchar(20),
	 @empId int,
	 @level int
	 set @SkillName = (select skill_name from inserted)
	 set @empId =  (select employee_id from inserted)
	 set @level =  (select skill_level from inserted)
	 if((select count(skill) from Skills where skill= @skillName) =0)
	 begin
			print 'Skill not present in skill table'
	end
	else
	begin
	    insert into EmployeesSkills values(@empId,@skillName,@level)	
	end
end

insert into EmployeesSkills values(101,'SQ',8)
insert into EmployeesSkills values(101,'SQL',8)

select * from EmployeesSkills