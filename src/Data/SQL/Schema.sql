use master; 

if db_id(N'FortuneDb') is not null drop database FortuneDb;
go

create database FortuneDb;
go

use FortuneDb;
go

create schema fort;
go

-- dotnet ef migrations add InitialSchema -o Migrations -c FortuneDbContext
-- dotnet ef database update