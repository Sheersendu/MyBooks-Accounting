IF OBJECT_ID('[dbo].[Expert]') IS NULL
    BEGIN
    CREATE TABLE
        [dbo].[Expert]
    (
        [Exp_PK] [uniqueidentifier] NOT NULL,
        [Exp_ID] [varchar](20) NOT NULL,
        [Exp_IsActive] [bit] NOT NULL,
        [Exp_CreatedUtc] [datetime] NOT NULL,
        CONSTRAINT
        [PK_Expert] PRIMARY KEY CLUSTERED ([Exp_PK] ASC)
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
        [Cust_PK] [uniqueidentifier] NOT NULL,
        [Cust_ID] [varchar](20) NOT NULL,
        [Cust_IsActive] [bit] NOT NULL,
        [Cust_CreatedUtc] [datetime] NOT NULL,
         CONSTRAINT
        [PK_Customer] PRIMARY KEY CLUSTERED ([Cust_PK] ASC)
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
        [Req_PK] [uniqueidentifier] NOT NULL,
        [Req_ID] [int] IDENTITY(1000,1) NOT NULL,
        [Req_Name] [varchar](200) NOT NULL,
        [Req_IsCompleted] [bit] NOT NULL,
        [Req_CreatedUtc] [datetime] NOT NULL,
         CONSTRAINT
        [PK_Request] PRIMARY KEY CLUSTERED ([Req_PK] ASC)
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
        [CustReq_PK] [uniqueidentifier] NOT NULL,
        [CustReq_Cust_ID] [uniqueidentifier] NOT NULL,
        [CustReq_Req_ID] [uniqueidentifier] NOT NULL,
        [CustReq_TASK_ID] [int] NOT NULL,
        [CustReq_STATUS] [bit] NOT NULL,
        [CustReq_CreatedUtc] [datetime] NOT NULL,
         CONSTRAINT
        [PK_CustomerRequest] PRIMARY KEY CLUSTERED ([CustReq_PK] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
        ON [PRIMARY]
        )
        ON [PRIMARY];
    ALTER TABLE
        [dbo].[CustomerRequest]
        ADD CONSTRAINT
            [FK_Customer_Request]
            FOREIGN KEY
                ([CustReq_Cust_ID])
                REFERENCES
                    [dbo].[Customer]([Cust_PK])
                ON DELETE CASCADE;
    ALTER TABLE
        [dbo].[CustomerRequest]
        ADD CONSTRAINT
            [FK_Request_Customer]
            FOREIGN KEY
            ([CustReq_Req_ID])
            REFERENCES
                [dbo].[Request]([Req_PK])
            ON DELETE CASCADE;
    END

IF OBJECT_ID('[dbo].[ExpertRequest]') IS NULL
    BEGIN
    CREATE TABLE
        [dbo].[ExpertRequest]
    (
        [ExpReq_PK] [uniqueidentifier] NOT NULL,
        [ExpReq_Exp_ID] [uniqueidentifier] NOT NULL,
        [ExpReq_Req_ID] [uniqueidentifier] NOT NULL,
        [ExpReq_CreatedUtc] [datetime] NOT NULL,
         CONSTRAINT
        [PK_ExpertRequest] PRIMARY KEY CLUSTERED ([ExpReq_PK] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
        ON [PRIMARY]
        )
        ON [PRIMARY];
    ALTER TABLE 
        [dbo].[ExpertRequest]
        ADD CONSTRAINT
            [FK_Expert_Request]
            FOREIGN KEY
                ([ExpReq_Exp_ID])
                REFERENCES
                    [dbo].[Expert]([Exp_PK])
                ON DELETE CASCADE;
    ALTER TABLE
        [dbo].[ExpertRequest]
        ADD CONSTRAINT
            [FK_Request_Expert]
            FOREIGN KEY
                ([ExpReq_Req_ID])
                REFERENCES
                    [dbo].[Request]([Req_PK])
                ON DELETE CASCADE;
    END
    
IF OBJECT_ID('[dbo].[User]') IS NULL
BEGIN
CREATE TABLE
    [dbo].[User]
(
    [User_PK] [uniqueidentifier] NOT NULL,
    [User_ID] [varchar](20) NOT NULL,
    [User_Password] [varchar](64) NOT NULL,
    [User_IsExpert] [bit] NOT NULL,
    [User_CreatedUtc] [datetime] NOT NULL,
    CONSTRAINT
    [PK_User] PRIMARY KEY CLUSTERED ([User_PK] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
    ON [PRIMARY]
    )
    ON [PRIMARY];
END