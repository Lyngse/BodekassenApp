
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2017 17:17:49
-- Generated from EDMX file: C:\Users\Søren\Desktop\Projekter\BodekassenApp\Bodekassen\Bodekassen\DB\BodekassenDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bodekassenDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FineFineType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FineSet] DROP CONSTRAINT [FK_FineFineType];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerMatch_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerMatch] DROP CONSTRAINT [FK_PlayerMatch_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerMatch_Match]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerMatch] DROP CONSTRAINT [FK_PlayerMatch_Match];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamFineType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FineTypeSet] DROP CONSTRAINT [FK_TeamFineType];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchGoal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GoalSet] DROP CONSTRAINT [FK_MatchGoal];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerGoal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GoalSet] DROP CONSTRAINT [FK_PlayerGoal];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchMOTM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchSet] DROP CONSTRAINT [FK_MatchMOTM];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerMOTM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MOTMSet] DROP CONSTRAINT [FK_PlayerMOTM];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchSet] DROP CONSTRAINT [FK_TeamMatch];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerSet] DROP CONSTRAINT [FK_TeamPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerFine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FineSet] DROP CONSTRAINT [FK_PlayerFine];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerVote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VoteSet] DROP CONSTRAINT [FK_PlayerVote];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchVote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VoteSet] DROP CONSTRAINT [FK_MatchVote];
GO
IF OBJECT_ID(N'[dbo].[FK_SeasonTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeasonSet] DROP CONSTRAINT [FK_SeasonTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_SeasonMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchSet] DROP CONSTRAINT [FK_SeasonMatch];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamSet] DROP CONSTRAINT [FK_UserTeam];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TeamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamSet];
GO
IF OBJECT_ID(N'[dbo].[PlayerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet];
GO
IF OBJECT_ID(N'[dbo].[FineTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FineTypeSet];
GO
IF OBJECT_ID(N'[dbo].[FineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FineSet];
GO
IF OBJECT_ID(N'[dbo].[MatchSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MatchSet];
GO
IF OBJECT_ID(N'[dbo].[GoalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GoalSet];
GO
IF OBJECT_ID(N'[dbo].[MOTMSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MOTMSet];
GO
IF OBJECT_ID(N'[dbo].[VoteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoteSet];
GO
IF OBJECT_ID(N'[dbo].[SeasonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeasonSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PlayerMatch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerMatch];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TeamSet'
CREATE TABLE [dbo].[TeamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FineTotal] int  NOT NULL,
    [FineDeposited] int  NOT NULL,
    [CasesOfBeerTotal] int  NOT NULL,
    [CasesOfBeerDeposited] int  NOT NULL,
    [CurrentSeasonId] int  NOT NULL,
    [ConnectionCode] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FineTotal] int  NOT NULL,
    [FineDeposited] int  NOT NULL,
    [CasesOfBeerTotal] int  NOT NULL,
    [CasesOfBeerDepostited] int  NOT NULL,
    [TeamId] int  NOT NULL,
    [SeasonId] int  NOT NULL
);
GO

-- Creating table 'FineTypeSet'
CREATE TABLE [dbo].[FineTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DefaultPrice] int  NULL,
    [IsDeleted] bit  NOT NULL,
    [IsCaseOfBeer] bit  NOT NULL,
    [IsDeposit] bit  NOT NULL,
    [TeamId] int  NOT NULL
);
GO

-- Creating table 'FineSet'
CREATE TABLE [dbo].[FineSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Price] int  NOT NULL,
    [PlayerId] int  NOT NULL,
    [FineType_Id] int  NOT NULL
);
GO

-- Creating table 'MatchSet'
CREATE TABLE [dbo].[MatchSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OpposingTeam] nvarchar(max)  NOT NULL,
    [GoalsFor] int  NOT NULL,
    [GoalsAgainst] int  NOT NULL,
    [IsHomeMatch] bit  NOT NULL,
    [Date] datetime  NOT NULL,
    [TeamId] int  NOT NULL,
    [SeasonId] int  NOT NULL,
    [SeasonId1] int  NOT NULL,
    [MOTM_Id] int  NOT NULL
);
GO

-- Creating table 'GoalSet'
CREATE TABLE [dbo].[GoalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MatchId] int  NOT NULL,
    [PlayerId] int  NOT NULL
);
GO

-- Creating table 'MOTMSet'
CREATE TABLE [dbo].[MOTMSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlayerId] int  NOT NULL,
    [MatchId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VoteSet'
CREATE TABLE [dbo].[VoteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlayerId] int  NOT NULL,
    [MatchId] int  NOT NULL
);
GO

-- Creating table 'SeasonSet'
CREATE TABLE [dbo].[SeasonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeamId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FacebookId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlayerMatch'
CREATE TABLE [dbo].[PlayerMatch] (
    [Players_Id] int  NOT NULL,
    [Matches_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TeamSet'
ALTER TABLE [dbo].[TeamSet]
ADD CONSTRAINT [PK_TeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FineTypeSet'
ALTER TABLE [dbo].[FineTypeSet]
ADD CONSTRAINT [PK_FineTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FineSet'
ALTER TABLE [dbo].[FineSet]
ADD CONSTRAINT [PK_FineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MatchSet'
ALTER TABLE [dbo].[MatchSet]
ADD CONSTRAINT [PK_MatchSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GoalSet'
ALTER TABLE [dbo].[GoalSet]
ADD CONSTRAINT [PK_GoalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MOTMSet'
ALTER TABLE [dbo].[MOTMSet]
ADD CONSTRAINT [PK_MOTMSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VoteSet'
ALTER TABLE [dbo].[VoteSet]
ADD CONSTRAINT [PK_VoteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SeasonSet'
ALTER TABLE [dbo].[SeasonSet]
ADD CONSTRAINT [PK_SeasonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Players_Id], [Matches_Id] in table 'PlayerMatch'
ALTER TABLE [dbo].[PlayerMatch]
ADD CONSTRAINT [PK_PlayerMatch]
    PRIMARY KEY CLUSTERED ([Players_Id], [Matches_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FineType_Id] in table 'FineSet'
ALTER TABLE [dbo].[FineSet]
ADD CONSTRAINT [FK_FineFineType]
    FOREIGN KEY ([FineType_Id])
    REFERENCES [dbo].[FineTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FineFineType'
CREATE INDEX [IX_FK_FineFineType]
ON [dbo].[FineSet]
    ([FineType_Id]);
GO

-- Creating foreign key on [Players_Id] in table 'PlayerMatch'
ALTER TABLE [dbo].[PlayerMatch]
ADD CONSTRAINT [FK_PlayerMatch_Player]
    FOREIGN KEY ([Players_Id])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Matches_Id] in table 'PlayerMatch'
ALTER TABLE [dbo].[PlayerMatch]
ADD CONSTRAINT [FK_PlayerMatch_Match]
    FOREIGN KEY ([Matches_Id])
    REFERENCES [dbo].[MatchSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerMatch_Match'
CREATE INDEX [IX_FK_PlayerMatch_Match]
ON [dbo].[PlayerMatch]
    ([Matches_Id]);
GO

-- Creating foreign key on [TeamId] in table 'FineTypeSet'
ALTER TABLE [dbo].[FineTypeSet]
ADD CONSTRAINT [FK_TeamFineType]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamFineType'
CREATE INDEX [IX_FK_TeamFineType]
ON [dbo].[FineTypeSet]
    ([TeamId]);
GO

-- Creating foreign key on [MatchId] in table 'GoalSet'
ALTER TABLE [dbo].[GoalSet]
ADD CONSTRAINT [FK_MatchGoal]
    FOREIGN KEY ([MatchId])
    REFERENCES [dbo].[MatchSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchGoal'
CREATE INDEX [IX_FK_MatchGoal]
ON [dbo].[GoalSet]
    ([MatchId]);
GO

-- Creating foreign key on [PlayerId] in table 'GoalSet'
ALTER TABLE [dbo].[GoalSet]
ADD CONSTRAINT [FK_PlayerGoal]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerGoal'
CREATE INDEX [IX_FK_PlayerGoal]
ON [dbo].[GoalSet]
    ([PlayerId]);
GO

-- Creating foreign key on [MOTM_Id] in table 'MatchSet'
ALTER TABLE [dbo].[MatchSet]
ADD CONSTRAINT [FK_MatchMOTM]
    FOREIGN KEY ([MOTM_Id])
    REFERENCES [dbo].[MOTMSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchMOTM'
CREATE INDEX [IX_FK_MatchMOTM]
ON [dbo].[MatchSet]
    ([MOTM_Id]);
GO

-- Creating foreign key on [PlayerId] in table 'MOTMSet'
ALTER TABLE [dbo].[MOTMSet]
ADD CONSTRAINT [FK_PlayerMOTM]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerMOTM'
CREATE INDEX [IX_FK_PlayerMOTM]
ON [dbo].[MOTMSet]
    ([PlayerId]);
GO

-- Creating foreign key on [TeamId] in table 'MatchSet'
ALTER TABLE [dbo].[MatchSet]
ADD CONSTRAINT [FK_TeamMatch]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamMatch'
CREATE INDEX [IX_FK_TeamMatch]
ON [dbo].[MatchSet]
    ([TeamId]);
GO

-- Creating foreign key on [TeamId] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [FK_TeamPlayer]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayer'
CREATE INDEX [IX_FK_TeamPlayer]
ON [dbo].[PlayerSet]
    ([TeamId]);
GO

-- Creating foreign key on [PlayerId] in table 'FineSet'
ALTER TABLE [dbo].[FineSet]
ADD CONSTRAINT [FK_PlayerFine]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerFine'
CREATE INDEX [IX_FK_PlayerFine]
ON [dbo].[FineSet]
    ([PlayerId]);
GO

-- Creating foreign key on [PlayerId] in table 'VoteSet'
ALTER TABLE [dbo].[VoteSet]
ADD CONSTRAINT [FK_PlayerVote]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerVote'
CREATE INDEX [IX_FK_PlayerVote]
ON [dbo].[VoteSet]
    ([PlayerId]);
GO

-- Creating foreign key on [MatchId] in table 'VoteSet'
ALTER TABLE [dbo].[VoteSet]
ADD CONSTRAINT [FK_MatchVote]
    FOREIGN KEY ([MatchId])
    REFERENCES [dbo].[MatchSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchVote'
CREATE INDEX [IX_FK_MatchVote]
ON [dbo].[VoteSet]
    ([MatchId]);
GO

-- Creating foreign key on [Team_Id] in table 'SeasonSet'
ALTER TABLE [dbo].[SeasonSet]
ADD CONSTRAINT [FK_SeasonTeam]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeasonTeam'
CREATE INDEX [IX_FK_SeasonTeam]
ON [dbo].[SeasonSet]
    ([Team_Id]);
GO

-- Creating foreign key on [SeasonId1] in table 'MatchSet'
ALTER TABLE [dbo].[MatchSet]
ADD CONSTRAINT [FK_SeasonMatch]
    FOREIGN KEY ([SeasonId1])
    REFERENCES [dbo].[SeasonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeasonMatch'
CREATE INDEX [IX_FK_SeasonMatch]
ON [dbo].[MatchSet]
    ([SeasonId1]);
GO

-- Creating foreign key on [UserId] in table 'TeamSet'
ALTER TABLE [dbo].[TeamSet]
ADD CONSTRAINT [FK_UserTeam]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTeam'
CREATE INDEX [IX_FK_UserTeam]
ON [dbo].[TeamSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------