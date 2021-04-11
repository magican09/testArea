SELECT products.*, GROUP_CONCAT(categories.title) AS categ
    FROM products
    INNER JOIN categories_to_products ON products.id =  categories_to_products.product_id
    LEFT JOIN categories ON categories_to_products.category_id = categories.id                     
    GROUP BY products.title 