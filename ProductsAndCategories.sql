SELECT p.Name Product, c.Name Category
FROM Products p
         LEFT JOIN ProductsCategories pc on p.Id = pc.ProductId
         LEFT JOIN Categories c ON c.Id = pc.CategoryId; 
