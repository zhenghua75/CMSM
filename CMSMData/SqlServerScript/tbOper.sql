if not exists (select * from syscolumns where name='IsDiscount' and id=OBJECT_ID(N'[dbo].[tbOper]'))
begin
alter table dbo.tbOper add IsDiscount bit null
end