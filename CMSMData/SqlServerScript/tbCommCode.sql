if exists (select * from syscolumns where name='vcCommSign' and id=OBJECT_ID(N'[dbo].[tbCommCode]') and length=5)
begin
alter table dbo.tbCommCode alter column vcCommSign varchar(20) not null
end