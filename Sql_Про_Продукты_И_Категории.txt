SELECT dbo.Products.Name, dbo.Categorys.Name
  FROM dbo.Products
LEFT JOIN dbo.CategorysProducts
  ON dbo.Products.ID = dbo.CategorysProducts.ProductId
LEFT JOIN dbo.Categorys
  ON dbo.CategorysProducts.CaregoryId = dbo.Category.ID