CREATE DEFINER=`root`@`localhost` PROCEDURE `usun_pracownika`(id int)
BEGIN
	DELETE FROM pracownik WHERE Id_Pracownika = id;
END