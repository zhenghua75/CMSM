SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

















create                                  procedure dbo.sp_tmp1th


AS


begin transaction



/****************************************************************************************************************************************
---------------------------------------------------------------初始化积分和余额-----------------------------------------------------------
****************************************************************************************************************************************/

delete from tbRepAssDailyIGCharge

--有充值或消费记录
insert into tbRepAssDailyIGCharge select vcCardID,convert(char(8),dtFillDate,112) as vcDate,null,max(dtFillDate) as dtFillDate,0,0
from vwFillFee where vcCardID+convert(char(8),dtFillDate,112) not in(select vcCardID+vcDate from tbRepAssDailyIGCharge)
group by vcCardID,convert(char(8),dtFillDate,112)

--没有上面的，但有积分记录
insert into tbRepAssDailyIGCharge select vcCardID,convert(char(8),dtIgDate,112) as vcDate,max(dtIgDate) as dtIgDate,null,
cast(0 as numeric(12,2)) as DailyIG,cast(0 as numeric(12,2)) as DailyCharge
from vwIntegralLog where vcCardID+convert(char(8),dtIgDate,112) not in(select vcCardID+vcDate from tbRepAssDailyIGCharge)
group by vcCardID,convert(char(8),dtIgDate,112)

--更新每会员每天最后一次的积分时间
update tbRepAssDailyIGCharge set dtIgDate=b.dtIgDate from tbRepAssDailyIGCharge a,
(select vcCardID,convert(char(8),dtIgDate,112) as vcDate,max(dtIgDate) as dtIgDate from vwIntegralLog
	group by vcCardID,convert(char(8),dtIgDate,112)) b
where a.vcCardID=b.vcCardID and a.vcDate=b.vcDate

---------------------------更新积分和余额------------------------
--update tbRepAssDailyIGCharge set DailyIG=0,DailyCharge=0
--根据核查，07年5，6，7，8四个月的数据可能会有点不对，是因为当时取的时间没有秒数，因此会产生重复。

update tbRepAssDailyIGCharge set DailyIG=b.iIgArrival from tbRepAssDailyIGCharge a,vwIntegralLog b
where a.vcCardID=b.vcCardID and a.dtIgDate=b.dtIgDate 

update tbRepAssDailyIGCharge set DailyCharge=b.nFeeCur from tbRepAssDailyIGCharge a,vwFillFee b
where a.vcCardID=b.vcCardID and a.dtFillDate=b.dtFillDate

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************每一天的门店的新增，挂失，解挂和净增量情况*********************************************
*********************************************************************************************************************************/

delete from tbRepAssCount

--插入新增数
insert into tbRepAssCount 
select vcDeptID,convert(char(8),dtCreateDate,112) as vcDate,count(*) as NewAss,0,0,0,0,0 from tbAssociator 
group by vcDeptID,convert(char(8),dtCreateDate,112)

--根据门店，日期，插入新增数中不包含的挂失数
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,count(*) as LoseAss,0,0,0,0 from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP004' 
	and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)

--根据门店，日期，插入新增数和挂失数中不包含的解挂数---暂时没有--保留
/*
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,0,count(*) as RelaseLoseAss,0 from tbBusiLogOther a,tbAssociator b
where a.vcOperType='OP009' and a.vcComments='' and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)
*/

--根据门店，日期，插入新增数中不包含的回收卡
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,0,0,count(*) as CardCycle,0,0 from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP011' 
	and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)

--根据门店，日期，插入新增数中不包含的补卡
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,0,0,0,0,count(*) as CardAgain from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP005' 
	and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)

--更新挂失数
update tbRepAssCount set LoseAss=d.LoseAss from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as LoseAss
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP004' and a.vcCardID=b.vcCardID 
		group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate

--更新解挂数---暂时没有--保留
/*
update tbRepAssCount set RelaseLoseAss=d.RelaseLoseAss from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as RelaseLoseAss
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP009' and a.vcComments='' and a.vcCardID=b.vcCardID 
		group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate
*/

--更新回收卡数
update tbRepAssCount set CardCycle=d.CardCycle from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as CardCycle
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP011' and a.vcCardID=b.vcCardID 
		group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate

--更新补卡数
update tbRepAssCount set CardAgain=d.CardAgain from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as CardAgain
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP005' and a.vcCardID=b.vcCardID 
		group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate

--更新净增数
update tbRepAssCount set OnlyAss=NewAss-(LoseAss-RelaseLoseAss)-CardCycle

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************每一天的门店的会员消费，赠卡会员消费，金银卡消费，零售*****************************************
*********************************************************************************************************************************/

delete from tbRepAssConsDaily 

insert into tbRepAssConsDaily
select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,c.vcAssType,count(distinct a.vcCardID) as AssCount,sum(b.nFee),0,
count(distinct a.iSerial) as ConsTimes,sum(b.iCount) as GoodsCount,c.vcDeptID as vcAssBelongDept
from vwBill a,vwConsItem b,tbAssociator c where a.vcConsType in('PT001','PT002') and b.cFlag='0' and a.iSerial=b.iSerial and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcAssType,c.vcDeptID
order by convert(char(8),a.dtConsDate,112)

update tbRepAssConsDaily set iIgValue=d.iIgValue from tbRepAssConsDaily b,
(select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,c.vcAssType,sum(a.iIgValue) as iIgValue,c.vcDeptID as vcAssBelongDept
from vwBill a,tbAssociator c where a.vcConsType in('PT001','PT002') and a.vcCardID=c.vcCardID and a.iSerial not in(select distinct iSerial from vwConsItem where cFlag='9')
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcAssType,c.vcDeptID) d
where b.vcDeptID=d.vcDeptID and b.vcDate=d.vcDate and b.vcAssType=d.vcAssType and b.vcAssBelongDept=d.vcAssBelongDept

---------银行卡零售----------------
insert into tbRepAssConsDaily
select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,'Bank',count(distinct a.vcCardID) as AssCount,sum(b.nFee),0,
count(distinct a.iSerial) as ConsTimes,sum(b.iCount) as GoodsCount,c.vcDeptID as vcAssBelongDept
from vwBill a,vwConsItem b,tbAssociator c where a.vcConsType in('PT005') and b.cFlag='0' and a.iSerial=b.iSerial and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcDeptID
order by convert(char(8),a.dtConsDate,112)

update tbRepAssConsDaily set iIgValue=d.iIgValue from tbRepAssConsDaily b,
(select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,'Bank' as vcAssType,sum(a.iIgValue) as iIgValue,c.vcDeptID as vcAssBelongDept
from vwBill a,tbAssociator c where a.vcConsType in('PT005') and a.vcCardID=c.vcCardID and a.iSerial not in(select distinct iSerial from vwConsItem where cFlag='9')
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcDeptID) d
where b.vcDeptID=d.vcDeptID and b.vcDate=d.vcDate and b.vcAssType=d.vcAssType and b.vcAssBelongDept=d.vcAssBelongDept

/*********************************************************************************************************************************
*********************************************每一天的门店的会员积分情况************************************************************
*********************************************************************************************************************************/
--积分兑换只管：兑换会员数，使用积分，兑换次数，商品数
--与tbRepAssConsDaily对应使用字段为：AssCount,iIgValue,ConsTimes,GoodsCount

insert into tbRepAssConsDaily
select a.vcDeptID,convert(char(8),a.dtIgDate,112),'IgChange',isnull(count(distinct a.vcCardID),0),0,isnull(sum(-a.iIgGet),0),isnull(count(*),0),0,b.vcDeptID
from vwIntegralLog a,tbAssociator b where a.vcIgType in('IGT02','IGT05') and a.vcCardID=b.vcCardID
group by a.vcDeptID,convert(char(8),dtIgDate,112),b.vcDeptID

update tbRepAssConsDaily set GoodsCount=d.GoodsCount from tbRepAssConsDaily c,
(select a.vcDeptID,convert(char(8),b.dtIgDate,112) as vcDate,'IgChange' as vcAssType,isnull(sum(iCount),0) as GoodsCount,c.vcDeptID as vcAssBelongDept
from vwConsItem a,vwIntegralLog b,tbAssociator c
where b.vcIgType in('IGT02','IGT05') and a.vcDeptID=b.vcDeptID and a.iSerial=b.iLinkCons and b.vcCardID=c.vcCardID
group by a.vcDeptID,convert(char(8),b.dtIgDate,112),c.vcDeptID) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate and c.vcAssType=d.vcAssType and c.vcAssBelongDept=d.vcAssBelongDept

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************每一天的门店的充值情况****************************************************************
*********************************************************************************************************************************/

delete from tbRepAssFill

insert into tbRepAssFill
select '现金充值',a.vcDeptID,convert(char(8),a.dtFillDate,112) as vcDate,isnull(count(distinct a.vcCardID),0) as AssCount,isnull(sum(a.nFillFee),0) as FillFee,
isnull(sum(a.nFillProm),0) as PromFee,isnull(count(*),0) as FillCount,b.vcDeptID as vcAssBelongDept
from vwFillFee a,tbAssociator b where a.vcComments not like '%补卡%' and a.vcComments not like '%补充值%' and a.vcComments not like '%合并%' and a.vcComments<>'银行卡'
and a.vcComments not like '%消费撤消%' and a.vcComments not like '%充值撤消%' and a.vcComments not like '回收卡%' and a.nFillFee>0 and a.vcCardID=b.vcCardID 
group by a.vcDeptID,convert(char(8),dtFillDate,112),b.vcDeptID

insert into tbRepAssFill
select '银行卡充值',a.vcDeptID,convert(char(8),a.dtFillDate,112) as vcDate,isnull(count(distinct a.vcCardID),0) as AssCount,isnull(sum(a.nFillFee),0) as FillFee,
isnull(sum(a.nFillProm),0) as PromFee,isnull(count(*),0) as FillCount,b.vcDeptID as vcAssBelongDept
from vwFillFee a,tbAssociator b where a.vcComments='银行卡' and a.nFillFee>0 and a.vcCardID=b.vcCardID 
group by a.vcDeptID,convert(char(8),dtFillDate,112),b.vcDeptID

insert into tbRepAssFill
select '回收卡',a.vcDeptID,convert(char(8),a.dtFillDate,112) as vcDate,isnull(count(distinct a.vcCardID),0) as AssCount,isnull(sum(a.nFillFee),0) as FillFee,
isnull(sum(a.nFillProm),0) as PromFee,isnull(count(*),0) as FillCount,b.vcDeptID as vcAssBelongDept
from vwFillFee a,tbAssociator b where a.vcComments like '回收卡%' and a.nFillFee>0 and a.vcCardID=b.vcCardID 
group by a.vcDeptID,convert(char(8),dtFillDate,112),b.vcDeptID

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************每一天的门店的会员赠送情况************************************************************
*********************************************************************************************************************************/

delete from tbRepAssLarg

insert into tbRepAssLarg
select a.vcDeptID,convert(char(8),b.dtConsDate,112) as vcDate,isnull(count(distinct a.iSerial),0) as LargTimes,isnull(sum(a.iCount),0) as GoodsCount,c.vcDeptID
from vwConsItem a,vwBill b,tbAssociator c
where vcConsType='PT004' and a.iSerial=b.iSerial and a.vcCardID=b.vcCardID and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID
group by a.vcDeptID,convert(char(8),b.dtConsDate,112),c.vcDeptID




if(@@Error<>0)	goto LError


commit tran


LError:
     if(@@TranCount>0)
         begin
	    rollback transaction
                 print'回滚'
         end
















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

