

CREATE TABLE [tbSetZero] (
	[vcCardID] [varchar] (10) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[dtInsertDate] [datetime] NULL 
) ON [PRIMARY]
GO


---��ʼ�������Ѿ������Ļ�Ա
insert into tbSetZero
select vcCardID,getdate() from tbIntegralLogOther where dtIgDate>'2010-01-01' and iIgLast=0 and vcIgType='IGT01'and vcCardID not in(select vcCardID from tbSetZero)

