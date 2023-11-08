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

create proc proc_Select(@f2 varchar(20))
as
begin
   select * from tbl1 where f2=@f2
end

exec proc_Select 'abc;delete from tbl1'
exec proc_Select 'abc'

create proc proc_GetTotalSaleAmount(@authorName varchar(20),@salemount float out)
as
begin
   declare
    @saleamt float
	set @saleamt = (select sum(s.qty) * sum(t.price) from sales s join titles t 
						on s.title_id=t.title_id
						where t.title_id in
						(select title_id from titleauthor where au_id= 
						(select au_id from authors where au_fname = @authorName)))
	set @salemount = @saleamt
end


select * from authors

declare @amt float
begin
exec proc_GetTotalSaleAmount 'Cheryl',@amt out
print @amt
end


create function fn_CalculateTax(@price float)
returns float
as
begin
    declare @totalPrice float
	set @totalPrice = @price +(@price*12.36/100)
	return round(@totalPrice,2)
end

select title,price,dbo.fn_CalculateTax(price) 'Nett. Price'
from titles


--create a function that will take the author's first name and last name and 
--give back the full name separated by space
create function full_Name(@au_fname varchar(20),@au_lname varchar(40))
returns varchar(40)
as
begin
	declare @fullName varchar(40)
	set @fullName	= @au_fname+' '+@au_lname
	return @fullName
end

select au_fname,au_lname,dbo.full_Name(au_fname,au_lname) 'Author Full Name' from authors


--create a procedure that will take the publisher name and give back the total sale 
--for the books published
create proc total_sales(@pubName varchar(40))
as
begin
    select (sum(s.qty)*sum(t.price)) as 'sales'from sales s join titles t
	on s.title_id=t.title_id join publishers p on p.pub_id=t.pub_id
end

exec total_sales 'New Moon Books'



--VIew
create view vwPublisher
as
select pub_id 'Publisher Id', pub_name 'Publisher Name'  from Publishers

select * from vwPublisher

create view vwInvoice
as
 select t.title 'Book Name', sum(s.qty)*sum(t.price) 'Sale Amount' from sales s join titles t
                    on s.title_id=t.title_id
					group by t.title 

select * from vwInvoice

create index idxSample on tbl1(f1)

sp_help tbl1

create trigger trg_InsertTbl1
on tbl1
for insert
as
begin
   print 'Hello'
end

insert into tbl1 values(101,'UUU')

select * from tbl1


select * from authors
select * from sales
select * from stores
select * from titles
select * from publishers
select * from titleauthor
select * from pub_info

select stor_name 'Store Name',title 'Book',qty 'Quanity',(ytd_sales*price) as 'Sale Amount',
pub_name 'Publisher name',au_fname+' '+au_lname 'Author Name'
from stores s join sales sa on s.stor_id=sa.stor_id right outer join titles t
on t.title_id=sa.title_id
join publishers p on t.pub_id=p.pub_id join titleauthor ta on ta.title_id=t.title_id
right outer join authors a on a.au_id=ta.au_id

drop proc total_auth_sales

create proc total_auth_sales(@pubName varchar(40))
as
begin
    select au_fname+' '+au_lname as Author,(sum(s.qty)*t.price) as 'sales'from sales s join titleauthor ta 
	on s.title_id=ta.title_id join authors a on a.au_id=ta.au_id join titles t on
	s.title_id=t.title_id group by Author
end

exec total_sales 'New Moon Books'

create proc name_Look()

select sa.stor_id,stor_name,t.title,ord_num,ord_date,sum(qty)>max,payterms from sales sa join stores st on
sa.stor_id=st.stor_id join titles t on t.title_id=sa.title_id group by
sa.stor_id,stor_name,t.title,ord_num,ord_date,qty,payterms having max(qty)<sum(qty)

SELECT
    s.stor_id AS 'Store ID',
    s.title_id AS 'Title ID',
    t.title AS 'Title',
    s.qty AS 'Sale Quantity',
    s.ord_date AS 'Sale Date'
FROM sales s
left JOIN (
    SELECT
        s.stor_id,
        s.title_id,
        MAX(s.qty) AS max_qty
    FROM sales s
    GROUP BY s.stor_id, s.title_id
) max_sale_qty ON s.stor_id = max_sale_qty.stor_id
    AND s.title_id = max_sale_qty.title_id
    AND s.qty > max_sale_qty.max_qty
JOIN titles t ON s.title_id = t.title_id;

select concat(au_fname,' ',au_lname) as AuthorName, title 'Book' ,avg(price) 'Average Price' from
authors a join titleauthor ta on a.au_id=ta.au_id join titles t on t.title_id=ta.title_id
group by concat(au_fname,' ',au_lname),title

sp_help titles

select title 'Titles' from titles where title like '%e%' and title like '%a%'

--6
create procedure proc_CountBooks (@Price decimal(10, 2))
as
begin
    select count(*) 'No. of Books' from titles where price < @Price
END

EXEC proc_CountBooks 20

create 

create PROCEDURE get_total_sales_by_author (@author_name VARCHAR(60))
AS
BEGIN
DECLARE @total_sales DECIMAL(10,2);
SET @total_sales = (SELECT sum(s.qty )* sum(t.price)  FROM sales s
INNER JOIN titles t ON s.title_id = t.title_id
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id
WHERE a.au_fname + ' ' + a.au_lname = @author_name)
IF @total_sales IS NULL OR @total_sales = 0
BEGIN
PRINT 'Sale yet to gear up';
END
ELSE
BEGIN
PRINT 'The total sales amount for ' + @author_name + ' is ' + CAST(@total_sales AS VARCHAR);
END;
END;

EXEC get_total_sales_by_author @author_name = 'Green Marjorie';
select * from authors

alter TRIGGER trgPreventPriceUpdate
ON titles
FOR UPDATE
AS
BEGIN
    IF UPDATE(price) AND EXISTS (SELECT 1 FROM inserted WHERE price > 3000)
    BEGIN
        ROLLBACK;
        PRINT 'Price update is not allowed for prices below 7.';
    END
END;
select * from titles
where price<7
update titles set price=9000 where title_id='BU1111'

drop trigger trgPriceUpdate

SELECT  
    name,
    is_instead_of_trigger
FROM 
    sys.triggers  
WHERE 
    type = 'TR'

create PROCEDURE total_sales_author (@author_name VARCHAR(60))
AS
BEGIN
DECLARE @total_sales DECIMAL(10,2);
SET @total_sales = (SELECT sum(s.qty )* sum(t.price)  FROM sales s
INNER JOIN titles t ON s.title_id = t.title_id
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id
WHERE a.au_fname + ' ' + a.au_lname = @author_name)
IF @total_sales IS NULL OR @total_sales = 0
BEGIN
PRINT 'Sale yet to gear up';
END
ELSE
BEGIN
PRINT 'The total sales amount for ' + @author_name + ' is ' + CAST(@total_sales AS VARCHAR);
END;
END;

EXEC total_sales_author @author_name = 'Green Marjorie';

SELECT
    s.stor_id AS 'Store ID',
    s.title_id AS 'Title ID',
    t.title AS 'Title',
    s.qty AS 'Sale Quantity',
    s.ord_date AS 'Sale Date'
FROM sales s
left JOIN (
    SELECT
        s.stor_id,
        s.title_id,
        MAX(s.qty) AS max_qty
    FROM sales s
    GROUP BY s.stor_id, s.title_id
) max_sale_qty ON s.stor_id = max_sale_qty.stor_id
    AND s.title_id = max_sale_qty.title_id
    AND s.qty > max_sale_qty.max_qty
JOIN titles t ON s.title_id = t.title_id;