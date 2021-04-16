CREATE TABLE Products (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [Name] NVARCHAR(30)
)

 CREATE TABLE Categories (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [Name] NVARCHAR(30)
)

CREATE TABLE Product_to_Category (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [product_id] INT NOT NULL,
  [category_id] INT NOT NULL
)
INSERT Products VALUES ('Product1')
INSERT Products VALUES ('Product2')
INSERT Products VALUES ('Product3')
INSERT Products VALUES ('Product4')
INSERT Products VALUES ('Product5')
INSERT Products VALUES ('Product6')

INSERT Categories VALUES ('Category1')
INSERT Categories VALUES ('Category2')
INSERT Categories VALUES ('Category3')

INSERT Product_to_Category(product_id, category_id) VALUES (1,1)
INSERT Product_to_Category(product_id, category_id) VALUES (1,2)
INSERT Product_to_Category(product_id, category_id) VALUES (1,3)

INSERT Product_to_Category(product_id, category_id) VALUES (2,1)
INSERT Product_to_Category(product_id, category_id) VALUES (2,2)
INSERT Product_to_Category(product_id, category_id) VALUES (2,3)


