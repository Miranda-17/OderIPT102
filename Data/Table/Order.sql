CREATE TABLE [dbo].[Order]
(
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(150) NOT NULL,
    OrderName NVARCHAR(150) NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    OrderStatus NVARCHAR(50) NOT NULL
);