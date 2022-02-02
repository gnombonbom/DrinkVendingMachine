INSERT INTO drink
VALUES(
@p_id,
@p_name,
@p_image,
@p_cost)
ON CONFLICT(id) DO
UPDATE drink
SET
name = @p_name,
image = @p_image,
cost = @p_cost
WHERE id = @p_id