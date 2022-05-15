CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `kelnerzy` AS
    SELECT 
        `pracownik`.`Id_Pracownika` AS `Id_Pracownika`,
        `pracownik`.`Imie` AS `Imie`,
        `pracownik`.`Nazwisko` AS `Nazwisko`,
        `pracownik`.`Pesel` AS `Pesel`,
        `pracownik`.`RokUrodzenia` AS `RokUrodzenia`,
        `pracownik`.`Id_Posada` AS `Id_Posada`,
        `pracownik`.`Zmiana` AS `Zmiana`,
        `pracownik`.`Wynagrodzenie` AS `Wynagrodzenie`
    FROM
        `pracownik`
    WHERE
        (`pracownik`.`Id_Posada` = 1)