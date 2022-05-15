CREATE TABLE IF NOT EXISTS TABELA_DIETY (
    Id_Diety INT        NOT NULL,
    Dieta    CHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Diety ASC)
);

CREATE TABLE IF NOT EXISTS TABELA_POSAD (
    Id_Posada INT        NOT NULL,
    Posada    CHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Posada ASC)
);

CREATE TABLE IF NOT EXISTS TABELA_JEDNOSTKA (
    Id_Jednostka INT        NOT NULL,
    Jednostka    CHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Jednostka ASC)
);

CREATE TABLE IF NOT EXISTS TABELA_RODZAJ (
    Id_Rodzaj INT        NOT NULL,
    Rodzaj    CHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Rodzaj ASC)
);

CREATE TABLE IF NOT EXISTS Pracownik (
    Id_Pracownika INT        NOT NULL,
    Imie          CHAR (20) NOT NULL,
    Nazwisko      CHAR (30) NOT NULL,
    Pesel         INT        NOT NULL,
    RokUrodzenia  INT        NOT NULL,
    Id_Posada     INT        NULL,
    Zmiana        INT        NULL,
    Wynagrodzenie INT        NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Pracownika ASC),
    FOREIGN KEY (Id_Posada) REFERENCES TABELA_POSAD (Id_Posadapracownik) ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Zamowienie (
    Id_Zamowienia   INT        NOT NULL,
    Numer_Stolu     INT        NULL,
    Data_Zamowienia DATE       NOT NULL,
    Ulica           CHAR (30) NULL,
    Budynek         INT        NULL,
    Lokal           INT        NULL,
    Id_Pracownika   INT        NULL,
    PRIMARY KEY CLUSTERED (Id_Zamowienia ASC),
    FOREIGN KEY (Id_Pracownika) REFERENCES Pracownik (Id_Pracownika) ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Potrawa (
    Id_Potrawa INT         NOT NULL,
    Nazwa      CHAR (30)   NOT NULL,
    Id_Rodzaj  INT         NULL,
    Id_Diety   INT         NULL,
    Cena       FLOAT (53)  NOT NULL,
    Alkohol    FLOAT (53)  NOT NULL,
    Czy_Gotowa BINARY (50) NULL,
    PRIMARY KEY CLUSTERED (Id_Potrawa ASC),
    FOREIGN KEY (Id_Rodzaj) REFERENCES TABELA_RODZAJ (Id_Rodzaj) ON UPDATE CASCADE,
    FOREIGN KEY (Id_Diety) REFERENCES TABELA_DIETY (Id_Diety) ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Skladnik (
    Id_Skladnik         INT         NOT NULL,
    Nazwa               CHAR (20)  NOT NULL,
    Ilosc               FLOAT (53)  NOT NULL,
    Id_Jednostka        INT         NOT NULL,
    Cena_Za_Jednostke   FLOAT (53)  NOT NULL,
    Czy_Widoczne_W_Menu BINARY (50) NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Skladnik ASC),
    FOREIGN KEY (Id_Jednostka) REFERENCES TABELA_JEDNOSTKA (Id_Jednostka) ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS TAB_POSR_POTRAWA_SKLADNIK (
    Id_Potrawa_Skladnik INT NOT NULL,
    Id_Potrawa          INT NOT NULL,
	Id_Skladnik         INT NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Potrawa_Skladnik ASC),
    FOREIGN KEY (Id_Potrawa) REFERENCES Potrawa (Id_Potrawa) ON UPDATE CASCADE,
    FOREIGN KEY (Id_Skladnik) REFERENCES Skladnik (Id_Skladnik) ON UPDATE CASCADE
);

CREATE TABLE TAB_POSR_ZAMOWIENIE_POTRAWA (
    Id_Zamowienie_Potrawa INT NOT NULL,
    Id_Zamowienie         INT NOT NULL,
    Id_Potrawa            INT NOT NULL,
    PRIMARY KEY CLUSTERED (Id_Zamowienie_Potrawa ASC),
    FOREIGN KEY (Id_Zamowienie) REFERENCES Zamowienie (Id_Zamowienia) ON UPDATE CASCADE,
    FOREIGN KEY (Id_Potrawa) REFERENCES Potrawa (Id_Potrawa) ON UPDATE CASCADE
);