create database shoproots12
Go
use shoproots12
Go


create table Logs(Id int  IDENTITY(1,1)  PRIMARY KEY ,
CreatedOn datetime default  Current_TimeStamp, message varchar(Max) , CreatedBy varchar(50)  default 'Unknown',Deleted int default 0,
UpdatedOn datetime  default  Current_TimeStamp ,
) 
Go

create table Users(Id int  IDENTITY(1,1) CONSTRAINT pk_UserId  PRIMARY KEY,  Name varchar(20), DOB date null, Email varchar(40) unique not null, 
Phone varchar(10)  unique not null, UserPassword varbinary(160), UserId varchar(50) unique not null,
CreatedOn datetime default  Current_TimeStamp, UpdatedOn datetime  default  Current_TimeStamp , Deleted int default 0, CreatedBy varchar(50)  default 'Unknown', 
) 
Go


create table UserType (Id int  IDENTITY(1,1) CONSTRAINT pk_UserTypeId  PRIMARY KEY, userType varchar(20),
CreatedOn datetime default  Current_TimeStamp, UpdatedOn datetime default  Current_TimeStamp , Deleted int default 0
)
Go


insert into UserType (userType) values ('superAdmin')
insert into UserType (userType) values ('Admin')
insert into UserType (userType) values ('Delivery')
Go

ALTER TABLE Users
ADD UserType int CONSTRAINT fk_UserType foreign key references UserType(Id);
Go

create table Address(Id int  IDENTITY(1,1) CONSTRAINT pk_AddressId PRIMARY KEY, AddressLine1 varchar(30), City varchar(30), District varchar(30), State varchar(20), 
PinCode int, CreatedOn datetime  default  Current_TimeStamp, UpdatedOn datetime  default  Current_TimeStamp, Deleted int default 0, CreatedBy varchar (20) default 'Unknown',UserId int CONSTRAINT fk_UserId foreign key references Users(Id))
Go

create table authentication (Id int IDENTITY(1,1) CONSTRAINT pk_AuthId PRIMARY KEY ,  token NVARCHAR(500) unique not null , userId varchar(50) not null , CreatedOn datetime default  Current_TimeStamp, 
UpdatedOn datetime  default  Current_TimeStamp , ExpireOn datetime, Deleted int default 0, CreatedBy varchar(50)  default 'Unknown')

ALTER TABLE Address
ADD addressType varchar(50);
go
