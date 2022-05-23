CREATE DEFINER=`root`@`localhost` PROCEDURE `ukoncz_potrawe`(id int)
BEGIN
    UPDATE    potrawa
    SET    Czy_Gotowa = 1
    WHERE    Id_Potrawa = id;
END