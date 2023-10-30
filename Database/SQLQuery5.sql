use pubs

select * from authors
-- For restriction on rows
select * from authors where state ='CA'
-- Column selection
select au_lname 'Author Name', au_fname 'Phone' from authors

select au_fname Author_Name, phone Phone_Number from authors

select au_fname+' '+au_lname 'Author Name', phone 'Phone Number' from authors

select * from authors where contract=0

select title 'Book Name', price 'Cost', royalty 'Royalty Paid',
advance 'Advance received' from titles where royalty >10 and price>15

select title from titles where price >=10 and price<=25

select title from titles where price between 10 and 25

select * from titles where title like 'The%'

--isnull
select price from titles where price is null

--fetch those title that have 'data' any where in teh title
select * from titles where title like '%data%'

--fetch those titles whcih are published before '1991-06-18 00:00:00.000'
select title 'Book Name' from titles where pubdate<'1991-06-18 00:00:00.000'

--fetch the book name and the price of those books that have been published by 0877
select title 'Book Name',price 'Price' from titles where pub_id='0877'

-- fetch  book name, price nad notes of books from business 
-- type that re priced in the range of 15 to 100
select title 'Book Name',price 'Price',notes 'Notes'
from titles where price between 15 and 100 and type='business'

--look for multiple values
select * from titles where price in (10, 20, 30)

--Aggegate data
select AVG(price) 'Average Price' from titles

select AVG(price) 'Average Price' from titles where type='business'

select AVG(price) 'Average Price', Sum(price) 'Sum of price' from titles


--Sub total and grouping
select type 'Type Name' , AVG(price) 'Average Price' from titles group by type

select state, count(au_id) from authors group by state

select title_id, count(ord_num) 'number of times sold'
from sales group by title_id

select title_id, count(ord_num) 'number of times sold'
from sales group by title_id having Count(ord_num)>1

select type 'Type Name' , AVG(price) 'Average Price'
from titles where price >10 group by type having AVG(price)>18

--sorting
select * from authors

select * from authors order by state,city,au_fname

select type 'Type Name' , AVG(price) 'Average Price'
from titles where price >10 group by type having AVG(price)>18 order by type desc

--subquries
select * from titles
select * from titleauthor
select * from sales
select * from publishers
select title_id from titles where title = 'Straight Talk About Computers'
select * from sales where title_id = 'BU7832'

select * from sales where title_id =
(select title_id from titles where title = 'Straight Talk About Computers')


Select * from titles where title_id in(
select title_id from titleauthor where au_id = 
(select au_id from authors where au_lname = 'White'))

select title 'Book Name' from titles where title_id in
(select title_id from sales)

--fetch the average price of titles that hvae been published by publishers 
--who are from USA. Print only if the average is greater than the average of
-- all the titles
--sort them by asencending order of the average

select title 'Title Name',AVG(price) 'Average Price' from titles where pub_id in
(select pub_id from publishers where country='USA')
group by title
having AVG(price)>(select AVG(price) from titles)
order by 'Average Price' asc

sp_help titles

use pubs

select * from publishers

select * from titles
--select publisher name and the title name
select pub_name 'Publisher Name', title 'Book Name' from publishers join titles
on publishers.pub_id = titles.pub_id

select pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id

select p.pub_id 'Publisher Id', pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id
order by [Publisher Name]

--outer JOin
select pub_name 'Publisher Name', title 'Book Name' 
from publishers left outer join titles
on publishers.pub_id = titles.pub_id

select t.title Book_Name, s.qty Quantity_Sold
from sales s right outer join titles t
on s.title_id = t.title_id

select pub_name 'Publisher Name', count(t.pub_id) 'Number of Books Published' 
from publishers p join titles t
on p.pub_id = t.pub_id
group by pub_name
order by [Publisher Name]

select * from employee

select fname 'Employee Name',pub_name 'Publisher Name' from employee e left outer join publishers p
on e.pub_id=p.pub_id order by [Employee Name]

select * from authors
select * from titles
select * from titleauthor

sp_help titleauthor

select title 'Book Name', CONCAT(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id 
join authors a on ta.au_id = a.au_id

select pub_name 'Publisher Name', title 'Book', sum(qty) 'No. of books sold'
from titles t join publishers p
on t.pub_id =p.pub_id
join sales s on t.title_id=s.title_id group by pub_name,title

create table tbl1
(f1 int,
f2 varchar(20))

insert into tbl1 values(1,'abc'),(2,'efg'),(3,'klj'),(4,'jjj')
--data injection
select * from tbl1 where f1=1;delete  from tbl1;

create procedure proc_First
as
begin
    select * from authors
end

execute proc_First

create proc proc_InsertSample(@f1 int, @f2 varchar(20))
as
begin
   insert into tbl1 values(@f1,@f2)
end
go
exec proc_InsertSample 5,'GYH'
exec proc_InsertSample 5,'GYH;delete from tbl1'

select * from tbl1

DROP PROCEDURE dbo.proc_InsertSample 
GO