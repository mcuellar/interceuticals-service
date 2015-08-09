 
 /* Get Shopping Cart by Session */
  SELECT COALESCE(SC.PromotionId,0) AS PromotionId,
         COALESCE(SC.GlobalDiscountAmount,0) AS GlobalDiscountAmount,
         COALESCE(SC.GlobalPercentageAmount,0) AS GlobalPercentageAmount,
         SC.*,SCI.*,SCI.itemCount*SCI.orderPrice AS itemTotalCost
    FROM ShoppingCart SC 
    LEFT JOIN ShoppingCartItem SCI 
      ON SCI.shoppingCartID = SC.shoppingCartID 
   WHERE SC.shoppingCartID = 0


/* Check Shopping Cart */

select count(1)
from ShoppingCart;

select top 1000 *
from ShoppingCart
order by CreatedDttm desc;


select count(1)
from ShoppingCartItem;

select top 100 *
from ShoppingCartItem
where ShoppingCartId = 789808;

select top 1000 *
from ShoppingCartItem
order by CreatedDttm desc;


/* Shopping Cart Item */

SELECT *
  FROM ShoppingCartItem 
 WHERE ShoppingCartItemId = @ShoppingCartItemID 


SELECT *
  FROM ShoppingCartItemFeature CIF
  JOIN OTCProductFeatureTypeAffiliation FTA
    ON FTA.OTCProductFeatureTypeAffiliationId = CIF.OTCProductFeatureTypeAffiliationId
  JOIN OTCProductFeature F 
    ON F.OTCProductFeatureId = FTA.OTCProductFeatureId
  JOIN OTCProductFeatureType FT
    ON FT.OTCProductFeatureTypeId = F.OTCProductFeatureTypeId
 WHERE OTCShoppingCartItemId = @shoppingCartItemID


 /* Features */
 select top 100 *
 from ShoppingCartItemFeature;


 select top 100 *
 from OTCProductFeatureTypeAffiliation;

 select max(CreatedDttm)
 from OTCProductFeatureTypeAffiliation;


 /*  Save the cart item legacy */

 
CREATE PROCEDURE dbo.spInsertShoppingCartItem
(
   @shoppingCartID INT,
   @itemCount INT = 1,
   @productID INT,
   @productPrice FLOAT,
   @productFeatureIdentifier DECIMAL(38,0),
   @shippingPrice FLOAT,
   @promotionKey VARCHAR(255) = ''
)
AS
-- ****************************************************************
-- *	Program Name    :	spInsertShoppingCartItem
-- ****************************************************************
DECLARE @otcPromotionId 	INT 
DECLARE @orderPrice     	FLOAT 
DECLARE @discountAmount 	FLOAT 
DECLARE @discountPercentage     FLOAT

SET @otcPromotionId 	= 0 
SET @orderPrice 	= 0.00

IF LEN(@promotionKey) > 0 
 BEGIN
   SELECT @OTCpromotionId = OTCPromotionId FROM OTCPromotion WHERE PromotionKey = @promotionKey 
 END 

IF EXISTS(SELECT 'x' FROM ShoppingCartItem WHERE shoppingCartID = @shoppingCartID AND productID = @productID AND productFeatureIdentifier = @productFeatureIdentifier)
 BEGIN
  UPDATE ShoppingCartItem 
     SET 
         itemCount = @itemCount,
         OTCPromotionId = @OTCpromotionId
   WHERE shoppingCartID = @shoppingCartID 
     AND productFeatureIdentifier = @productFeatureIdentifier
  SELECT @shoppingCartId AS ShoppingCartId
 END 
ELSE 
 BEGIN
  INSERT INTO ShoppingCartItem(shoppingCartID,productID,productPrice,OTCPromotionId,OrderPrice,ShippingPrice,itemCount,productFeatureIdentifier)
		        VALUES(@shoppingCartID,@productID,@productPrice,@otcPromotionId,@productPrice/*set order price to product price*/,@ShippingPrice,@itemCount,@productFeatureIdentifier)
  SELECT SCOPE_IDENTITY() AS ShoppingCartId
 END
