-- Create a new database called 'MovieAPIDB'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'MovieAPIDB'
)
CREATE DATABASE MovieAPIDB
GO

-- -- Create a new table called '[Movies]' in schema '[dbo]'
-- -- Drop the table if it already exists

IF OBJECT_ID('[dbo].[Movies]', 'U') IS NOT NULL
DROP TABLE [dbo].[Movies]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Movies]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), -- Primary Key column
    [Title] NVARCHAR(50) NOT NULL,
    [Category] NVARCHAR(50) NOT NULL
    -- Specify more columns here
);
GO

-- Insert rows into table 'Movies' in schema '[dbo]'
INSERT INTO [dbo].[Movies]
( -- Columns to insert data into
 Title, Category
)
VALUES
( -- First row: values for the columns in the list above
 '2001: A Space Odyssey', 'SciFi'
),
( 
 '3:10 to Yuma', 'Western'
),
(
 'Balls of Fury', 'Comedy'
),
(
 'Avengers: Age of Ultron', 'Superhero'
),
(
 'Back to the Future', 'SciFi'
),
(
 'Die Hard', 'Action'
),
(
 'Event Horizon', 'Horror'
),
(
 'Fast & Furious', 'Action'
),
(
 'Snatch', 'Crime'
),
(
 'Groundhog Day', 'Comedy'
),
(
 'Groundhog Day', 'Comedy'
),
(
 'Groundhog Day', 'Comedy'
),
(
 'Her', 'Romance'
),
(
 'Inside Out', 'Animated'
),
(
 'John Wick', 'Action'
)
-- Add more rows here
GO