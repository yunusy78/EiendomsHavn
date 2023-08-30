CREATE TABLE [dbo].[Categories] (
    [Id]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]        NVARCHAR (MAX)   NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    [ImageUrl]    NVARCHAR (MAX)   NOT NULL,
    [CreatedAt]   DATETIME2 (7)    NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Products] (
    [Id]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Title]        NVARCHAR (MAX)   NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    [ImageUrl]    NVARCHAR (MAX)   NOT NULL,
    [CoverImageUrl] NVARCHAR (MAX)   NOT NULL,
    [CreatedAt]   DATETIME2 (7)    NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ProductDetails] (
    [Id]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ProductId]  UNIQUEIDENTIFIER  NOT NULL,
    [Size]        integer   NOT NULL,
    [BadromCount] tinyint NOT NULL,
    [BathCount]    tinyint   NOT NULL,
    [RomCount] tinyint   NOT NULL,
    [GarageSize]   tinyint NOT NULL,
    [BuildYear]      Char(4)   NOT NULL,
    [Location] NVARCHAR (MAX)   NOT NULL,
    [VideoUrl] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customer] (
    [Id]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]       NVARCHAR (100)   NOT NULL,
    [Title]       NVARCHAR (200)   NOT NULL,
    [Comment]       NVARCHAR (2000)   NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Employee] (
    [Id]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]       NVARCHAR (100)   NOT NULL,
    [Title]       NVARCHAR (200)   NOT NULL,
    [Email]       NVARCHAR (200)   NOT NULL,
    [PhoneNumber]       NVARCHAR (100)   NOT NULL,
    [Status]      BIT              NOT NULL,
    [ImageUrl]    NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Addresses] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Street]      NVARCHAR(200)    NOT NULL,
    [City]        NVARCHAR(100)    NOT NULL,
    [PostalCode]  NVARCHAR(20)     NOT NULL,
    [Country]     NVARCHAR(100)    NOT NULL,
    [CreatedAt]   DATETIME2(7)     NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

ALTER TABLE [dbo].[Products]
ADD [AddressId] UNIQUEIDENTIFIER NULL;

ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Addresses_AddressId] 
    FOREIGN KEY ([AddressId]) 
    REFERENCES [dbo].[Addresses] ([Id]) 
    ON DELETE SET NULL;



-- Veri Girişi 1
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Enebolig', N'Enboliger og hus', 'url1', '2023-08-30 10:00:00', 1);

-- Veri Girişi 2
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Tomannsbolig', N'Dobbelthus og leiligheter', 'url2', '2023-08-30 11:30:00', 1);

-- Veri Girişi 3
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Rekkehus', N'Rekkehus og terrassehus', 'url3', '2023-08-30 12:45:00', 1);

-- Veri Girişi 4
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Leilighet', N'Leiligheter og leilighetskomplekser', 'url4', '2023-08-30 14:15:00', 1);

-- Veri Girişi 5
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Hybel', N'Hybler og ettromsleiligheter', 'url5', '2023-08-30 15:30:00', 1);

-- Veri Girişi 6
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Fritidsbolig', N'Fritidshus og hytter', 'url6', '2023-08-30 16:45:00', 1);

-- Veri Girişi 7
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Gårdsbruk', N'Gårdsbruk og landlige eiendommer', 'url7', '2023-08-30 18:00:00', 1);

-- Veri Girişi 8
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Skogeiendom', N'Skogeiendom og skogområder', 'url8', '2023-08-30 19:15:00', 1);

-- Veri Girişi 9
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Næringslokale', N'Næringslokaler og butikklokaler', 'url9', '2023-08-30 20:30:00', 1);

-- Veri Girişi 10
INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt, Status)
VALUES (N'Kontorlokale', N'Kontorlokaler', 'url10', '2023-08-30 21:45:00', 1);


-- Veri Girişi 1
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Ahmet Yılmaz', N'Software Engineer', N'ahmet@example.com', N'555-1234', 1, 'url1');

-- Veri Girişi 2
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Ayşe Kaya', N'Designer', N'ayse@example.com', N'555-5678', 1, 'url2');

-- Veri Girişi 3
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Mehmet Demir', N'Project Manager', N'mehmet@example.com', N'555-9876', 1, 'url3');

-- Veri Girişi 4
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Fatma Öztürk', N'Marketing Specialist', N'fatma@example.com', N'555-3456', 1, 'url4');

-- Veri Girişi 5
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Ali Can', N'QA Engineer', N'ali@example.com', N'555-6543', 1, 'url5');

-- Veri Girişi 6
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Zeynep Yıldız', N'HR Manager', N'zeynep@example.com', N'555-8765', 1, 'url6');

-- Veri Girişi 7
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Osman Ateş', N'Financial Analyst', N'osman@example.com', N'555-4321', 1, 'url7');

-- Veri Girişi 8
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Derya Gündoğdu', N'Sales Representative', N'derya@example.com', N'555-6789', 1, 'url8');

-- Veri Girişi 9
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Elif Karahan', N'Customer Support', N'elif@example.com', N'555-2345', 1, 'url9');

-- Veri Girişi 10
INSERT INTO Employee (Name, Title, Email, PhoneNumber, Status, ImageUrl)
VALUES (N'Cem Tekin', N'Operations Manager', N'cem@example.com', N'555-7890', 1, 'url10');





INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Enebolig - Oslo', N'Oslo şehrinde satılık güzel bir enebolig.', 'url1', 'cover_url1', '2023-08-30 10:00:00', 1, 'eed0e63a-981b-4327-a14b-0ad3b8051a25', '1c8e4489-2fa5-40a5-960f-01c5b48da22f');

-- Veri Girişi 2
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Tomannsbolig - Bergen', N'Bergen şehrinde satılık iki daireli bir tomannsbolig.', 'url2', 'cover_url2', '2023-08-30 11:30:00', 1, '3500c1ea-7c63-4f43-8c73-0c1a261ecd10', '8a6696e5-2989-40df-b06d-34d14402f2a8');

-- Veri Girişi 3
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Rekkehus - Trondheim', N'Trondheim şehrinde satılık modern bir rekkehus.', 'url3', 'cover_url3', '2023-08-30 12:45:00', 1, '34e33c27-df95-405f-9681-2749fb592ed3', 'b8d2953e-a62f-4c4e-9602-3f8388b72a23');



INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Leilighet - Stavanger', N'Stavanger şehrinde satılık lüks bir daire.', 'resim_url4', 'kapak_resim_url4', '2023-08-30 14:15:00', 1, 'cc479f5b-3cc4-47bb-bb42-29443e85fc16', 'efdebeb8-fb4a-46c4-bb06-5eb250e59e35');

-- Veri Girişi 5
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Hybel - Tromsø', N'Tromsø şehrinde kiralık bir stüdyo daire.', 'resim_url5', 'kapak_resim_url5', '2023-08-30 15:30:00', 1, '8e421404-4317-4bb6-a8fa-b771a384260a', '9b750dd7-5eb8-4d6d-95f0-731b0ebe535b');

-- Veri Girişi 6
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Fritidsbolig - Bodø', N'Bodø şehrinde doğa içinde bir tatil evi.', 'resim_url6', 'kapak_resim_url6', '2023-08-30 16:45:00', 1, 'ebba3914-e8a7-4929-aa81-cfba29be9587', 'fe0fa0aa-4cc2-4a48-b89d-9d58bd636e16');

-- Veri Girişi 7
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Gårdsbruk - Ålesund', N'Ålesund şehrinde satılık bir çiftlik evi.', 'resim_url7', 'kapak_resim_url7', '2023-08-30 18:00:00', 1, '4c646750-f5cf-45c4-8e8c-d7b24d54d959', '38be17cc-5d94-40b9-a571-ac3a22ce7677');

-- Veri Girişi 8
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Skogeiendom - Molde', N'Molde şehrinde satılık bir orman arazisi.', 'resim_url8', 'kapak_resim_url8', '2023-08-30 19:15:00', 1, '54e6ce4d-12bd-4971-b3c9-d870394c1a1c', '246cc0df-0221-49f5-aaa6-d2d54d0c17bf');

-- Veri Girişi 9
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Næringslokale - Kristiansand', N'Kristiansand şehrinde kiralık bir ticari alan.', 'resim_url9', 'kapak_resim_url9', '2023-08-30 20:30:00', 1, 'b1b0c397-338d-4d01-ad50-db9aa6503c2e', '1945baa5-b6ed-404a-b8ef-dbf7d1a98656');

-- Veri Girişi 10
INSERT INTO Products (Title, Description, ImageUrl, CoverImageUrl, CreatedAt, Status, EmployeeId, CategoryId)
VALUES (N'Kontorlokale - Fredrikstad', N'Fredrikstad şehrinde kiralık bir ofis alanı.', 'resim_url10', 'kapak_resim_url10', '2023-08-30 21:45:00', 1, 'ac922e76-dc20-42c9-ac29-f16e88aa7365', '5ec2ba0b-f03c-4a91-9f45-f2bc34c2d8de');




-- Adres Verisi 1
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Oslo Caddesi 123', N'Oslo', N'01234', N'Norveç', '2023-08-30 10:00:00', 1);

-- Adres Verisi 2
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Bergen Yolu 456', N'Bergen', N'56789', N'Norveç', '2023-08-30 11:30:00', 1);

-- Adres Verisi 3
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Trondheim Caddesi 789', N'Trondheim', N'90123', N'Norveç', '2023-08-30 12:45:00', 1);

-- Adres Verisi 4
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Stavanger Yolu 234', N'Stavanger', N'34567', N'Norveç', '2023-08-30 14:15:00', 1);

-- Adres Verisi 5
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Tromsø Caddesi 567', N'Tromsø', N'45678', N'Norveç', '2023-08-30 15:30:00', 1);

-- Adres Verisi 6
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Bodø Yolu 789', N'Bodø', N'56789', N'Norveç', '2023-08-30 16:45:00', 1);

-- Adres Verisi 7
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Ålesund Caddesi 234', N'Ålesund', N'67890', N'Norveç', '2023-08-30 18:00:00', 1);

-- Adres Verisi 8
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Molde Yolu 567', N'Molde', N'78901', N'Norveç', '2023-08-30 19:15:00', 1);

-- Adres Verisi 9
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Kristiansand Caddesi 890', N'Kristiansand', N'89012', N'Norveç', '2023-08-30 20:30:00', 1);

-- Adres Verisi 10
INSERT INTO Addresses (Street, City, PostalCode, Country, CreatedAt, Status)
VALUES (N'Fredrikstad Yolu 123', N'Fredrikstad', N'90123', N'Norveç', '2023-08-30 21:45:00', 1);
