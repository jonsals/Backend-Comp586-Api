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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201085419_Initial')
BEGIN
    CREATE TABLE [AlbumInfos] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [RegularPrice] float NOT NULL,
        [Details] nvarchar(max) NULL,
        CONSTRAINT [PK_AlbumInfos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201085419_Initial')
BEGIN
    CREATE TABLE [AlbumImages] (
        [Id] int NOT NULL IDENTITY,
        [AlbumId] int NOT NULL,
        [AlbumImageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_AlbumImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AlbumImages_AlbumInfos_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [AlbumInfos] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201085419_Initial')
BEGIN
    CREATE INDEX [IX_HotelRoomImages_RoomId] ON [AlbumImages] ([AlbumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201085419_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201085419_Initial', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201201729_Tweaks')
BEGIN
    EXEC sp_rename N'[AlbumImages].[IX_HotelRoomImages_RoomId]', N'IX_AlbumImage_AlbumId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201201729_Tweaks')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201201729_Tweaks', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201203300_ImageFix')
BEGIN
    ALTER TABLE [AlbumImages] ADD [ImageData] varbinary(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201203300_ImageFix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201203300_ImageFix', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201224452_practice')
BEGIN
    CREATE TABLE [PeopleName] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_PeopleName] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201224452_practice')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201224452_practice', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201233400_addedImage')
BEGIN
    ALTER TABLE [AlbumInfos] ADD [ImageData] varbinary(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201233400_addedImage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201233400_addedImage', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202063524_ChangeTable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AlbumInfos]') AND [c].[name] = N'ImageData');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AlbumInfos] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AlbumInfos] DROP COLUMN [ImageData];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202063524_ChangeTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211202063524_ChangeTable', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202220949_practicePeopleCon')
BEGIN
    ALTER TABLE [AlbumImages] DROP CONSTRAINT [FK_AlbumImages_AlbumInfos_AlbumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202220949_practicePeopleCon')
BEGIN
    EXEC sp_rename N'[AlbumImages].[AlbumId]', N'AlbumImageId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202220949_practicePeopleCon')
BEGIN
    ALTER TABLE [PeopleName] ADD [LastName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202220949_practicePeopleCon')
BEGIN
    ALTER TABLE [PeopleName] ADD [RandomId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202220949_practicePeopleCon')
BEGIN
    ALTER TABLE [AlbumImages] ADD CONSTRAINT [FK_AlbumImages_AlbumInfos_AlbumImageId] FOREIGN KEY ([AlbumImageId]) REFERENCES [AlbumInfos] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211202220949_practicePeopleCon')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211202220949_practicePeopleCon', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211203075601_PeopleVm')
BEGIN
    ALTER TABLE [PeopleName] ADD [Image] varbinary(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211203075601_PeopleVm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211203075601_PeopleVm', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211203205105_practiceWithAnotherModel')
BEGIN
    CREATE TABLE [SomethingPeoples] (
        [Id] int NOT NULL IDENTITY,
        [FavoriteFood] nvarchar(max) NOT NULL,
        [Age] float NOT NULL,
        [DifferentSize] int NOT NULL,
        [PersonId] int NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        CONSTRAINT [PK_SomethingPeoples] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SomethingPeoples_PeopleName_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [PeopleName] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211203205105_practiceWithAnotherModel')
BEGIN
    CREATE INDEX [IX_SomethingPeoples_PersonId] ON [SomethingPeoples] ([PersonId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211203205105_practiceWithAnotherModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211203205105_practiceWithAnotherModel', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204045829_initial1')
BEGIN
    ALTER TABLE [SomethingPeoples] DROP CONSTRAINT [FK_SomethingPeoples_PeopleName_PersonId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204045829_initial1')
BEGIN
    DROP INDEX [IX_SomethingPeoples_PersonId] ON [SomethingPeoples];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204045829_initial1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211204045829_initial1', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204072516_SpICollection')
BEGIN
    ALTER TABLE [PeopleName] ADD [PersonId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204072516_SpICollection')
BEGIN
    CREATE INDEX [IX_PeopleName_PersonId] ON [PeopleName] ([PersonId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204072516_SpICollection')
BEGIN
    ALTER TABLE [PeopleName] ADD CONSTRAINT [FK_PeopleName_SomethingPeoples_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [SomethingPeoples] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211204072516_SpICollection')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211204072516_SpICollection', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211207002124_fixedAge')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211207002124_fixedAge', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211207002455_fixedAge1')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SomethingPeoples]') AND [c].[name] = N'Age');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [SomethingPeoples] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [SomethingPeoples] ALTER COLUMN [Age] int NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211207002455_fixedAge1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211207002455_fixedAge1', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211210191759_PeopleImage')
BEGIN
    CREATE TABLE [PeopleImages] (
        [ImageId] int NOT NULL IDENTITY,
        [Title] nvarchar(50) NULL,
        [ImageName] nvarchar(100) NULL,
        CONSTRAINT [PK_PeopleImages] PRIMARY KEY ([ImageId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211210191759_PeopleImage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211210191759_PeopleImage', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211210201124_ImageEdit')
BEGIN
    ALTER TABLE [PeopleImages] ADD [Image] varbinary(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211210201124_ImageEdit')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211210201124_ImageEdit', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211211014335_moreImage')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PeopleImages]') AND [c].[name] = N'Image');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [PeopleImages] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [PeopleImages] DROP COLUMN [Image];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211211014335_moreImage')
BEGIN
    ALTER TABLE [PeopleImages] ADD [Occupancy] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211211014335_moreImage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211211014335_moreImage', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212042909_Song')
BEGIN
    ALTER TABLE [SomethingPeoples] ADD [AlbumId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212042909_Song')
BEGIN
    CREATE TABLE [SongInfos] (
        [SongId] int NOT NULL IDENTITY,
        [SongName] nvarchar(max) NOT NULL,
        [Minute] int NOT NULL,
        [Seconds] int NOT NULL,
        [AlbumId] int NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        CONSTRAINT [PK_SongInfos] PRIMARY KEY ([SongId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212042909_Song')
BEGIN
    CREATE INDEX [IX_SomethingPeoples_AlbumId] ON [SomethingPeoples] ([AlbumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212042909_Song')
BEGIN
    ALTER TABLE [SomethingPeoples] ADD CONSTRAINT [FK_SomethingPeoples_SongInfos_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [SongInfos] ([SongId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212042909_Song')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211212042909_Song', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    ALTER TABLE [AlbumImages] DROP CONSTRAINT [FK_AlbumImages_AlbumInfos_AlbumImageId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    DROP INDEX [IX_AlbumImage_AlbumId] ON [AlbumImages];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AlbumInfos]') AND [c].[name] = N'Details');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AlbumInfos] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [AlbumInfos] DROP COLUMN [Details];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    ALTER TABLE [AlbumInfos] ADD [ImageName] nvarchar(100) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    ALTER TABLE [AlbumInfos] ADD [TotalNumberOfSongs] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    ALTER TABLE [AlbumImages] ADD [AlbumId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    CREATE INDEX [IX_AlbumImages_AlbumId] ON [AlbumImages] ([AlbumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    ALTER TABLE [AlbumImages] ADD CONSTRAINT [FK_AlbumImages_AlbumInfos_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [AlbumInfos] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212044237_EditedAlbumInfo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211212044237_EditedAlbumInfo', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212052356_AlbumChanges')
BEGIN
    DROP TABLE [AlbumImages];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212052356_AlbumChanges')
BEGIN
    ALTER TABLE [AlbumInfos] ADD [ArtistId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212052356_AlbumChanges')
BEGIN
    ALTER TABLE [PeopleName] ADD CONSTRAINT [FK_PeopleName_AlbumInfos_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [AlbumInfos] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212052356_AlbumChanges')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211212052356_AlbumChanges', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213004629_ArtistModel')
BEGIN
    CREATE TABLE [ArtistInfos] (
        [ArtistId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Genre] nvarchar(max) NULL,
        [ImageName] nvarchar(100) NULL,
        CONSTRAINT [PK_ArtistInfos] PRIMARY KEY ([ArtistId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213004629_ArtistModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211213004629_ArtistModel', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213005227_AlbumIcollectionChange')
BEGIN
    ALTER TABLE [PeopleName] DROP CONSTRAINT [FK_PeopleName_AlbumInfos_PersonId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213005227_AlbumIcollectionChange')
BEGIN
    ALTER TABLE [ArtistInfos] ADD [PersonId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213005227_AlbumIcollectionChange')
BEGIN
    CREATE INDEX [IX_ArtistInfos_PersonId] ON [ArtistInfos] ([PersonId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213005227_AlbumIcollectionChange')
BEGIN
    ALTER TABLE [ArtistInfos] ADD CONSTRAINT [FK_ArtistInfos_AlbumInfos_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [AlbumInfos] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211213005227_AlbumIcollectionChange')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211213005227_AlbumIcollectionChange', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    ALTER TABLE [SomethingPeoples] DROP CONSTRAINT [FK_SomethingPeoples_SongInfos_AlbumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    DROP INDEX [IX_SomethingPeoples_AlbumId] ON [SomethingPeoples];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SomethingPeoples]') AND [c].[name] = N'AlbumId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [SomethingPeoples] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [SomethingPeoples] DROP COLUMN [AlbumId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    ALTER TABLE [AlbumInfos] ADD [AlbumId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    CREATE INDEX [IX_AlbumInfos_AlbumId] ON [AlbumInfos] ([AlbumId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    ALTER TABLE [AlbumInfos] ADD CONSTRAINT [FK_AlbumInfos_SongInfos_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [SongInfos] ([SongId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211215003356_ChangeId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211215003356_ChangeId', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220184910_changedImageAlbum')
BEGIN
    DROP TABLE [PeopleImages];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220184910_changedImageAlbum')
BEGIN
    DROP TABLE [PeopleName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220184910_changedImageAlbum')
BEGIN
    DROP TABLE [SomethingPeoples];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220184910_changedImageAlbum')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AlbumInfos]') AND [c].[name] = N'ImageName');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AlbumInfos] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [AlbumInfos] DROP COLUMN [ImageName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220184910_changedImageAlbum')
BEGIN
    ALTER TABLE [AlbumInfos] ADD [ImageUrl] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220184910_changedImageAlbum')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211220184910_changedImageAlbum', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211220194735_somethingChanged')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211220194735_somethingChanged', N'5.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211221014837_artistDateAdded')
BEGIN
    ALTER TABLE [ArtistInfos] ADD [DateCreated] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211221014837_artistDateAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211221014837_artistDateAdded', N'5.0.12');
END;
GO

COMMIT;
GO

