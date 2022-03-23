create table fort.UserPost
(
	Id			int not null identity,
	PostId		int not null,
	UserId		string not null,

	constraint PK_User primary key(Id),
	constraint FK_UserPost_User foreign key(UserId) references fort.[User](Id),
	constraint FK_UserPost_Post foreign key(PostId) references fort.Post(Id),

);
go
