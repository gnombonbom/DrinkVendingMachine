INSERT INTO vendingmachine
VALUES (@p_id, @p_secretcode)
ON CONFLICT(id) DO
UPDATE vendingmachine
SET
secretcode = @p_secretcode
WHERE id = @p_id