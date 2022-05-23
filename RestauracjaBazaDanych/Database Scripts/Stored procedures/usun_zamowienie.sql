CREATE DEFINER=`root`@`localhost` PROCEDURE `usun_zamowienie`(id int)
BEGIN
	DELETE FROM zamowienie WHERE Id_Zamowienia = id;
END