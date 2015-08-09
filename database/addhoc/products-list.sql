CART
use Interceuticals

SELECT P.OTCProductId as Id, DisplayText as Label,
COALESCE(OTCParentProductId,0) AS ParentProductId,
COALESCE(OTCSubordinateProductId,0) AS SubordinateProductId,
CASE
WHEN OTCParentProductId IS NOT NULL THEN 1
ELSE 0
END AS HasAutohip
FROM OTCProduct P
JOIN OTCVisibleProduct VP
ON VP.OTCProductId = P.OTCProductId
AND OTCProductCategoryId = 21
LEFT JOIN OTCProductRelationship R
ON R.OTCParentProductId = P.OTCProductID
WHERE OTCSiteId = 7
ORDER BY DisplayOrder

select *
from OTCProduct;