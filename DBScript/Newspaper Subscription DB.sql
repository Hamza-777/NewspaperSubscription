create database NewsSubDB

use NewsSubDB

create table Admin (
	username varchar(15) not null primary key,
	password varchar(50) not null
)

insert into Admin values ('Admin', 'Admin')

create table Cities (
	cityid int identity(0, 1) not null primary key,
	cityname varchar(30) not null,
	citystate varchar(30) not null
)

create table Vendors (
	vendorid int identity(234, 3) not null primary key,
	vendorname varchar(50) not null,
	vendorcity int foreign key references Cities(cityid)
)

create table VendorCredentials (
	username varchar(20) not null primary key,
	password varchar(30) not null,
	vendor int foreign key references Vendors(vendorid)
)

create table NewsPapers (
	newspaperid int identity(332, 7) not null primary key,
	newspapername varchar(50) not null,
	newspaperprice real not null,
	weeklysubscription real not null,
	monthlysubscription real not null,
	yearlysubscription real not null,
	newspaperlanguage varchar(20) not null
)

create table Customers (
	customerid int identity(0, 1) not null primary key,
	customername varchar(50) not null,
	customeraddress varchar(50) not null,
	customercity int foreign key references Cities(cityid)
)

create table CustomerCredentials (
	username varchar(20) not null primary key,
	password varchar(30) not null,
	customer int foreign key references Customers(customerid)
)

create table Subscriptions (
	subscriptionid int identity(53, 3) not null primary key,
	subscriptiontype varchar(10) not null,
	subscriptionstartdate date not null,
	customer int foreign key references Customers(customerid),
	newspaper int foreign key references NewsPapers(newspaperid),
	vendor int foreign key references Vendors(vendorid)
)

select * from Admin