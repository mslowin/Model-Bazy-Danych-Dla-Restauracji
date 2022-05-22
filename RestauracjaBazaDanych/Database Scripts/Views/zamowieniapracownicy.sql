CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `zamowieniapracownicy` AS
    SELECT 
        `a`.`Id_Pracownika` AS `Id_pracownika`,
        `a`.`Imie` AS `Imie`,
        `a`.`Nazwisko` AS `Nazwisko`,
        `b`.`Data_Zamowienia` AS `Data_Zamowienia`
    FROM
        (`pracownik` `a`
        JOIN `zamowienie` `b`)
    WHERE
        (`a`.`Id_Pracownika` = `b`.`Id_Pracownika`)