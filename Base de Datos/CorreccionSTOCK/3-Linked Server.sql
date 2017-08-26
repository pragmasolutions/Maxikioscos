USE [master]
GO

/****** Object:  LinkedServer [SQL5010.SMARTERASP.NET]    Script Date: 22/02/2017 7:41:09 ******/
EXEC master.dbo.sp_addlinkedserver @server = N'SQL5010.SMARTERASP.NET', @srvproduct=N'SQL Server'
 /* For security reasons the linked server remote logins password is changed with ######## */
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'SQL5010.SMARTERASP.NET',@useself=N'False',@locallogin=NULL,@rmtuser=N'DB_9B2582_MaxiKioscos_admin',@rmtpassword='quilombito'

GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'collation compatible', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'data access', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'dist', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'pub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'rpc', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'rpc out', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'sub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'connect timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'collation name', @optvalue=null
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'lazy schema validation', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'query timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'use remote collation', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'SQL5010.SMARTERASP.NET', @optname=N'remote proc transaction promotion', @optvalue=N'true'
GO


