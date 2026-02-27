CREATE PROCEDURE [dbo].[AddOrder]
    @CustomerName NVARCHAR(150),
    @OrderName NVARCHAR(150),
    @OrderDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @OrderStatus NVARCHAR(50)
AS
BEGIN
    INSERT INTO [Order]
    (
        CustomerName,
        OrderName,
        OrderDate,
        TotalAmount,
        OrderStatus
    )
    VALUES
    (
        @CustomerName,
        @OrderName,
        @OrderDate,
        @TotalAmount,
        @OrderStatus
    )
END