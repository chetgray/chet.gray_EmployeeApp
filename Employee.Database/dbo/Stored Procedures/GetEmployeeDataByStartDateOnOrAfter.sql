
CREATE   PROCEDURE dbo.GetEmployeeDataByStartDateOnOrAfter
    @StartDate date
AS
SELECT
    gi.Id
    , gi.FirstName
    , gi.MiddleName
    , gi.LastName
    , gi."Date of Birth"
    , gi."Employment Start Date"
    , gi."Employment End Date"
    , a."Street Address"
    , a.City
    , a."State"
    , a.Zip
FROM
    dbo.GeneralInfo AS gi
    LEFT JOIN dbo.Address AS a
        ON gi.Address_ID = a.Address_ID
WHERE
    @StartDate <= CAST("Employment Start Date" as date)
;
