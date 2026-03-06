-- =============================================
-- Create Database
-- =============================================
CREATE DATABASE VistraDB;
GO

USE VistraDB;
GO

-- =============================================
-- Create Table: employee_biodata
-- =============================================
CREATE TABLE employee_biodata (
    employee_no     VARCHAR(10)     NOT NULL PRIMARY KEY,
    employee_name   VARCHAR(60)     NOT NULL,
    birth_date      DATETIME        NOT NULL
);
GO

-- =============================================
-- Insert Records
-- =============================================
INSERT INTO employee_biodata (employee_no, employee_name, birth_date) VALUES
('00001', 'Alex Song',     '1979-12-31'),
('00002', 'Johnson Ong',   '1985-01-27'),
('00003', 'Henry Lim',     '1985-12-26'),
('00004', 'Anders Ngo',    '1986-02-05'),
('00005', 'Summer Leow',   '1980-08-12');
GO
