CREATE DEFINER=`root`@`localhost` PROCEDURE `aktualizuj_skladnik`(id int, roznica double, operacja char(20))
BEGIN
    IF operacja = 'dodaj' THEN
        BEGIN
            UPDATE    skladnik
            SET    Ilosc = Ilosc + roznica
            WHERE    Id_Skladnik = id;
        END;
	END IF;
    IF operacja = 'zmniejsz' THEN
        BEGIN
            UPDATE    skladnik
            SET    Ilosc = Ilosc - roznica
            WHERE    Id_Skladnik = id;
        END;
	END IF;
	IF operacja = 'zmien' THEN
        BEGIN
            UPDATE    skladnik
            SET    Ilosc = roznica
            WHERE    Id_Skladnik = id;
        END;
	END IF;
END