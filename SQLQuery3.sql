CREATE TRIGGER trg_AfterInsertUser
ON Users
AFTER INSERT
AS
BEGIN
    -- Yeni eklenen kullanıcının UserId'sini alın
    DECLARE @UserId NVARCHAR(256)
    SELECT @UserId = Id FROM INSERTED

    -- "user" rolünün RoleId'sini alın
    DECLARE @RoleId NVARCHAR(256)
    SELECT @RoleId = RoleId FROM Roles WHERE RoleName = 'user'

    -- Eğer "user" rolü bulunduysa ve UserId ve RoleId değerleri mevcutsa
    IF @RoleId IS NOT NULL AND @UserId IS NOT NULL
    BEGIN
        -- Kullanıcıyı "user" rolüne ekleyin
        INSERT INTO UserRoles (UserId, RoleId) VALUES (@UserId, @RoleId)
    END
END;



