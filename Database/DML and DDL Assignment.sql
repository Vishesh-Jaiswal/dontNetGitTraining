create database Employees_Assignment

use Employees_Assignment

sp_help EMP
sp_help DEPARTMENT
sp_help SALES
sp_help ITEM

create table EMP(empno int identity(1,1) constraint emp_key primary key,
Empname varchar(20),Empsalary money, Deptname varchar(20) null,
Bossno int null constraint fk_empno foreign key references EMP(empno))

create table DEPARTMENT(deptname varchar(20) constraint pk_deptname primary key,
Deptfloor int, Deptphone int, Mgrid int constraint fk_mgrid 
foreign key references EMP(empno) null)

create table SALES(salesno int identity(101,1) constraint pk_salesno primary key,
Saleqty int,itemname varchar(30), Deptname varchar(20) constraint fk_deptname
foreign key references DEPARTMENT(deptname))

create table ITEM(Itemname varchar(30) constraint pk_itemname primary key,
itemtype char(1), itemcolor varchar(10) null)

INSERT INTO EMP (Empname, Empsalary, Deptname,Bossno)
VALUES
    ('Alice', 75000, 'Management', NULL),
    ('Ned', 45000, 'Marketing', 1),
    ('Andrew', 25000, 'Marketing', 2),
    ('Clare', 22000, 'Marketing', 2),
    ('Todd', 38000, 'Accounting', 1),
    ('Nancy', 22000, 'Accounting', 5),
    ('Brier', 43000, 'Purchasing', 1),
    ('Sarah', 56000, 'Purchasing', 7),
    ('Sophile', 35000, 'Personnel', 1),
    ('Sanjay', 15000, 'Navigation', 3),
    ('Rita', 15000, 'Books', 4),
    ('Gigi', 16000, 'Clothes', 4),
    ('Maggie', 11000, 'Clothes', 4),
    ('Paul', 15000, 'Equipment', 3),
    ('James', 15000, 'Equipment', 3),
    ('Pat', 15000, 'Furniture', 3),
    ('Mark', 15000, 'Recreation', 3)

select * from EMP

INSERT INTO DEPARTMENT (Deptname, Deptfloor, Deptphone, MgrId)
VALUES
    ('Management', 5, 34, 1),
    ('Books', 1, 81, 4),
    ('Clothes', 2, 24, 4),
    ('Equipment', 3, 57, 3),
    ('Furniture', 4, 14, 3),
    ('Navigation', 1, 41, 3),
    ('Recreation', 2, 29, 4),
    ('Accounting', 5, 35, 5),
    ('Purchasing', 5, 36, 7),
    ('Personnel', 5, 37, 9),
    ('Marketing', 5, 38, 2)

select * from DEPARTMENT

INSERT INTO SALES (Saleqty, itemname, Deptname)
VALUES
    (2, 'Boots-snake proof', 'Clothes'),
    (1, 'Pith Helmet', 'Clothes'),
    (1, 'Sextant', 'Navigation'),
    (3, 'Hat-polar Explorer', 'Clothes'),
    (5, 'Pith Helmet', 'Equipment'),
    (2, 'Pocket Knife-Nile', 'Clothes'),
    (3, 'Pocket Knife-Nile', 'Recreation'),
    (1, 'Compass', 'Navigation'),
    (2, 'Geo positioning system', 'Navigation'),
    (5, 'Map Measure', 'Navigation'),
    (1, 'Geo positioning system', 'Books'),
    (1, 'Sextant', 'Books'),
    (3, 'Pocket Knife-Nile', 'Books'),
    (1, 'Pocket Knife-Nile', 'Navigation'),
    (1, 'Pocket Knife-Nile', 'Equipment'),
    (1, 'Sextant', 'Clothes'),
    (1, 'Equipment', 'Recreation'),
    (1, 'Recreation', 'Furniture'),
    (1, 'Furniture', 'Navigation'),
    (1, 'Pocket Knife-Nile', NULL),
    (1, 'Exploring in 10 easy lessons', 'Books'),
    (1, 'How to win foreign friends', NULL),
    (1, 'Compass', NULL),
    (1, 'Pith Helmet', NULL),
    (1, 'Elephant Polo stick', 'Recreation'),
    (1, 'Camel Saddle', 'Recreation')

select * from SALES

INSERT INTO ITEM (Itemname, itemtype, itemcolor)
VALUES
    ('Pocket Knife-Nile', 'E', 'Brown'),
    ('Pocket Knife-Avon', 'E', 'Brown'),
    ('Compass', 'N', NULL),
    ('Geo positioning system', 'N', NULL),
    ('Elephant Polo stick', 'R', 'Bamboo'),
    ('Camel Saddle', 'R', 'Brown'),
    ('Sextant', 'N', NULL),
    ('Map Measure', 'N', NULL),
    ('Boots-snake proof', 'C', 'Green'),
    ('Pith Helmet', 'C', 'Khaki'),
    ('Hat-polar Explorer', 'C', 'White'),
    ('Exploring in 10 Easy Lessons', 'B', NULL),
    ('Hammock', 'F', 'Khaki'),
    ('How to win Foreign Friends', 'B', NULL),
    ('Map case', 'E', 'Brown'),
    ('Safari Chair', 'F', 'Khaki'),
    ('Safari cooking kit', 'F', 'Khaki'),
    ('Stetson', 'C', 'Black'),
    ('Tent - 2 person', 'F', 'Khaki'),
    ('Tent -8 person', 'F', 'Khaki')

select * from ITEM