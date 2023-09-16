CREATE TABLE ForgotPasswords
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    [UserId] NVARCHAR (256) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(255),
    ResetToken NVARCHAR(255),
    ResetTokenExpiry DATETIME
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
);
