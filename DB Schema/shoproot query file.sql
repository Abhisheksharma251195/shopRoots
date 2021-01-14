create database shoproots1
Go
use shoproots1
Go
----------------------------------
--CREATE MASTER KEY ENCRYPTION BY   
--PASSWORD = 'shoproot@freelancer';
--Go
--CREATE CERTIFICATE shoproots  
--   WITH SUBJECT = 'Password_Encrypted';  
--GO  

--CREATE SYMMETRIC KEY Password_Key  
--    WITH ALGORITHM = AES_256  
--    ENCRYPTION BY CERTIFICATE shoproots;  
--GO 
----------------------------------------------------------

--drop table Address
--go
--drop table Users
create table Logs(Id int  IDENTITY(1,1)  PRIMARY KEY,  Name varchar(20) ,
CreatedOn datetime default  Current_TimeStamp, message varchar(Max)
) 
Go

create table Users(Id int  IDENTITY(1,1) CONSTRAINT pk_UserId  PRIMARY KEY,  Name varchar(20), DOB date null, Email varchar(40) unique not null, 
Phone varchar(10)  unique not null, UserPassword varbinary(160), 
CreatedOn datetime default  Current_TimeStamp, UpdatedOn datetime default  Current_TimeStamp , Deleted int default 0, CreatedBy varchar(50) default 'Unknown', 
) 
Go

create table Address(Id int  IDENTITY(1,1) CONSTRAINT pk_AddressId PRIMARY KEY, AddressLine1 varchar(30), City varchar(30), District varchar(30), State varchar(20), 
PinCode int, CreatedOn datetime default  Current_TimeStamp, UpdatedOn datetime default  Current_TimeStamp, Deleted int default 0, CreatedBy varchar (20) default 'Unknown', UserId int CONSTRAINT fk_UserId foreign key references Users(Id))
Go

--alter table Users 

--delete from Users
insert into Users(Name ,  Email ,Phone ) values ('pru' , 'pruTest@gahjhmil.com' ,  7899873261 )
go
insert into Address(AddressLine1 ,  City ,State ,UserId) values ('jwalaji' , 'jwalaji' ,  'kangra' , 1)
go

insert into Users(Name ,  Email ,Phone ) values ('Abhishek sharma' , 'abhisheksharma251195@gmail.com' ,  7833873211 )
go
insert into Address(AddressLine1 ,  City ,District ,UserId) values ('vpo khabli teh Dehra' , 'dehra' ,  'kangra' , 2)
go

insert into Users(Name ,  Email ,Phone ) values ('Ankush sharma' , 'ankush123@gmail.com' ,  8894454138 )
go
insert into Address(AddressLine1 ,  City ,District ,  State ,UserId) values ('vpo khabli teh Dehra' , 'dehra' ,  'kangra'  , 'Himachal Pradesh', 8)
go


select * from Users

select * from Address

--select u.Name ,  u.Email , a.AddressLine1 , a.City from Users as u  inner join Address as a  on u.UserAddress =  a.ID
--------------------------------------------
--UPDATE Users 
--SET Password_Encrypted = EncryptByKey(Key_GUID('Password_Key')  
--    , user_password);  
--GO
------------------------------------------------------------------------
--OPEN SYMMETRIC KEY Password_Key  
--   DECRYPTION BY CERTIFICATE shoproots;  
--GO 
--------------------------------------------------------------------------
--insert into users(Name,Email,Phone, user_password) values('Abhishek', 'abhi123@gmail.com', 7833873211, 'password')

--select * from users
--Go
------------------------------------------------


--use authentication table, userid fk,  id, access token string, delete, common columns, 