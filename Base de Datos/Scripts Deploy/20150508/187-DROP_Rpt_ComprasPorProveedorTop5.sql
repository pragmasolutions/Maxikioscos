IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_ComprasPorProveedorTop5]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_ComprasPorProveedorTop5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_DescuentoProveedores]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_DescuentoProveedores]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_DescuentoProveedoresTop5]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_DescuentoProveedoresTop5]
GO