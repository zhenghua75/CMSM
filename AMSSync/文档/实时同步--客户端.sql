

---------------------服务器和客户端都需要----新建同步会员临时表-------------------
CREATE TABLE [tbAssociatorSync] (
	[iSerial] [bigint] IDENTITY (1, 1) NOT NULL ,
	[vcCardID] [varchar] (10) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[vcAssName] [varchar] (30) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcSpell] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcAssNbr] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcLinkPhone] [varchar] (25) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcLinkAddress] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcEmail] [varchar] (30) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcAssType] [varchar] (5) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcAssState] [char] (1) COLLATE Chinese_PRC_CI_AS NULL ,
	[nCharge] [numeric](10, 2) NULL ,
	[iIgValue] [int] NULL ,
	[vcCardFlag] [char] (1) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcComments] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[dtCreateDate] [datetime] NULL ,
	[dtOperDate] [datetime] NULL ,
	[vcDeptID] [varchar] (5) COLLATE Chinese_PRC_CI_AS NULL ,
	[vcCardSerial] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,
	[iUpdateCount] [bigint] NULL ,
	CONSTRAINT [PK_TBASSOCIATORSYNC] PRIMARY KEY  CLUSTERED 
	(
		[iSerial]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

CREATE INDEX tbAssociatorSync_cardid ON tbAssociatorSync(vcCardID)
CREATE INDEX tbAssociatorSync_updatecount ON tbAssociatorSync(iUpdateCount)
GO


----------------------系统错误日志表-----------------------
CREATE TABLE [tbSysErrorLog] (
	[iSerial] [bigint] IDENTITY (1, 1) NOT NULL ,
	[vcDeptID] [varchar] (5) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[dtErrDate] [datetime] NULL ,
	[vcErrorDes] [varchar] (3000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK_TBSYSERRORLOG] PRIMARY KEY  CLUSTERED 
	(
		[iSerial],
		[vcDeptID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO




------------门店同步标识，标识在服务器上的会员资料某个门店是否已经更新过-----------
------------新门店标识，必须在原最大标识的基础上*2，或是2的n次方，以此类推，不能重复------------
insert into tbCommCode values('1','MDZH1','SYNCN','门店同步标识')