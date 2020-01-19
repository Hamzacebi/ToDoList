USE [ToDoList]
GO
/****** Object:  Table [dbo].[AssignmentHistoryOfTasks]    Script Date: 6.01.2020 22:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentHistoryOfTasks](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ToDoId] [smallint] NOT NULL,
	[DateToAccepted] [datetime] NOT NULL,
	[ReleaseDate] [datetime] NULL,
	[ProcessType] [tinyint] NOT NULL,
 CONSTRAINT [PK_AssignmentHistoryOfTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6.01.2020 22:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UniqueKey_CategoryName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThingsToDo]    Script Date: 6.01.2020 22:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThingsToDo](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [smallint] NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[PriorityType] [tinyint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_ThingsToDo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6.01.2020 22:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UniqueKey_UserEmail] UNIQUE NONCLUSTERED 
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_CategoryName]    Script Date: 6.01.2020 22:57:31 ******/
CREATE NONCLUSTERED INDEX [Index_CategoryName] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_ToDoSubject]    Script Date: 6.01.2020 22:57:31 ******/
CREATE NONCLUSTERED INDEX [Index_ToDoSubject] ON [dbo].[ThingsToDo]
(
	[Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_UserEmail]    Script Date: 6.01.2020 22:57:31 ******/
CREATE NONCLUSTERED INDEX [Index_UserEmail] ON [dbo].[Users]
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_UserPassword]    Script Date: 6.01.2020 22:57:31 ******/
CREATE NONCLUSTERED INDEX [Index_UserPassword] ON [dbo].[Users]
(
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssignmentHistoryOfTasks] ADD  CONSTRAINT [DF_AssignmentHistoryOfTasks_DateToAccepted]  DEFAULT (getdate()) FOR [DateToAccepted]
GO
ALTER TABLE [dbo].[AssignmentHistoryOfTasks] ADD  CONSTRAINT [DF_AssignmentHistoryOfTasks_ReleaseDate]  DEFAULT (getdate()) FOR [ReleaseDate]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_DeleteDate]  DEFAULT (getdate()) FOR [DeleteDate]
GO
ALTER TABLE [dbo].[ThingsToDo] ADD  CONSTRAINT [DF_ThingsToDo_IsCompleted]  DEFAULT ((0)) FOR [IsCompleted]
GO
ALTER TABLE [dbo].[ThingsToDo] ADD  CONSTRAINT [DF_ThingsToDo_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ThingsToDo] ADD  CONSTRAINT [DF_ThingsToDo_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[ThingsToDo] ADD  CONSTRAINT [DF_ThingsToDo_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[ThingsToDo] ADD  CONSTRAINT [DF_ThingsToDo_DeleteDate]  DEFAULT (getdate()) FOR [DeleteDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[AssignmentHistoryOfTasks]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentHistoryOfTasks_ThingsToDo] FOREIGN KEY([ToDoId])
REFERENCES [dbo].[ThingsToDo] ([Id])
GO
ALTER TABLE [dbo].[AssignmentHistoryOfTasks] CHECK CONSTRAINT [FK_AssignmentHistoryOfTasks_ThingsToDo]
GO
ALTER TABLE [dbo].[AssignmentHistoryOfTasks]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentHistoryOfTasks_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[AssignmentHistoryOfTasks] CHECK CONSTRAINT [FK_AssignmentHistoryOfTasks_Users]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Users]
GO
ALTER TABLE [dbo].[ThingsToDo]  WITH CHECK ADD  CONSTRAINT [FK_ThingsToDo_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ThingsToDo] CHECK CONSTRAINT [FK_ThingsToDo_Categories]
GO