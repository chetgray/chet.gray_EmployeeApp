CREATE PROCEDURE dbo.spEmployeeGetAll
AS
SELECT
    e.Id
    , e.FirstName
    , e.MiddleName
    , e.LastName
    , e.[Date of Birth]
    , e.[Employment Start Date]
    , e.[Employment End Date]
    , e.Address_ID
FROM
    dbo.GeneralInfo AS e
