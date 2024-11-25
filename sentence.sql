CREATE DATABASE SaleEFE
GO
USE SaleEFE

CREATE TABLE Category
(
	CategoryId INT PRIMARY KEY IDENTITY(1, 1),
	Description VARCHAR(100) NOT NULL,
	ShortDescription VARCHAR(30) NULL,
	IsActive BIT NOT NULL DEFAULT (1),
	CreatorUser VARCHAR(20) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT (GETDATE()),
	ModifierUser VARCHAR(20) NULL,
	ModificationDate DATETIME NULL
)
GO

CREATE TABLE Brand
(
	BrandId INT PRIMARY KEY IDENTITY(1, 1),
	Description VARCHAR(100) NOT NULL,
	ShortDescription VARCHAR(30) NULL,
	IsActive BIT NOT NULL DEFAULT (1),
	CreatorUser VARCHAR(20) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT (GETDATE()),
	ModifierUser VARCHAR(20) NULL,
	ModificationDate DATETIME NULL
)
GO

CREATE TABLE Product
(
	ProductId INT PRIMARY KEY IDENTITY(1, 1),
	BrandId INT NOT NULL,
	CategoryId INT NOT NULL,
	Description VARCHAR(250) NOT NULL,
	ShortDescription VARCHAR(100) NULL,
	BasePrice DECIMAL(18, 2) NOT NULL,
	ImgUrl VARCHAR(255) NOT NULL,
	IsActive BIT NOT NULL DEFAULT (1),
	CreatorUser VARCHAR(20) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT (GETDATE()),
	ModifierUser VARCHAR(20) NULL,
	ModificationDate DATETIME NULL,

	CONSTRAINT FK_ProductBrandId FOREIGN KEY (BrandId) REFERENCES Brand(BrandId),
	CONSTRAINT FK_ProductCategoryId FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
)
GO

CREATE TABLE Customer
(
	CustomerId INT PRIMARY KEY IDENTITY(1,1),
	Names VARCHAR(50) NOT NULL,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Email VARCHAR(50) NULL,
	NumberPhone VARCHAR(20) NULL,
	IsActive BIT NOT NULL DEFAULT (1),
	CreatorUser VARCHAR(20) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT (GETDATE()),
	ModifierUser VARCHAR(20) NULL,
	ModificationDate DATETIME NULL
)
GO

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY(1, 1),
	CustomerId INT NOT NULL,
	DateOrder DATETIME NOT NULL,
	IsActive BIT NOT NULL DEFAULT (1),
	CONSTRAINT FK_SaleCustomerId FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),

)
GO

CREATE TABLE OrderDetail
(
	OrderDetailId INT PRIMARY KEY IDENTITY(1,1),
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	Discount INT NOT NULL,

	CONSTRAINT FK_OrderDetailOrderId FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
	CONSTRAINT FK_OrderDetailProductId FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
)
GO

--INSERT DATA
INSERT INTO Category (Description, ShortDescription, IsActive, CreatorUser)
VALUES 
('Laptops', 'Portátiles', 1, 'admin'),
('Monitors', 'Monitores', 1, 'admin'),
('Smartphones', 'Teléfonos', 1, 'admin'),
('Tablets', 'Tabletas', 1, 'admin');
GO

INSERT INTO Brand (Description, ShortDescription, IsActive, CreatorUser)
VALUES 
('Dell', 'Dell Inc.', 1, 'admin'),
('Apple', 'Apple Inc.', 1, 'admin'),
('HP', 'Hewlett-Packard', 1, 'admin'),
('Samsung', 'Samsung Electronics', 1, 'admin'),
('Asus', 'AsusTek', 1, 'admin'),
('Google', 'Google LLC', 1, 'admin'),
('Lenovo', 'Lenovo Group', 1, 'admin'),
('MSI', 'Micro-Star International', 1, 'admin'),
('Acer', 'Acer Inc.', 1, 'admin'),
('OnePlus', 'OnePlus Tech', 1, 'admin'),
('Microsoft', 'Microsoft Corp.', 1, 'admin'),
('Razer', 'Razer Inc.', 1, 'admin');

INSERT INTO Product (BrandId, CategoryId, Description, ShortDescription, BasePrice, ImgUrl, IsActive, CreatorUser)
VALUES 
(1, 1, 'Laptop Dell XPS 13', 'Ultrabook 13"', 1200.99, 'https://example.com/dell-xps13.jpg', 1, 'admin'),
(1, 2, 'Monitor Dell 24"', 'Monitor FullHD', 200.50, 'https://example.com/dell-monitor24.jpg', 1, 'admin'),
(2, 1, 'MacBook Pro 16"', 'Laptop Apple', 2400.75, 'https://example.com/macbook-pro16.jpg', 1, 'admin'),
(2, 3, 'iPhone 14 Pro Max', 'Smartphone Apple', 1300.99, 'https://example.com/iphone-14-pro-max.jpg', 1, 'admin'),
(3, 1, 'HP Envy 15', 'Laptop HP', 1500.49, 'https://example.com/hp-envy15.jpg', 1, 'admin'),
(3, 2, 'Impresora HP DeskJet', 'Impresora multifuncional', 120.00, 'https://example.com/hp-deskjet.jpg', 1, 'admin'),
(4, 3, 'Samsung Galaxy S23 Ultra', 'Smartphone Samsung', 1400.00, 'https://example.com/samsung-s23-ultra.jpg', 1, 'admin'),
(4, 4, 'Samsung Tab S8', 'Tablet Samsung', 750.00, 'https://example.com/samsung-tab-s8.jpg', 1, 'admin'),
(5, 1, 'Asus ROG Strix G15', 'Laptop Gaming Asus', 1700.99, 'https://example.com/asus-rog-strix.jpg', 1, 'admin'),
(5, 2, 'Monitor Asus TUF Gaming', 'Monitor Gaming 27"', 350.50, 'https://example.com/asus-monitor-tuf.jpg', 1, 'admin'),
(6, 3, 'Google Pixel 7', 'Smartphone Google', 899.99, 'https://example.com/google-pixel7.jpg', 1, 'admin'),
(7, 1, 'Lenovo ThinkPad X1', 'Ultrabook Lenovo', 1250.00, 'https://example.com/lenovo-thinkpad-x1.jpg', 1, 'admin'),
(7, 4, 'Lenovo Yoga Smart Tab', 'Tablet Lenovo', 300.99, 'https://example.com/lenovo-yoga-tab.jpg', 1, 'admin'),
(8, 1, 'MSI Stealth 15M', 'Laptop Gaming MSI', 1800.00, 'https://example.com/msi-stealth-15m.jpg', 1, 'admin'),
(8, 2, 'MSI Optix Monitor', 'Monitor Gaming 24"', 400.00, 'https://example.com/msi-optix.jpg', 1, 'admin'),
(9, 1, 'Acer Aspire 5', 'Laptop Acer', 800.00, 'https://example.com/acer-aspire5.jpg', 1, 'admin'),
(9, 2, 'Acer Predator Monitor', 'Monitor Gaming 34"', 600.50, 'https://example.com/acer-predator.jpg', 1, 'admin'),
(10, 3, 'OnePlus 11 Pro', 'Smartphone OnePlus', 700.00, 'https://example.com/oneplus-11-pro.jpg', 1, 'admin'),
(11, 4, 'Microsoft Surface Pro 9', 'Tablet Microsoft', 1100.00, 'https://example.com/surface-pro9.jpg', 1, 'admin'),
(12, 1, 'Razer Blade 14', 'Laptop Gaming Razer', 2100.99, 'https://example.com/razer-blade14.jpg', 1, 'admin');

UPDATE Product SET ImgUrl = 'https://plazavea.vteximg.com.br/arquivos/ids/30208938-650-650/20425669.jpg'

INSERT INTO Customer(Names, FirstName, LastName, IsActive, CreatorUser, CreationDate) VALUES ('Nothing', 'Nothing', 'Nothing', 1, '12024', GETDATE())
GO

--STORES PROCEDURES--

CREATE PROCEDURE dsp_InsertarOrder
	@CustomerId INT,
	@DateOrder DATETIME,
	@OrderId INT OUT
AS
BEGIN
	INSERT INTO Orders
	(
		CustomerId, DateOrder
	)
	VALUES
	(
		@CustomerId, @DateOrder
	)

	SET @OrderId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE dsp_InsertarOrderDetail
	@OrderId INT,
	@ProductId INT,
	@Quantity INT,
	@Price DECIMAL(18, 2),
	@Discount FLOAT
AS
BEGIN
	INSERT INTO OrderDetail
	(
		OrderId, ProductId, Quantity, Price, Discount
	)
	VALUES
	(
		@OrderId, @ProductId, @Quantity, @Price, @Discount
	)
END
GO	

CREATE PROCEDURE dsp_GetOrderByCustomerId
	@CustomerId INT
AS
BEGIN
	SELECT
		ord.OrderId,
		ord.CustomerId,
		od.OrderDetailId,
		od.Quantity,
		od.Discount,
		pr.ProductId,
		pr.[Description] AS DescProduct,
		pr.BasePrice,
		br.Description[DescBrand]
	FROM Orders ord
	INNER JOIN OrderDetail od ON (od.OrderId = ord.OrderId)
	INNER JOIN Product pr ON (pr.ProductId = od.ProductId)
	INNER JOIN Brand br ON (br.BrandId = pr.BrandId)
	WHERE --ord.CustomerId = @CustomerId AND 
	ord.IsActive = 1
END
GO

CREATE PROCEDURE dsp_GetProducts
AS
BEGIN
	SELECT
		pro.ProductId,
		pro.Description,
		pro.ShortDescription,
		pro.ImgUrl,
		pro.BasePrice,
		bran.BrandId,
		bran.Description[DescBrand]
	FROM Product pro
	INNER JOIN Brand bran ON (bran.BrandId = pro.BrandId)
END
GO
