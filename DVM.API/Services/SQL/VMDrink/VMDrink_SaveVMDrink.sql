INSERT INTO vmdrink
VALUES (
@p_id,
@p_vmid,
@p_drinkid,
@p_count)
ON CONFLICT(id) DO
UPDATE vmdrink
SET 
vmid = @p_vmid,
drinkid = @p_drinkid,
count = @p_count
WHERE id = @p_id