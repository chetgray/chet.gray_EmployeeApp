CREATE PROCEDURE dbo.spAddressGetById
    @addressId int
AS
SELECT
    a.Address_ID
    , a.[Street Address]
    , a.City
    , a.[State]
    , a.Zip
FROM
    dbo.Address AS a
WHERE
    a.Address_ID = @addressId
