--(completed successfully)
--ALTER TABLE dbo.Good 
--ADD CONSTRAINT GoodStock_Check CHECK (Stock >= 0)

IF OBJECT_ID('InsertSalePos', 'P') IS NOT NULL
   DROP PROCEDURE InsertSalePos;
   
GO   
CREATE PROCEDURE InsertSalePos
   @SaleId INT, 
   @GoodId INT, 
   @Quantity NUMERIC(18,3)
AS
BEGIN
   DECLARE @Price money = (SELECT Price
                           FROM dbo.Good
                           WHERE GoodId = @GoodId);
   BEGIN TRAN
     BEGIN TRY
   
	   UPDATE dbo.Good
	   SET
	   Stock = Stock - @Quantity
	   WHERE GoodId = @GoodId;
	   
	   INSERT INTO dbo.SalePos(SaleId, GoodId, Quantity, SalePosSum)
	   VALUES (@SaleId, @GoodId, @Quantity, @Quantity * @Price);
	   
	   UPDATE dbo.Sale
	   SET SaleAmount = SaleAmount + @Quantity * @Price
	   WHERE SaleId = @SaleId;
	   COMMIT;
     END TRY
     BEGIN CATCH
       ROLLBACK;
     END CATCH
   
END
GO