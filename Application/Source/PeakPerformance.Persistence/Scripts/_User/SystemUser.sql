SET IDENTITY_INSERT [Users] ON;

INSERT INTO [dbo].[Users]
    ([Id]
    ,[FirstName]
    ,[MiddleName]
    ,[LastName]
    ,[Username]
    ,[Email]
    ,[Password]
    ,[DateOfBirth]
    ,[PhoneNumber]
    ,[CreatedOn]
    ,[ModifiedOn]
    ,[ModifiedBy]
    ,[DeletedOn]
    ,[DeletedBy]
    ,[IsActive]
    ,[ReceiveAppNews]
    ,[Description]
    ,[ProfilePicture]
    ,[CreatedBy])
VALUES
    (-1
    ,'Peak'
    ,'Performance'
    ,'Admin'
    ,'PeakPerformance'
    ,'peakperformance690@gmail.com'
    ,'$2a$12$KhXkK8rfHcTA3WiOD6lnde.yA.MO5/T9OsFAak9CmWU7dmQfyrLbu'
    ,'2002-10-10'
    ,'000-000-0000'
    ,CURRENT_TIMESTAMP
    ,CURRENT_TIMESTAMP
    ,-1
    ,NULL
    ,NULL
    ,1
    ,0
    ,NULL
    ,NULL
    ,-1);

SET IDENTITY_INSERT [Users] OFF;

-- User Roles

INSERT INTO [dbo].[UserRoles]
    ([UserId]
    ,[RoleId]
    ,[CreatedOn]
    ,[ModifiedOn]
    ,[ModifiedBy]
    ,[DeletedOn]
    ,[DeletedBy]
    ,[IsActive]
    ,[CreatedBy])
VALUES
    (-1
    ,1
    ,CURRENT_TIMESTAMP
    ,CURRENT_TIMESTAMP
    ,-1
    ,NULL
    ,NULL
    ,1
    ,-1);
