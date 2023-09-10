CREATE TABLE [dbo].[Users] (
    [Id]             NVARCHAR(256) DEFAULT (newid()) PRIMARY KEY,
    [Email]          NVARCHAR(256) NOT NULL UNIQUE,
    [UserName]       AS (UPPER([Email])) PERSISTED UNIQUE, -- Kullanıcı adını e-posta adresinden oluşturur ve büyük harfle saklar
    [PasswordHash]   NVARCHAR(255) NOT NULL
);
CREATE TABLE [dbo].[Roles] (
    [RoleId]   NVARCHAR(256) DEFAULT (newid()) PRIMARY KEY,
    [RoleName] NVARCHAR(256) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[UserRoles] (
    [UserId]  NVARCHAR(256) NOT NULL,
    [RoleId]  NVARCHAR(256) NOT NULL,
    PRIMARY KEY ([UserId], [RoleId]),
    FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
    FOREIGN KEY ([RoleId]) REFERENCES [Roles]([RoleId])
);

