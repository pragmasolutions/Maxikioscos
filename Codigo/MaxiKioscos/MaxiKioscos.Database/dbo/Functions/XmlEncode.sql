
CREATE FUNCTION XmlEncode
(
	@XML XML
)
RETURNS XML
AS
BEGIN
	DECLARE @Text XML

	SET @Text = '<?xml version="1.0" encoding="UTF-32"?>' + CAST(@XML as varchar(MAX))
	-- Return the result of the function
	RETURN CAST(@Text as XML)

END
