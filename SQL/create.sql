BEGIN TRAN;

CREATE TABLE Products
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(256) NOT NULL UNIQUE
);

CREATE TABLE Categories
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(256) NOT NULL UNIQUE
);

CREATE TABLE ProductsCategories
(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    productID INT REFERENCES Products (ID),
    categoryID INT REFERENCES Categories (ID)
);

INSERT INTO Categories (Name) VALUES 
('Electronics'),
('Office supplies'),
('Fruits');

INSERT INTO Products (Name) VALUES 
('iPhone 13'),
('Laptop Xiaomi 132ab'),
('Phone r-fon 1'),
('Pen'),
('Pencil'),
('Electronic pen'),
('Apple'),
('Banana'),
('Lychee'),
('Cheburashka');

INSERT INTO ProductsCategories (productID, categoryID) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 2),
(5, 2),
(6, 1),
(6, 2),
(7, 3),
(8, 3),
(9, 3)

COMMIT;