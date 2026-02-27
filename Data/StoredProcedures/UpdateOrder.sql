CREATE PROCEDURE [dbo].[UpdateOrder]
    @OrderId INT,
    @CustomerName NVARCHAR(150),
    @OrderName NVARCHAR(150),
    @OrderDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @OrderStatus NVARCHAR(50)
AS
BEGIN
    UPDATE [Order]
    SET
        CustomerName = @CustomerName,
        OrderName = @OrderName,
        OrderDate = @OrderDate,
        TotalAmount = @TotalAmount,
        OrderStatus = @OrderStatus
    WHERE OrderId = @OrderId
END