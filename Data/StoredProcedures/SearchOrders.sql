CREATE PROCEDURE [dbo].[SearchOrders]
    @Keyword NVARCHAR(150)
AS
BEGIN
    SELECT * FROM [Order]
    WHERE CustomerName LIKE '%' + @Keyword + '%'
       OR OrderName LIKE '%' + @Keyword + '%'
    ORDER BY OrderDate DESC
END