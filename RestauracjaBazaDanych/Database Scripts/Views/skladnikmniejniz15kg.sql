CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `skladnikimniejniz15kg` AS
    SELECT 
        `skladnik`.`Id_Skladnik` AS `Id_Skladnik`,
        `skladnik`.`Nazwa` AS `Nazwa`,
        `skladnik`.`Ilosc` AS `Ilosc`,
        `skladnik`.`Id_Jednostka` AS `Id_Jednostka`,
        `skladnik`.`Cena_Za_Jednostke` AS `Cena_Za_Jednostke`,
        `skladnik`.`Czy_Widoczne_W_Menu` AS `Czy_Widoczne_W_Menu`
    FROM
        `skladnik`
    WHERE
        ((`skladnik`.`Id_Jednostka` = 1)
            AND (`skladnik`.`Ilosc` < 15))