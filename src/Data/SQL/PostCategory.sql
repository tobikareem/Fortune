create table fort.PostCategory
(
	Id				int not null identity,
	PostId			int not null,
	CategoryId		int not null

	constraint PK_PostCategory primary key(Id),
	constraint FK_PostCategory_Category foreign key(CategoryId) references fort.Category(Id),
	constraint FK_PostCategory_Post foreign key(PostId) references fort.Post(Id),

);
go