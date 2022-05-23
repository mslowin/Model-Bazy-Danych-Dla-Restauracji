CREATE DEFINER=`root`@`localhost` PROCEDURE `usun_skladnik`(id int, uzyte double)
BEGIN
    UPDATE skladnik
    SET    Ilosc =  Ilosc - uzyte
    WHERE    Id_Skladnik = id;
END