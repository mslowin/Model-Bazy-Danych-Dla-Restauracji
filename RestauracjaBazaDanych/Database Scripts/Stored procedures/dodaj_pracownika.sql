CREATE DEFINER=`root`@`localhost` PROCEDURE `dodaj_pracownika`(IN imie char(20), IN nazwisko char(30), IN pesel char(11), IN rokUrodzenia int, IN ID_Posada int, IN zmiana int, IN wynagrodzenie int)
BEGIN
	select @id := max(Id_Pracownika) + 1 FROM pracownik;
	insert into pracownik values(@id,imie,nazwisko,pesel,rokUrodzenia,ID_Posada,zmiana,wynagrodzenie);
END