CREATE TABLE [dbo].[Meetings] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [personObserved]      VARCHAR (100) NOT NULL,
    [dateOfDiscussion]    VARCHAR (50)  NOT NULL,
    [location]            VARCHAR (100) NOT NULL,
    [colleagues]          VARCHAR (500) NOT NULL,
    [subjectOfDiscussion] VARCHAR (200) NOT NULL,
    [outcome]             VARCHAR (500) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

