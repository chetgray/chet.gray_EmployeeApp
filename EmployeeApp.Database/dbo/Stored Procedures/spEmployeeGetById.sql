CREATE PROCEDURE dbo.spEmployeeGetById
    @employeeId int
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
WHERE
    e.Id = @employeeId
