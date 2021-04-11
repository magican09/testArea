SELECT Products.Name , Categories.Name
FROM Products
LEFT JOIN Product_to_Category  ON Products.id = Product_to_Category.product_id
LEFT JOIN Categories ON Product_to_Category.category_id = Categories.id
