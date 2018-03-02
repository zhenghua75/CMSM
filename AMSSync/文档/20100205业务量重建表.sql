

--------------------------��ֵ�м�Դ��----------------------------
drop table tbRepAssFill
go

CREATE TABLE [tbRepAssFill] (
	[vcType] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[vcDeptID] [varchar] (5) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[vcDate] [char] (8) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[AssCount] [int] NOT NULL ,
	[FillFee] [numeric](38, 2) NOT NULL ,
	[PromFee] [numeric](38, 2) NOT NULL ,
	[FillCount] [int] NOT NULL ,
	[vcAssBelongDept] [varchar] (5) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	CONSTRAINT [PK_tbRepAssFill] PRIMARY KEY  CLUSTERED 
	(
		[vcType],
		[vcDeptID],
		[vcDate],
		[vcAssBelongDept]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO


--------------------------��Ա���仯�м�Դ��----------------------------
drop table tbRepAssCount
go

CREATE TABLE [tbRepAssCount] (
	[vcDeptID] [varchar] (5) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[vcDate] [char] (8) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[NewAss] [int] NULL ,
	[LoseAss] [int] NULL ,
	[RelaseLoseAss] [int] NULL ,
	[CardCycle] [int] NULL ,
	[OnlyAss] [int] NULL ,
	[CardAgain] [int] NULL ,
	CONSTRAINT [PK_tbRepAssCount] PRIMARY KEY  CLUSTERED 
	(
		[vcDeptID],
		[vcDate]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO


-----------------------------�����ղ�������û��д�ԣ��޸�һ��--------------------------
insert into tbCommCode values('������','OP011','OP','��������')



