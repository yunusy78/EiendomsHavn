SELECT Roles.RoleName FROM Roles INNER JOIN UserRoles ON Roles.RoleId = UserRoles.RoleId 
INNER JOIN Users ON Users.Id = UserRoles.UserId WHERE Users.Email = 'yunusy@gmail.com'