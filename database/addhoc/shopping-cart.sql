 
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

select top 100 *
from ShoppingCart
order by CreatedDttm desc;


select count(1)
from ShoppingCartItem;

select top 100 *
from ShoppingCartItem
where ShoppingCartId = 789808;

select top 100 *
from ShoppingCartItem
order by CreatedDttm desc;
