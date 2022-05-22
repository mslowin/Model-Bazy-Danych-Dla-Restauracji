CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `zamowieniaponiedzialek16` AS
    SELECT 
        `zamowienie`.`Id_Zamowienia` AS `Id_Zamowienia`,
        `zamowienie`.`Numer_Stolu` AS `Numer_Stolu`,
        `zamowienie`.`Data_Zamowienia` AS `Data_Zamowienia`,
        `zamowienie`.`Ulica` AS `Ulica`,
        `zamowienie`.`Budynek` AS `Budynek`,
        `zamowienie`.`Lokal` AS `Lokal`,
        `zamowienie`.`Id_Pracownika` AS `Id_Pracownika`
    FROM
        `zamowienie`
    WHERE
        (`zamowienie`.`Data_Zamowienia` = '2022-05-16')