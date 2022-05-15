CREATE INDEX idx_pracpesel
ON pracownik (Pesel ASC);

CREATE INDEX idx_pracid
ON pracownik (Id_Pracownika ASC);

CREATE INDEX idx_pracimienazwisko
ON pracownik (Imie, Nazwisko ASC);



CREATE INDEX idx_zamowid
ON zamowienie (Id_Zamowienia DESC);

CREATE INDEX idx_zamowdata
ON zamowienie (Data_Zamowienia DESC);

CREATE INDEX idx_zamowstol
ON zamowienie (Numer_Stolu ASC);

CREATE INDEX idx_zamowadres
ON zamowienie (Budynek, Ulica ASC);



CREATE INDEX idx_potrawaid
ON potrawa (Id_Potrawa ASC);

CREATE INDEX idx_potrawanazwa
ON potrawa (Nazwa ASC);

CREATE INDEX idx_potrawacena
ON potrawa (Id_Rodzaj, Cena DESC);

CREATE INDEX idx_potrawaalko
ON potrawa (Alkohol ASC);



CREATE INDEX idx_skladnikid
ON skladnik (Id_Skladnik ASC);

CREATE INDEX idx_skladniknazwa
ON skladnik (Nazwa ASC);

CREATE INDEX idx_skladnikcena
ON skladnik (Id_Jednostka, Cena_Za_Jednostke DESC);