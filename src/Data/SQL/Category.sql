create table fort.Category
(
	Id				int not null identity,
	Category		varchar(50) not null,
	[Description]	varchar(200) not null,
	[Enabled] bit not null default 1, 
	CreatedBy varchar(55) null,
	CreatedOn datetime2 not null default getutcdate(),
	ModifiedBy varchar(55) null,
	ModifiedOn datetime2 null,

	constraint PK_Category primary key(Id),
);
go

create nonclustered index idx_nc_category on fort.Category(Category);
go