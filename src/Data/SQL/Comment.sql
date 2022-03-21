create table fort.Comment
(
	Id			int not null identity,
	PostId		int not null,
	Content		text not null,
	[Enabled] bit not null default 1, 
	CreatedBy varchar(55) null,
	CreatedOn datetime2 not null default getutcdate(),
	ModifiedBy varchar(55) null,
	ModifiedOn datetime2 null,

	constraint PK_Comment primary key(Id),
	constraint FK_CommentPost foreign key(PostId) references fort.Post(Id),

);
go

create nonclustered index idx_nc_comment_postid_content on fort.Comment(PostId, Content);
go