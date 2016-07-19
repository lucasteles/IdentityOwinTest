create table Client ( 	
	Id char(20) primary key,
	Secret varchar(512),
	Name varchar(100),
	ApplicationType int,
	Active bit,
	RefreshTokenLifeTime int,
	AllowedOrigin varchar(250)
)

insert into Client 
	(Id, Secret, Name, ApplicationType, Active, RefreshTokenLifeTime, AllowedOrigin)
values
	('ngWebApp','IIqRbqNn4TzAv4wSDinj4bQFbRbfw/4rGj/i/wBgtf0=','Web App',1,1,7200,'*')


create table RefreshToken (
	Id char(128) primary key,
	Subject varchar(50),
	ClientId varchar(50),
	IssuedUtc datetime2,
	ExpiresUtc datetime2,
	ProtectedTicket varchar(500)
)
