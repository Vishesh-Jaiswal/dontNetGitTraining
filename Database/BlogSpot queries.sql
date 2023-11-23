--Delete----------------
delete from Users

delete from Products

delete from Carts

delete from CartItems

--select------------------
sp_help Users
sp_help Blogs
sp_help CartItems
select * from Blogs
select * from users order by RegistrationDate desc
select * from Comments
select * from Follows

select * from Products
select * from Orders
select * from Carts

select * from CartItems

SP_HELP USERS

ALTER TABLE USERS ALTER COLUMN RegistrationDate DATETIME NULL

use dbShopping06Nov2023

drop database dbShopping06Nov2023

create database dbShopping06Nov2023

drop database BlogSpotDB

create database BlogSpotDB

use BlogSpotDB