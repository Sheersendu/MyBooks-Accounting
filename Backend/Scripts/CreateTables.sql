IF OBJECT_ID('[dbo].[Expert]') IS NULL
BEGIN
CREATE TABLE
    [dbo].[Expert]
(
    [EXP_PK] [uniqueidentifier] NOT NULL,
    [EXP_ID] [int] NOT NULL,
    [EXP_CreatedUtc] [datetime] NOT NULL,
    CONSTRAINT
    [PK_Expert] PRIMARY KEY CLUSTERED ([EXP_PK] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
    ON [PRIMARY]
    )
    ON [PRIMARY];
END

IF OBJECT_ID('[dbo].[Customer]') IS NULL
BEGIN
CREATE TABLE
    [dbo].[Customer]
(
    [CUST_PK] [uniqueidentifier] NOT NULL,
    [CUST_ID] [int] NOT NULL,
    [CUST_CreatedUtc] [datetime] NOT NULL,
     CONSTRAINT
    [PK_Customer] PRIMARY KEY CLUSTERED ([CUST_PK] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
    ON [PRIMARY]
    )
    ON [PRIMARY];
END

IF OBJECT_ID('[dbo].[Request]') IS NULL
BEGIN
CREATE TABLE
    [dbo].[Request]
(
    [REQ_PK] [uniqueidentifier] NOT NULL,
    [REQ_ID] [int] NOT NULL,
    [REQ_CreatedUtc] [datetime] NOT NULL,
     CONSTRAINT
    [PK_Request] PRIMARY KEY CLUSTERED ([REQ_PK] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
    ON [PRIMARY]
    )
    ON [PRIMARY];
END

IF OBJECT_ID('[dbo].[CustomerRequest]') IS NULL
BEGIN
CREATE TABLE
    [dbo].[CustomerRequest]
(
    [CUSTREQ_PK] [uniqueidentifier] NOT NULL,
    [CUSTREQ_CUST_ID] [uniqueidentifier] NOT NULL,
    [CUSTREQ_REQ_ID] [uniqueidentifier] NOT NULL,
    [CUSTREQ_TASK_ID] [int] NOT NULL,
    [CUSTREQ_STATUS] [bit] NOT NULL,
    [CUSTREQ_CreatedUtc] [datetime] NOT NULL,
     CONSTRAINT
    [PK_CustomerRequest] PRIMARY KEY CLUSTERED ([CUSTREQ_PK] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
    ON [PRIMARY]
    )
    ON [PRIMARY];
END

IF OBJECT_ID('[dbo].[ExpertRequest]') IS NULL
BEGIN
CREATE TABLE
    [dbo].[ExpertRequest]
(
    [EXPREQ_PK] [uniqueidentifier] NOT NULL,
    [EXPREQ_EXP_ID] [uniqueidentifier] NOT NULL,
    [EXPREQ_REQ_ID] [uniqueidentifier] NOT NULL,
    [EXPREQ_CreatedUtc] [datetime] NOT NULL,
     CONSTRAINT
    [PK_ExpertRequest] PRIMARY KEY CLUSTERED ([EXPREQ_PK] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
    ON [PRIMARY]
    )
    ON [PRIMARY];
END