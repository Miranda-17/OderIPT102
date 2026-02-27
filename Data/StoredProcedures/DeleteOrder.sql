CREATE PROCEDURE [dbo].[DeleteOrder]
    @OrderId INT
AS
BEGIN
    DELETE FROM [Order]
    WHERE OrderId = @OrderId
END