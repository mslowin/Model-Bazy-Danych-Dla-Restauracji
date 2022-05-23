CREATE DEFINER=`root`@`localhost` PROCEDURE `dodaj_zamowienie`(Numer_Stolu int, Data_Zamowienia date, Ulica char(30), Budynek int, Lokal int, Id_Pracownika int, Gotowe tinyint)
BEGIN
	select @id := max(Id_Zamowienia) + 1 FROM zamowienie;
    
    IF Numer_Stolu IS NULL THEN
		IF Ulica IS NOT NULL AND Budynek IS NOT NULL THEN
			insert into zamowienie values(@id,Numer_Stolu,Data_Zamowienia,Ulica,Budynek,Lokal,Id_Pracownika,Gotowe);
		END IF;
	ELSE 
		IF Numer_Stolu IS NOT NULL THEN 
			IF Ulica IS NULL AND Budynek IS NULL THEN
				insert into zamowienie values(@id,Numer_Stolu,Data_Zamowienia,Ulica,Budynek,Lokal,Id_Pracownika,Gotowe);
			END IF;
		END IF;
    END IF;
    
    -- IF ((Numer_Stolu = NULL) OR (Ulica = NULL AND Budynek = NULL AND Lokal = NULL)) THEN 
	-- 	insert into zamowienie values(@id,Numer_Stolu,Data_Zamowienia,Ulica,Budynek,Lokal,Id_Pracownika);
	-- END IF;
END