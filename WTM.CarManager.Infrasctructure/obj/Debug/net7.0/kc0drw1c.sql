IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Marcas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(150) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230902234726_BeginTable', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Marcas]') AND [c].[name] = N'Status');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Marcas] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Marcas] ALTER COLUMN [Status] nvarchar(30) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230902234910_BeginTable2', N'7.0.10');
GO

COMMIT;
GO

