


--在服务器上要再建一个定时任务，每天晚上0点以后，中间统计源任务后面1小时执行。
--这个新任务是删除会员同步表中已经同步完了的记录。

--任务里面只需要一条语句就行：
delete from tbAssociatorSync where iUpdateCount>=(select sum(cast(isnull(vcCommName,0) as bigint)) from tbCommCode where vcCommSign='SYNCN')