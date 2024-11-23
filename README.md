# Twitter
![Beige Company Organizational Chart Graph](https://github.com/user-attachments/assets/af9fdd75-0fbd-4d25-a684-8598ea7caae5)
Creating a User Service in C# and SQL Server
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARBINARY(MAX) NOT NULL,
    Salt VARBINARY(MAX) NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Posts (
    PostId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
