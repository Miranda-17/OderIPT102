CREATE PROCEDURE [dbo].[GetAllOrders]
AS
BEGIN
    SELECT * FROM [Order]
    ORDER BY OrderDate DESC
END
