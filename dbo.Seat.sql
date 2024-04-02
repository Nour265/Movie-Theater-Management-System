CREATE TABLE [dbo].[Seat] (
    [ID]        INT      NOT NULL,
    [SSN]       INT      NULL,
    [NUMBER]    INT      NULL,
    [MID]       INT      NULL,
    [#Row]      INT      NULL,
    [#Column]   INT      NULL,
    [StartTime] DATETIME NULL,
    [EndTime]   DATETIME NULL,
    [Price]     INT      NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Person_Seat_SSN] FOREIGN KEY ([SSN]) REFERENCES [dbo].[Person] ([SSN]),
    CONSTRAINT [Auditorium_Seat_Number] FOREIGN KEY ([NUMBER]) REFERENCES [dbo].[Auditorium] ([Number]),
    CONSTRAINT [Movie_Seat_MID] FOREIGN KEY ([MID]) REFERENCES [dbo].[Movie] ([ID])
);

