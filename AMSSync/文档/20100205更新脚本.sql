


delete from tbCommCode where vcCommSign='GT' and vcCommName='月饼类'
insert into tbCommCode values('月饼类','10-16','GT','商品类型')

ALTER TABLE tbGoods ADD vcGoodsType VARCHAR(20) NULL

update tbGoods set vcGoodsType='10-16' where substring(vcGoodsID,1,2) in('10','11','12','13','14','15','16')
update tbGoods set vcGoodsType='20-26' where substring(vcGoodsID,1,2) in('20','21','22','23','24','25','26')
update tbGoods set vcGoodsType='27-27' where substring(vcGoodsID,1,2) in('27')
update tbGoods set vcGoodsType='28-28' where substring(vcGoodsID,1,2) in('28')
update tbGoods set vcGoodsType='29-29' where substring(vcGoodsID,1,2) in('29')
update tbGoods set vcGoodsType='30-32' where substring(vcGoodsID,1,2) in('30','31','32')
update tbGoods set vcGoodsType='33-39' where substring(vcGoodsID,1,2) in('33','34','35','36','37','38','39')
update tbGoods set vcGoodsType='40-44' where substring(vcGoodsID,1,2) in('40','41','42','43','44')
update tbGoods set vcGoodsType='45-45' where substring(vcGoodsID,1,2) in('45')
update tbGoods set vcGoodsType='50-59' where substring(vcGoodsID,1,2) in('50','51','52','53','54','55','56','57','58','59')
update tbGoods set vcGoodsType='60-69' where substring(vcGoodsID,1,2) in('60','61','62','63','64','65','66','67','68','69')
update tbGoods set vcGoodsType='70-79' where substring(vcGoodsID,1,2) in('70','71','72','73','74','75','76','77','78','79')
update tbGoods set vcGoodsType='80-99' where substring(vcGoodsID,1,2) in('80','81','82','83','84','85','86','87','88','89')

---如果没加过，要加一下，中心和客户端都要加
--insert into tbCommCode values('2','MDCN1','SYNCN','门店同步标识')