CREATE TABLE [dbo].[Categories] (
    [CategoryId]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]        NVARCHAR (MAX)   NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

CREATE TABLE [dbo].[Products] (
    [ProductID]       UNIQUEIDENTIFIER           DEFAULT (newid()) NOT NULL,
    [ProductName]     NVARCHAR (40) NOT NULL,
    [CategoryID]     UNIQUEIDENTIFIER           NULL,
    [PurchasePrice]       MONEY         CONSTRAINT [DF_Products_PurchasePrice] DEFAULT ((0)) NULL,
    [UnitPrice]       MONEY         CONSTRAINT [DF_Products_UnitPrice] DEFAULT ((0)) NULL,
    [UnitsInStock]    SMALLINT      CONSTRAINT [DF_Products_UnitsInStock] DEFAULT ((0)) NULL,
    [Status]    BIT                 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]),
    CONSTRAINT [CK_Products_UnitPrice] CHECK ([UnitPrice]>=(0)),
    CONSTRAINT [CK_UnitsInStock] CHECK ([UnitsInStock]>=(0)),
    
);


GO
CREATE NONCLUSTERED INDEX [CategoriesProducts]
    ON [dbo].[Products]([CategoryID] ASC);


GO
CREATE NONCLUSTERED INDEX [CategoryID]
    ON [dbo].[Products]([CategoryID] ASC);


GO
CREATE NONCLUSTERED INDEX [ProductName]
    ON [dbo].[Products]([ProductName] ASC);




    CREATE TABLE [dbo].[Employees] (
    [EmployeeID]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [LastName]        NVARCHAR (20)  NOT NULL,
    [FirstName]       NVARCHAR (10)  NOT NULL,
    [Email]           NVARCHAR (30)  NULL,
    [PhoneNumber]     NVARCHAR (25)  NULL,
    [PhotoPath]       NVARCHAR (255) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),

);


GO
CREATE NONCLUSTERED INDEX [LastName]
    ON [dbo].[Employees]([LastName] ASC);






    CREATE TABLE [dbo].[Customers] (
    [CustomerID]    UNIQUEIDENTIFIER           DEFAULT (newid()) NOT NULL,
    [CompanyName]  NVARCHAR (40) NOT NULL,
    [ContactName]  NVARCHAR (30) NULL,
    [ContactTitle] NVARCHAR (30) NULL,
    [Address]      NVARCHAR (60) NULL,
    [City]         NVARCHAR (15) NULL,
    [Region]       NVARCHAR (15) NULL,
    [PostalCode]   NVARCHAR (10) NULL,
    [Country]      NVARCHAR (15) NULL,
    [Phone]        NVARCHAR (24) NULL,
    [Bank]          NVARCHAR (50) NULL,
    [Email]          NVARCHAR (50) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [City]
    ON [dbo].[Customers]([City] ASC);


GO
CREATE NONCLUSTERED INDEX [CompanyName]
    ON [dbo].[Customers]([CompanyName] ASC);


GO
CREATE NONCLUSTERED INDEX [PostalCode]
    ON [dbo].[Customers]([PostalCode] ASC);


    CREATE TABLE [dbo].[Notifications] (
    [NotificationID]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Title]        NVARCHAR (20)  NOT NULL,
    [Content]       NVARCHAR (10)  NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationID] ASC),
);

CREATE TABLE [dbo].[Departments] (
    [DepartmentID]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]        NVARCHAR (30)  NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentID] ASC),
);

CREATE TABLE [dbo].[TeknicService] (
    [ProcessID]      UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    [ProductID]      UNIQUEIDENTIFIER NOT NULL,
    [CustomerID]     UNIQUEIDENTIFIER NOT NULL,
    [EmployeeID]     UNIQUEIDENTIFIER NOT NULL,
    [TheArrivalDate] SMALLDATETIME NOT NULL DEFAULT GETDATE(),
    [TheReleaseDate] SMALLDATETIME NOT NULL,
    [Status]         BIT NOT NULL,
    CONSTRAINT [PK_TeknicService] PRIMARY KEY CLUSTERED ([ProcessID] ASC),
    CONSTRAINT [FK_TeknicService_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_TeknicService_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]),
    CONSTRAINT [FK_TeknicService_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID])
);

CREATE TABLE [dbo].[FaultDetail] (
    [FaultDetailID] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    [ProcessID] UNIQUEIDENTIFIER  NOT NULL,
    [Fault] VARCHAR(50) NOT NULL,
    [Detail] VARCHAR(255) NOT NULL,
    [Description] VARCHAR(255) NOT NULL,
    [ListPrice] DECIMAL(10, 2), 
    [NetPrice] DECIMAL(10, 2),  
    CONSTRAINT [PK_FaultDetail] PRIMARY KEY CLUSTERED ([FaultDetailID] ASC), -- [FaultDetailID] düzeltildi
    CONSTRAINT [FK_FaultDetail_TeknicService] FOREIGN KEY ([ProcessID]) REFERENCES [dbo].[TeknicService] ([ProcessID])
);


CREATE TABLE [dbo].[ProductMovement] (
    [MovementID]      UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    [ProductID]      UNIQUEIDENTIFIER NOT NULL,
    [CustomerID]     UNIQUEIDENTIFIER NOT NULL,
    [EmployeeID]     UNIQUEIDENTIFIER NOT NULL,
    [MovementType] VARCHAR(20) NOT NULL,
    [MovementDate] DATETIME DEFAULT GETDATE(),
    [Quantity] Smallint NOT NULL,
    [Price]          DECIMAL(10, 2) not null,
    CONSTRAINT [PK_ProductMovement] PRIMARY KEY CLUSTERED ([MovementID] ASC),
    CONSTRAINT [FK_ProductMovement_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_ProductMovement_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]),
    CONSTRAINT [FK_ProductMovement_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID])
);


CREATE TABLE [dbo].[Invoice] (
    [InvoiceID] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    [CustomerID] UNIQUEIDENTIFIER NOT NULL,
    [EmployeeID] UNIQUEIDENTIFIER not null,
    [InvoiceDate] DATE NOT NULL,
    [DueDate] DATE NOT NULL,
    [DueTime] TIME not null,
    [TotalAmount] DECIMAL(10, 2) NOT NULL,
    [IsPaid] BIT NOT NULL,
    [SerialNumber] VARCHAR(20) NOT NULL,
    [SequenceNumber] INT NOT NULL,
    [TaxOffice] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(255),
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([InvoiceID] ASC),
    CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]),
     CONSTRAINT [FK_Invoice_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID])
);



CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailId]      UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    [ProductId]      UNIQUEIDENTIFIER NOT NULL,
    [InvoiceID] UNIQUEIDENTIFIER  NOT NULL,
    [Quantity] Smallint NOT NULL,
    [UnitPrice]          DECIMAL(10, 2) not null,
    [Price]          DECIMAL(10, 2) not null,

    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderDetailId] ASC),
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_OrderDetails_Invoice] FOREIGN KEY ([InvoiceID]) REFERENCES [dbo].[Invoice] ([InvoiceID]),
);

CREATE TABLE [dbo].[Admin] (
    [AdminID]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserName]        NVARCHAR (30)  NOT NULL,
    [Password]       NVARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED ([AdminID] ASC),
);

CREATE TABLE [dbo].[Tracking] (
    [TrackingID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ProcessID] UNIQUEIDENTIFIER NOT NULL,
    [Status] VARCHAR(50) NOT NULL,
    [Date] DATETIME NOT NULL,
    [Description] VARCHAR(255),
    CONSTRAINT [PK_Tracking] PRIMARY KEY CLUSTERED ([TrackingID] ASC),
    CONSTRAINT [FK_Tracking_TeknicService] FOREIGN KEY ([ProcessID]) REFERENCES [dbo].[TeknicService] ([ProcessID])
);


CREATE TABLE [dbo].[Expense] (
    [ExpenseID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ExpenseDate] DATE NOT NULL,
    [ExpenseCategory] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(255),
    [Amount] DECIMAL(10, 2) NOT NULL,
    [PaymentMethod] VARCHAR(50),
    [Payee] VARCHAR(100),
    [ReceiptNumber] VARCHAR(20),
    [Notes] VARCHAR(255)
     CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED ([ExpenseID] ASC),
);
