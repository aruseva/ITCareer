
SELECT deposit_group, SUM(`wizzard_deposits`.deposit_amount) AS `total_sum`
FROM gringotts.wizzard_deposits
WHERE `wizzard_deposits`.`magic_wand_creator` = 'Ollivander family'
GROUP BY deposit_group
HAVING total_sum <=150000
ORDER BY total_sum DESC;