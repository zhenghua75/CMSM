


--�ڷ�������Ҫ�ٽ�һ����ʱ����ÿ������0���Ժ��м�ͳ��Դ�������1Сʱִ�С�
--�����������ɾ����Աͬ�������Ѿ�ͬ�����˵ļ�¼��

--��������ֻ��Ҫһ�������У�
delete from tbAssociatorSync where iUpdateCount>=(select sum(cast(isnull(vcCommName,0) as bigint)) from tbCommCode where vcCommSign='SYNCN')