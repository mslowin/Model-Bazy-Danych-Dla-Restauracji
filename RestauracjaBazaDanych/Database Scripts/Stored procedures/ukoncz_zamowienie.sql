CREATE DEFINER=`root`@`localhost` PROCEDURE `ukoncz_zamowienie`(id int)
BEGIN
	UPDATE zamowienie SET Gotowe = 1 WHERE Id_Zamowienia = id;
END