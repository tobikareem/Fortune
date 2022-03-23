create table fort.Post
(
	Id				int not null identity,
	Title			varchar(50) not null,
	[Description]	varchar(200) not null,
	Content			text not null,
	UserId			string not null,
	CategoryId		int null,
	IsPublished		bit,
	[Enabled] bit not null default 1, 
	CreatedBy varchar(55) null,
	CreatedOn datetime2 not null default getutcdate(),
	ModifiedBy varchar(55) null,
	ModifiedOn datetime2 null,
	IsReviewPost bit not null default 0,

	constraint PK_Post primary key(Id),
	constraint FK_Post_User_Id foreign key(UserId) references fort.[User](Id),
	constraint FK_Post_Category_Id foreign key(CategoryId) references fort.Category(Id),

);
go

create nonclustered index idx_nc_post_title on fort.Post(Title);
go
