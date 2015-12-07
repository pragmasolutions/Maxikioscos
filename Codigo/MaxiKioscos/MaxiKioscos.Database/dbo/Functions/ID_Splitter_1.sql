
CREATE FUNCTION  [dbo].[ID_Splitter](@IDs Varchar(8000) )  
RETURNS @Tbl_IDs TABLE  (ID Int)  As  

BEGIN 
 -- Append comma

 SET @IDs =  @IDs + ',' 
 -- Indexes to keep the position of searching

 DECLARE @Pos1 Int
 DECLARE @pos2 Int
 
 -- Start from first character 

 SET @Pos1=1
 SET @Pos2=1

 WHILE @Pos1<LEN(@IDs)
 BEGIN
  SET @Pos1 = CHARINDEX(',',@IDs,@Pos1)
  INSERT @Tbl_IDs Select  CAST(SUBSTRING(@IDs,@Pos2,@Pos1-@Pos2) AS INT)
  -- Go to next non comma character

  SET @Pos2=@Pos1+1
  -- Search from the next charcater

  SET @Pos1 = @Pos1+1
 END 
 RETURN
END


