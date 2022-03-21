create table fort.[User] 
(
	Id			int not null identity,
	FirstName   varchar(50) not null,
	LastName	varchar(50) not null,
	DisplayName varchar(50) not null,
	Email		varchar(50) not null,
	Identifier  varchar(50) not null,
	Phone		nvarchar(50) null,
	[Enabled] bit not null default 1, 
	CreatedBy varchar(55) null,
	CreatedOn datetime2 not null default getutcdate(),
	ModifiedBy varchar(55) null,
	ModifiedOn datetime2 null,

	constraint PK_User primary key(Id),
);
go

create nonclustered index idx_nc_displayname on fort.[User](DisplayName);
go