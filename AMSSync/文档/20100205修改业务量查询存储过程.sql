SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




















ALTER                                     procedure dbo.sp_BusiIncomeReport
(
   @DeptID varchar(5),
   @QueryBeginDate varchar(8),
   @QueryEndDate varchar(8),
   @YestodayDate varchar(8)
)
AS

declare @StrDate varchar(16)
declare @CreateDate datetime

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tbBusiIncomeReport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [tbBusiIncomeReport] (
	[vcDateZoom] [varchar] (16) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[vcDeptID] [varchar] (10) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Type] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[REP1] [int] NOT NULL ,
	[REP2] [int] NOT NULL ,
	[REP3] [numeric](12, 2) NOT NULL ,
	[REP4] [numeric](12, 2) NOT NULL ,
	[REP5] [numeric](12, 2) NOT NULL ,
	[REP6] [numeric](12, 2) NOT NULL ,
	[REP7] [int] NOT NULL ,
	[ReNo] [int] NULL ,
	[dtCreateDate] [datetime] NULL ,
	CONSTRAINT [PK_tbBusiIncomeReport] PRIMARY KEY  CLUSTERED 
	(
		[vcDateZoom],
		[vcDeptID],
		[Type]
	)  ON [PRIMARY] 
) ON [PRIMARY]


begin transaction

set @StrDate=@QueryBeginDate+@QueryEndDate
set @CreateDate=getdate()
delete from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID like @DeptID
delete from tbBusiIncomeReport where convert(char(8),dtCreateDate,112)<convert(char(8),DATEADD(month,-1,getdate()),112) and vcDeptID like @DeptID
if(@@Error<>0)	goto LError

--ԭ״̬(���ֺ������ŵ꣬�����ǲ�ѯ�ŵ��ȫ����ֻ��ʾȫ�������)
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'OldState',0,isnull(sum(DailyIG),0),0,isnull(sum(DailyCharge),0),0,0,0,1,@CreateDate from tbRepAssDailyIGCharge a,
(select vcCardID,max(vcDate) as maxdate from tbRepAssDailyIGCharge where vcDate<=@YestodayDate group by vcCardID) b
where a.vcCardID=b.vcCardID and a.vcDate=b.maxdate

update tbBusiIncomeReport set REP1=(select isnull(sum(OnlyAss),0) from tbRepAssCount where vcDeptID like @DeptID and vcDate<=@YestodayDate) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='OldState'

if(@@Error<>0)	goto LError

--print 'ԭ״̬ok'

--��״̬(���ֺ������ŵ꣬�����ǲ�ѯ�ŵ��ȫ����ֻ��ʾȫ�������)
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'NewState',0,isnull(sum(DailyIG),0),0,isnull(sum(DailyCharge),0),0,0,0,2,@CreateDate from tbRepAssDailyIGCharge a,
(select vcCardID,max(vcDate) as maxdate from tbRepAssDailyIGCharge where vcDate<=@QueryEndDate group by vcCardID) b
where a.vcCardID=b.vcCardID and a.vcDate=b.maxdate

update tbBusiIncomeReport set REP1=(select isnull(sum(OnlyAss),0) from tbRepAssCount where vcDeptID like @DeptID and vcDate<=@QueryEndDate) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='NewState'

if(@@Error<>0)	goto LError

--print '��״̬ok'


--�����Ա(���ֺ������ŵ꣬�����ǲ�ѯ�ŵ��ȫ����ֻ��ʾȫ���������ָĳ����������Ա��ֹ��ĳһ��Ļ��ֺ����)
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'NewAss',0,isnull(sum(DailyIG),0),0,isnull(sum(DailyCharge),0),0,0,0,3,@CreateDate from tbRepAssDailyIGCharge a,
(select vcCardID,max(vcDate) as maxdate from tbRepAssDailyIGCharge where vcDate<=@QueryEndDate and vcCardID in(
	select distinct vcCardID from tbAssociator where convert(char(8),dtCreateDate,112) between @QueryBeginDate and @QueryEndDate)
	group by vcCardID) b
where a.vcCardID=b.vcCardID and a.vcDate=b.maxdate

update tbBusiIncomeReport set REP1=(select isnull(sum(NewAss),0) from tbRepAssCount where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='NewAss'

if(@@Error<>0)	goto LError

--print '�����Աok'

--��ʧ��Ա
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'LostAss',isnull(sum(LoseAss),0),0,0,0,0,0,0,4,@CreateDate from tbRepAssCount where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate

if(@@Error<>0)	goto LError

--print '��ʧ��Աok'

--���տ���Ա
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'CardCycle',0,0,0,isnull(sum(FillFee),0),isnull(sum(PromFee),0),isnull(sum(FillCount),0),0,5,@CreateDate from tbRepAssFill
where vcType='���տ�' and vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate

update tbBusiIncomeReport set REP1=(select isnull(sum(CardCycle),0) from tbRepAssCount where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='CardCycle'

if(@@Error<>0)	goto LError

--������Ա
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'CardAgain',isnull(sum(CardAgain),0),0,0,0,0,0,0,6,@CreateDate from tbRepAssCount where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate

if(@@Error<>0)	goto LError

--�ܳ�ֵ(�ֽ�)
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'FillFee',isnull(sum(AssCount),0),0,0,isnull(sum(FillFee),0),isnull(sum(PromFee),0),isnull(sum(FillCount),0),0,7,@CreateDate from tbRepAssFill where vcType='�ֽ��ֵ' and vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate

if @DeptID<>'%%'
	begin
		--�����Ա�ڱ����ֵ
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-FillFee',isnull(sum(AssCount),0),0,0,isnull(sum(FillFee),0),isnull(sum(PromFee),0),isnull(sum(FillCount),0),0,7,@CreateDate from tbRepAssFill where vcType='�ֽ��ֵ' and vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssBelongDept=@DeptID
	
		--�����Ա�ڱ����ֵ
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-FillFee',isnull(sum(AssCount),0),0,0,isnull(sum(FillFee),0),isnull(sum(PromFee),0),isnull(sum(FillCount),0),0,7,@CreateDate from tbRepAssFill where vcType='�ֽ��ֵ' and vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssBelongDept<>@DeptID

		--�����Ա�������ֵ
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherFillFee',isnull(sum(AssCount),0),0,0,isnull(sum(FillFee),0),isnull(sum(PromFee),0),isnull(sum(FillCount),0),0,7,@CreateDate from tbRepAssFill where vcType='�ֽ��ֵ' and vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--print '��ֵok'


--����ͨ��Ա����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'AssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),8,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT001'

if @DeptID<>'%%'
	begin
		--������ͨ��Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-AssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),8,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT001' and vcAssBelongDept=@DeptID
	
		--������ͨ��Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-AssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),8,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT001' and vcAssBelongDept<>@DeptID

		--������ͨ��Ա����������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),8,@CreateDate from tbRepAssConsDaily where vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT001' and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--print '��ͨ��Ա����ok'

--��������Ա����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'SAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),9,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT003'

if @DeptID<>'%%'
	begin
		--����������Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-SAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),9,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT003' and vcAssBelongDept=@DeptID
	
		--����������Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-SAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),9,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT003' and vcAssBelongDept<>@DeptID

		--����������Ա����������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherSAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),9,@CreateDate from tbRepAssConsDaily where vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT003' and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--�ܽ𿨻�Ա����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'GAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),10,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT004'

if @DeptID<>'%%'
	begin
		--����𿨻�Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-GAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),10,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT004' and vcAssBelongDept=@DeptID
	
		--����𿨻�Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-GAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),10,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT004' and vcAssBelongDept<>@DeptID

		--����𿨻�Ա����������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherGAssCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),10,@CreateDate from tbRepAssConsDaily where vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT004' and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--��������Ա����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'PromCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),11,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT002'

if @DeptID<>'%%'
	begin
		--����������Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-PromCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),11,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT002' and vcAssBelongDept=@DeptID
	
		--����������Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-PromCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),11,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT002' and vcAssBelongDept<>@DeptID

		--����������Ա����������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherPromCons',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),isnull(sum(iIgValue),0),isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),11,@CreateDate from tbRepAssConsDaily where vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT002' and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--print '������Ա����ok'


--����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'Retail',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),0,isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),12,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='AT999'

if(@@Error<>0)	goto LError

--print '����ok'


--�ܻ�Ա����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'Larg',0,0,0,0,0,isnull(sum(LargTimes),0),isnull(sum(GoodsCount),0),13,@CreateDate from tbRepAssLarg where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate

if @DeptID<>'%%'
	begin
		--�����Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-Larg',0,0,0,0,0,isnull(sum(LargTimes),0),isnull(sum(GoodsCount),0),13,@CreateDate from tbRepAssLarg where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssBelongDept=@DeptID
	
		--�����Ա�ڱ�������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-Larg',0,0,0,0,0,isnull(sum(LargTimes),0),isnull(sum(GoodsCount),0),13,@CreateDate from tbRepAssLarg where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssBelongDept<>@DeptID

		--�����Ա����������
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherLarg',0,0,0,0,0,isnull(sum(LargTimes),0),isnull(sum(GoodsCount),0),13,@CreateDate from tbRepAssLarg where vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--print '��Ա����ok'


--�ܻ��ֶһ�
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'IgChange',isnull(sum(AssCount),0),0,isnull(sum(iIgValue),0),0,0,isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),14,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='IgChange'

if @DeptID<>'%%'
	begin
		--�����Ա�ڱ�����ֶһ�
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Local-IgChange',isnull(sum(AssCount),0),0,isnull(sum(iIgValue),0),0,0,isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),14,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='IgChange' and vcAssBelongDept=@DeptID
	
		--�����Ա�ڱ�����ֶһ�
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'Other-IgChange',isnull(sum(AssCount),0),0,isnull(sum(iIgValue),0),0,0,isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),14,@CreateDate from tbRepAssConsDaily where vcDeptID = @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='IgChange' and vcAssBelongDept<>@DeptID

		--�����Ա��������ֶһ�
		insert into tbBusiIncomeReport
		select @StrDate,@DeptID,'LocalToOtherIgChange',isnull(sum(AssCount),0),0,isnull(sum(iIgValue),0),0,0,isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),14,@CreateDate from tbRepAssConsDaily where vcDeptID <> @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='IgChange' and vcAssBelongDept=@DeptID
	end

if(@@Error<>0)	goto LError

--print '���ֶһ�ok'


--���п�����
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'BankRetail',isnull(sum(AssCount),0),0,0,isnull(sum(nFee),0),0,isnull(sum(ConsTimes),0),isnull(sum(GoodsCount),0),15,@CreateDate from tbRepAssConsDaily where vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate and vcAssType='Bank'

if(@@Error<>0)	goto LError

--���п���ֵ
insert into tbBusiIncomeReport
select @StrDate,@DeptID,'BankFillFee',isnull(sum(AssCount),0),0,0,isnull(sum(FillFee),0),isnull(sum(PromFee),0),isnull(sum(FillCount),0),0,16,@CreateDate from tbRepAssFill where vcType='���п���ֵ' and vcDeptID like @DeptID and vcDate between @QueryBeginDate and @QueryEndDate

if(@@Error<>0)	goto LError


--�ܼ�
insert into tbBusiIncomeReport select @StrDate,@DeptID,'Total',0,0,0,0,0,0,0,17,@CreateDate 

update tbBusiIncomeReport set REP1=(select REP1 from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='NewAss') where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'
update tbBusiIncomeReport set REP2=(select REP2 from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='NewState')-(select REP2 from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='OldState') where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'
update tbBusiIncomeReport set REP3=(select REP4 from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='NewState')-(select REP4 from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='OldState') where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'
update tbBusiIncomeReport set REP4=(select isnull(sum(REP4),0) from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type in('FillFee','Retail')) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'
update tbBusiIncomeReport set REP5=(select REP5 from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='FillFee') where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'
update tbBusiIncomeReport set REP6=(select isnull(sum(REP4),0) from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type in('AssCons','PromCons')) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'
update tbBusiIncomeReport set REP7=(select isnull(sum(REP7),0) from tbBusiIncomeReport where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type in('AssCons','PromCons','Retail','IgChange','Larg')) where vcDateZoom=@StrDate and vcDeptID=@DeptID and Type='Total'


if(@@Error<>0)	goto LError

--print '�ܼ�ok'

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

