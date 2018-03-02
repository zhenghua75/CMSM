SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO












ALTER                              procedure dbo.sp_CreateReportSouce


AS

declare @BeginDate varchar(8)
declare @EndDate varchar(8)

begin transaction

set @BeginDate=convert(char(8),DATEADD(day,-30,'2007-01-01'),112)
set @EndDate=convert(char(8),getdate(),112)


/****************************************************************************************************************************************
---------------------------------------------------------------��ʼ�����ֺ����-----------------------------------------------------------
****************************************************************************************************************************************/

delete from tbRepAssDailyIGCharge where vcDate between @BeginDate and @EndDate

--�г�ֵ�����Ѽ�¼
insert into tbRepAssDailyIGCharge select vcCardID,convert(char(8),dtFillDate,112) as vcDate,null,max(dtFillDate) as dtFillDate,0,0
from vwFillFee where vcCardID+convert(char(8),dtFillDate,112) not in(select vcCardID+vcDate from tbRepAssDailyIGCharge)
and convert(char(8),dtFillDate,112) between @BeginDate and @EndDate
group by vcCardID,convert(char(8),dtFillDate,112)

--û������ģ����л��ּ�¼
insert into tbRepAssDailyIGCharge select vcCardID,convert(char(8),dtIgDate,112) as vcDate,max(dtIgDate) as dtIgDate,null,
cast(0 as numeric(12,2)) as DailyIG,cast(0 as numeric(12,2)) as DailyCharge
from vwIntegralLog where vcCardID+convert(char(8),dtIgDate,112) not in(select vcCardID+vcDate from tbRepAssDailyIGCharge)
and convert(char(8),dtIgDate,112) between @BeginDate and @EndDate
group by vcCardID,convert(char(8),dtIgDate,112)

--����ÿ��Աÿ�����һ�εĻ���ʱ��
update tbRepAssDailyIGCharge set dtIgDate=b.dtIgDate from tbRepAssDailyIGCharge a,
(select vcCardID,convert(char(8),dtIgDate,112) as vcDate,max(dtIgDate) as dtIgDate from vwIntegralLog where convert(char(8),dtIgDate,112) between @BeginDate and @EndDate
	group by vcCardID,convert(char(8),dtIgDate,112)) b
where a.vcCardID=b.vcCardID and a.vcDate=b.vcDate and a.vcDate between @BeginDate and @EndDate

---------------------------���»��ֺ����------------------------
--update tbRepAssDailyIGCharge set DailyIG=0,DailyCharge=0
--���ݺ˲飬07��5��6��7��8�ĸ��µ����ݿ��ܻ��е㲻�ԣ�����Ϊ��ʱȡ��ʱ��û����������˻�����ظ���

update tbRepAssDailyIGCharge set DailyIG=b.iIgArrival from tbRepAssDailyIGCharge a,vwIntegralLog b
where a.vcCardID=b.vcCardID and a.dtIgDate=b.dtIgDate and a.vcDate between @BeginDate and @EndDate

update tbRepAssDailyIGCharge set DailyCharge=b.nFeeCur from tbRepAssDailyIGCharge a,vwFillFee b
where a.vcCardID=b.vcCardID and a.dtFillDate=b.dtFillDate and a.vcDate between @BeginDate and @EndDate

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************ÿһ����ŵ����������ʧ����Һ;��������*********************************************
*********************************************************************************************************************************/

delete from tbRepAssCount where vcDate between @BeginDate and @EndDate

--����������
insert into tbRepAssCount 
select vcDeptID,convert(char(8),dtCreateDate,112) as vcDate,count(*) as NewAss,0,0,0,0,0 from tbAssociator 
where convert(char(8),dtCreateDate,112) between @BeginDate and @EndDate
group by vcDeptID,convert(char(8),dtCreateDate,112)

--�����ŵ꣬���ڣ������������в������Ĺ�ʧ��
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,count(*) as LoseAss,0,0,0,0 from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP004' 
	and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
    and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)

--�����ŵ꣬���ڣ������������͹�ʧ���в������Ľ����---��ʱû��--����
/*
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,0,count(*) as RelaseLoseAss,0 from tbBusiLogOther a,tbAssociator b
where a.vcOperType='OP009' and a.vcComments='' and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
 and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)
*/

--�����ŵ꣬���ڣ������������в������Ļ��տ�
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,0,0,count(*) as CardCycle,0,0 from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP011' 
	and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
	and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)

--�����ŵ꣬���ڣ������������в������Ĳ���
insert into tbRepAssCount
select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,0,0,0,0,0,count(*) as CardAgain from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP005' 
	and b.vcDeptID+convert(char(8),a.dtOperDate,112) not in(select vcDeptID+vcDate from tbRepAssCount) and a.vcCardID=b.vcCardID
	and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate
group by b.vcDeptID,convert(char(8),a.dtOperDate,112)

--���¹�ʧ��
update tbRepAssCount set LoseAss=d.LoseAss from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as LoseAss
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP004' and a.vcCardID=b.vcCardID 
		and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate and c.vcDate between @BeginDate and @EndDate

--���½����---��ʱû��--����
/*
update tbRepAssCount set RelaseLoseAss=d.RelaseLoseAss from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as RelaseLoseAss
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP009' and a.vcComments='' and a.vcCardID=b.vcCardID 
		and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate and c.vcDate between @BeginDate and @EndDate
*/

--���»��տ���
update tbRepAssCount set CardCycle=d.CardCycle from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as CardCycle
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP011' and a.vcCardID=b.vcCardID 
		and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate and c.vcDate between @BeginDate and @EndDate

--���²�����
update tbRepAssCount set CardAgain=d.CardAgain from tbRepAssCount c,(select b.vcDeptID,convert(char(8),a.dtOperDate,112) as vcDate,count(*) as CardAgain
		from tbBusiLogOther a,tbAssociator b where a.vcOperType='OP005' and a.vcCardID=b.vcCardID 
		and convert(char(8),a.dtOperDate,112) between @BeginDate and @EndDate group by b.vcDeptID,convert(char(8),a.dtOperDate,112)) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate and c.vcDate between @BeginDate and @EndDate

--���¾�����
update tbRepAssCount set OnlyAss=NewAss-(LoseAss-RelaseLoseAss) where vcDate between @BeginDate and @EndDate


if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************ÿһ����ŵ�Ļ�Ա���ѣ�������Ա���ѣ����������ѣ�����*****************************************
*********************************************************************************************************************************/

delete from tbRepAssConsDaily where vcDate between @BeginDate and @EndDate

insert into tbRepAssConsDaily
select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,c.vcAssType,count(distinct a.vcCardID) as AssCount,sum(b.nFee),0,
count(distinct a.iSerial) as ConsTimes,sum(b.iCount) as GoodsCount,c.vcDeptID as vcAssBelongDept
from vwBill a,vwConsItem b,tbAssociator c where a.vcConsType in('PT001','PT002') and b.cFlag='0' and a.iSerial=b.iSerial and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID
and convert(char(8),a.dtConsDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcAssType,c.vcDeptID
order by convert(char(8),a.dtConsDate,112)

update tbRepAssConsDaily set iIgValue=d.iIgValue from tbRepAssConsDaily b,
(select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,c.vcAssType,sum(a.iIgValue) as iIgValue,c.vcDeptID as vcAssBelongDept
from vwBill a,tbAssociator c where a.vcConsType in('PT001','PT002') and a.vcCardID=c.vcCardID and a.iSerial not in(select distinct iSerial from vwConsItem where cFlag='9')
and convert(char(8),a.dtConsDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcAssType,c.vcDeptID) d
where b.vcDeptID=d.vcDeptID and b.vcDate=d.vcDate and b.vcAssType=d.vcAssType and b.vcAssBelongDept=d.vcAssBelongDept and b.vcDate between @BeginDate and @EndDate

---------���п�����----------------
insert into tbRepAssConsDaily
select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,'Bank',count(distinct a.vcCardID) as AssCount,sum(b.nFee),0,
count(distinct a.iSerial) as ConsTimes,sum(b.iCount) as GoodsCount,c.vcDeptID as vcAssBelongDept
from vwBill a,vwConsItem b,tbAssociator c where a.vcConsType in('PT005') and b.cFlag='0' and a.iSerial=b.iSerial and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID
and convert(char(8),a.dtConsDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcDeptID
order by convert(char(8),a.dtConsDate,112)

update tbRepAssConsDaily set iIgValue=d.iIgValue from tbRepAssConsDaily b,
(select a.vcDeptID,convert(char(8),a.dtConsDate,112) as vcDate,'Bank' as vcAssType,sum(a.iIgValue) as iIgValue,c.vcDeptID as vcAssBelongDept
from vwBill a,tbAssociator c where a.vcConsType in('PT005') and a.vcCardID=c.vcCardID and a.iSerial not in(select distinct iSerial from vwConsItem where cFlag='9')
and convert(char(8),a.dtConsDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),a.dtConsDate,112),c.vcDeptID) d
where b.vcDeptID=d.vcDeptID and b.vcDate=d.vcDate and b.vcAssType=d.vcAssType and b.vcAssBelongDept=d.vcAssBelongDept and b.vcDate between @BeginDate and @EndDate

/*********************************************************************************************************************************
*********************************************ÿһ����ŵ�Ļ�Ա�������************************************************************
*********************************************************************************************************************************/
--���ֶһ�ֻ�ܣ��һ���Ա����ʹ�û��֣��һ���������Ʒ��
--��tbRepAssConsDaily��Ӧʹ���ֶ�Ϊ��AssCount,iIgValue,ConsTimes,GoodsCount

insert into tbRepAssConsDaily
select a.vcDeptID,convert(char(8),a.dtIgDate,112),'IgChange',isnull(count(distinct a.vcCardID),0),0,isnull(sum(-a.iIgGet),0),isnull(count(*),0),0,b.vcDeptID
from vwIntegralLog a,tbAssociator b where a.vcIgType in('IGT02','IGT05') and a.vcCardID=b.vcCardID and convert(char(8),a.dtIgDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),dtIgDate,112),b.vcDeptID

update tbRepAssConsDaily set GoodsCount=d.GoodsCount from tbRepAssConsDaily c,
(select a.vcDeptID,convert(char(8),b.dtIgDate,112) as vcDate,'IgChange' as vcAssType,isnull(sum(iCount),0) as GoodsCount,c.vcDeptID as vcAssBelongDept
from vwConsItem a,vwIntegralLog b,tbAssociator c
where b.vcIgType in('IGT02','IGT05') and a.vcDeptID=b.vcDeptID and a.iSerial=b.iLinkCons and b.vcCardID=c.vcCardID and convert(char(8),b.dtIgDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),b.dtIgDate,112),c.vcDeptID) d
where c.vcDeptID=d.vcDeptID and c.vcDate=d.vcDate and c.vcAssType=d.vcAssType and c.vcAssBelongDept=d.vcAssBelongDept and c.vcDate between @BeginDate and @EndDate

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************ÿһ����ŵ�ĳ�ֵ���****************************************************************
*********************************************************************************************************************************/

delete from tbRepAssFill where vcDate between @BeginDate and @EndDate

insert into tbRepAssFill
select '�ֽ��ֵ',a.vcDeptID,convert(char(8),a.dtFillDate,112) as vcDate,isnull(count(distinct a.vcCardID),0) as AssCount,isnull(sum(a.nFillFee),0) as FillFee,
isnull(sum(a.nFillProm),0) as PromFee,isnull(count(*),0) as FillCount,b.vcDeptID as vcAssBelongDept
from vwFillFee a,tbAssociator b where a.vcComments not like '%����%' and a.vcComments not like '%����ֵ%' and a.vcComments not like '%�ϲ�%' and a.vcComments<>'���п�'
and a.vcComments not like '%���ѳ���%' and a.vcComments not like '%��ֵ����%' and a.vcComments not like '���տ�%' and a.nFillFee>0 and a.vcCardID=b.vcCardID 
and convert(char(8),dtFillDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),dtFillDate,112),b.vcDeptID

insert into tbRepAssFill
select '���п���ֵ',a.vcDeptID,convert(char(8),a.dtFillDate,112) as vcDate,isnull(count(distinct a.vcCardID),0) as AssCount,isnull(sum(a.nFillFee),0) as FillFee,
isnull(sum(a.nFillProm),0) as PromFee,isnull(count(*),0) as FillCount,b.vcDeptID as vcAssBelongDept
from vwFillFee a,tbAssociator b where a.vcComments='���п�' and a.nFillFee>0 and a.vcCardID=b.vcCardID 
and convert(char(8),dtFillDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),dtFillDate,112),b.vcDeptID

insert into tbRepAssFill
select '���տ�',a.vcDeptID,convert(char(8),a.dtFillDate,112) as vcDate,isnull(count(distinct a.vcCardID),0) as AssCount,isnull(sum(a.nFillFee),0) as FillFee,
isnull(sum(a.nFillProm),0) as PromFee,isnull(count(*),0) as FillCount,b.vcDeptID as vcAssBelongDept
from vwFillFee a,tbAssociator b where a.vcComments like '���տ�%' and a.nFillFee>0 and a.vcCardID=b.vcCardID 
and convert(char(8),dtFillDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),dtFillDate,112),b.vcDeptID

if(@@Error<>0)	goto LError


/*********************************************************************************************************************************
*********************************************ÿһ����ŵ�Ļ�Ա�������************************************************************
*********************************************************************************************************************************/

delete from tbRepAssLarg where vcDate between @BeginDate and @EndDate

insert into tbRepAssLarg
select a.vcDeptID,convert(char(8),b.dtConsDate,112) as vcDate,isnull(count(distinct a.iSerial),0) as LargTimes,isnull(sum(a.iCount),0) as GoodsCount,c.vcDeptID
from vwConsItem a,vwBill b,tbAssociator c
where vcConsType='PT004' and a.iSerial=b.iSerial and a.vcCardID=b.vcCardID and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID
and convert(char(8),b.dtConsDate,112) between @BeginDate and @EndDate
group by a.vcDeptID,convert(char(8),b.dtConsDate,112),c.vcDeptID




commit tran


LError:
     if(@@TranCount>0)
         begin
	    rollback transaction
                 print'�ع�'
         end











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

