Select * from titleauthor
Select * from titles
select * from sales
select * from publishers
select * from pub_info
select * from authors

select title 'Titles' from titles

select title 'Titles' from titles where pub_id='1389'

select title 'Titles',price 'Price' from titles where price between 10 and 15

select title 'Titles',price 'Price' from titles where price is null

select title 'Titles' from titles where title like 'The%'

select title 'Titles' from titles where title not like '%v%'

select title 'Titles', royalty 'Royalty' from titles order by royalty

select title 'Titles',pub_id 'PUB ID',type 'Type',price 'Price' from titles
order by pub_id desc,type asc,price desc

select AVG(price) 'Average Price',type 'Type' from titles group by type

select distinct type 'Type' from titles

select top 2 title 'Titles',price 'Price' from titles order by price desc

select title 'Titles',price 'Price',advance 'Advance',type 'Type' from titles where 
(select type from titles where price<20 and type in(
select type from titles where type='business'and advance>7000 ))
--OR
select title 'Titles',price 'Price',advance 'Advance' from titles where
type='business' and price<20 and advance>7000

select pub_id 'Publisher ID',count(title_id) 'No of Books' from titles
where price between 15 and 25 and title like '%It%'
group by pub_id having count(title_id)>2 order by COUNT(title_id) asc

select au_fname+' '+au_lname 'Author Name', state 'State' from authors
where state='CA'

select count(au_id) 'No. of Publishers',state from authors group by state


---Set 2



select stor_id as Store_ID, ord_num 'Order Number' from sales group by stor_id

select title, ytd_sales from titles

select title,pub_name from titles, publishers where pub_name =
(select pub_name from publishers) 

select title 'Title',price 'Price', (price+price*12.36/100) as Tax from titles

select au_fname+' '+au_lname 'Author' from authors

select a.au_fname+' '+au_lname 'Author',t.title from authors a,titles t,titleauthor ta 
where a.au_id=ta.au_id and t.title_id=ta.title_id

select a.au_fname+' '+au_lname 'Author',t.title 'Book', p.pub_name 'Publisher' 
from authors a,titles t,titleauthor ta ,publishers p where a.au_id=ta.au_id and
t.title_id=ta.title_id and p.pub_id=t.pub_id

select p.pub_name,AVG(price) 'Average Price' from titles t,publishers p 
where t.pub_id=p.pub_id group by title_id

select a.au_fname+' '+au_lname as Author,t.title 'Book' from authors a,titles t,titleauthor ta 
where a.au_id=ta.au_id and t.title_id=ta.title_id and au_fname like '%Marjorie%'

select distinct ord_num 'Order Number' from sales where title_id in
(select title_id from titles where pub_id=
(select pub_id from publishers where pub_name='New Moon Books'))

select pub_name 'Publisher Name',count(qty) 'NO of Orders' from publishers p,titles t, sales s
where p.pub_id=t.pub_id and s.title_id=t.title_id group by pub_name

select ord_num 'Order Number',qty 'Quanity',price 'Price',(price*qty) as 'Total Price'
from titles t, sales s where s.title_id=t.title_id

select SUM(qty), s.title_id from sales s group by s.title_id

SELECT t.title 'Book name',(SUM(qty*price))
as 'Total Order Value' FROM sales s JOIN titles t ON s.title_id = t.title_id
GROUP BY t.title, s.title_id

select ord_num 'Order Number',t.title 'Book Name' from sales s,titles t
where t.title_id=s.title_id and s.title_id in
(select title_id from titles  where pub_id=
(select pub_id from employee where fname='Paolo'))

select AVG(price) 'Average Price', pub_name 'Publisher Name' from titles t
JOIN publishers p on t.pub_id=p.pub_id
group by pub_name,t.pub_id

select stor_id 'Store ID',COUNT(ord_num) 'Number of Orders' from sales
group by stor_id

select distinct title 'Book',pub_name 'Publisher Name' from titles, publishers

Select * from titleauthor
Select * from titles
select * from sales
select * from stores
select * from publishers
select * from pub_info
select * from authors
select * from employee
select * from jobs
select * from roysched