SELECT p.Name AS Product,
       coalesce(c.Name, '-') AS Category
       
FROM Products AS p

LEFT JOIN ProductsCategories AS pc
     ON p.ID = pc.productID

LEFT JOIN Categories AS c
     ON pc.categoryID = c.ID