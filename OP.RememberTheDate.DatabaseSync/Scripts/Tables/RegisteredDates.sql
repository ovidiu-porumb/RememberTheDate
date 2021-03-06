﻿
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RegisteredDates](
    [ID] [BIGINT] IDENTITY(1,1) NOT NULL,
    [Date] [DATETIME] NULL,
    [EventToMark] [NVARCHAR](250) NULL,
    CONSTRAINT [PK_RegisteredDates] PRIMARY KEY CLUSTERED ( [ID] ASC)
)

GO