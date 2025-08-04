CREATE OR ALTER PROCEDURE check_product_status
    @p_name NVARCHAR(255),
    @p_today DATE
AS
BEGIN
    SELECT
        p.Name AS product_name,
        DATEDIFF(day, p.ManufactureDate, @p_today) AS aging_days,
        CASE
            WHEN p.ExpiryDate < @p_today THEN 1
            ELSE 0
        END AS is_expired
    FROM
        Products p
    WHERE
        p.Name = @p_name;
END;