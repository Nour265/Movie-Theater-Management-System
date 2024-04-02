CREATE TABLE [dbo].[TakesPlaceIn] (
    [Number]         INT      NOT NULL,
    [ID]             INT      NOT NULL,
    [Time]           DATETIME NOT NULL,
    [AvailableSeats] INT      NULL,
    [EndingTime] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([Number] ASC, [ID] ASC, [Time] ASC),
    CONSTRAINT [Auditorium_TakesPlaceIn_Number] FOREIGN KEY ([Number]) REFERENCES [dbo].[Auditorium] ([Number]),
    CONSTRAINT [Movie_TakesPlaceIn_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[Movie] ([ID])
);

