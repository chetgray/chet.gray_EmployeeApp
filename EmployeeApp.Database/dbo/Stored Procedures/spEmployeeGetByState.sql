CREATE PROCEDURE dbo.spEmployeeGetByState
    @state nvarchar(255)
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
    INNER JOIN dbo.Address AS a
        ON e.Address_ID = a.Address_ID
WHERE
    a.State = @state
