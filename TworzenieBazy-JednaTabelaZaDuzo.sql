-- 1. Tabela Projekty
CREATE TABLE Projekty (
    projekt_id INT IDENTITY(1,1) PRIMARY KEY,
    nazwa VARCHAR(255) NOT NULL,
    opis TEXT,
    data_rozpoczecia DATETIME,
    data_zakonczenia DATETIME,
    status VARCHAR(20) CHECK (status IN ('Nie Rozpocz�ty', 'W Trakcie', 'Zako�czony', 'Wstrzymany')) DEFAULT 'Nie Rozpocz�ty',
    priorytet VARCHAR(20) CHECK (priorytet IN ('Niski', '�redni', 'Wysoki')) DEFAULT '�redni',
    termin DATETIME
);

-- 2. Tabela Notatki do projekt�w
CREATE TABLE NotatkiProjekty (
    notatka_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    tresc_notatki TEXT,
    data_utworzenia DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 3. Tabela Pliki do projekt�w
CREATE TABLE PlikiProjekty (
    plik_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    nazwa_pliku VARCHAR(255),
    sciezka_pliku VARCHAR(255),
    data_wgrania DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 4. Tabela Wydarzenia 
CREATE TABLE Wydarzenia (
    wydarzenie_id INT IDENTITY(1,1) PRIMARY KEY,
    nazwa VARCHAR(255),
    data_rozpoczecia DATETIME,
    data_zakonczenia DATETIME,
    opis TEXT
);

-- 5. Tabela Notatki do wydarze�
CREATE TABLE NotatkiWydarzenia (
    notatka_id INT IDENTITY(1,1) PRIMARY KEY,
    wydarzenie_id INT,
    tresc_notatki TEXT,
    data_utworzenia DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (wydarzenie_id) REFERENCES Wydarzenia(wydarzenie_id) ON DELETE CASCADE
);

-- 6. Tabela Pliki do wydarze�
CREATE TABLE PlikiWydarzenia (
    plik_id INT IDENTITY(1,1) PRIMARY KEY,
    wydarzenie_id INT,
    nazwa_pliku VARCHAR(255),
    sciezka_pliku VARCHAR(255),
    data_wgrania DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (wydarzenie_id) REFERENCES Wydarzenia(wydarzenie_id) ON DELETE CASCADE
);

-- 7. Tabela Rejestr Czasu Pracy nad Projektem
--CREATE TABLE RejestrCzasuPracy (
  --  rejestr_id INT IDENTITY(1,1) PRIMARY KEY,
   -- projekt_id INT,
   -- data_rozpoczecia DATETIME,
   -- data_zakonczenia DATETIME,
   -- FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
--); 

-- 8. Tabela Historia Dzia�a� Projektu
CREATE TABLE HistoriaDzialanProjektu (
    historia_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    dzialanie TEXT,
    data_zdarzenia DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 9. Tabela Rejestr Czasu Pracy na Projekcie
CREATE TABLE RejestrCzasuPracyProjekt (
    rejestr_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    czas_spedzony DECIMAL(10, 2),
    data DATETIME,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 10. Tabela Podsumowanie Czasu
CREATE TABLE PodsumowanieCzasu (
    podsumowanie_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    calkowity_czas DECIMAL(10, 2),
    data_rozpoczecia DATETIME,
    data_zakonczenia DATETIME,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 11. Tabela Zadania
CREATE TABLE Zadania (
    zadanie_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    nazwa VARCHAR(255),
    opis TEXT,
    status VARCHAR(20) CHECK (status IN ('Nie Rozpocz�te', 'W Trakcie', 'Zako�czone')) DEFAULT 'Nie Rozpocz�te',
    data_rozpoczecia DATETIME,
    data_zakonczenia DATETIME,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 12. Tabela Tagi
CREATE TABLE Tagi (
    tag_id INT IDENTITY(1,1) PRIMARY KEY,
    nazwa VARCHAR(255) NOT NULL
);

-- 13. Tabela Tagi do Projekt�w
CREATE TABLE TagiProjekty (
    projekt_id INT,
    tag_id INT,
    PRIMARY KEY (projekt_id, tag_id),
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE,
    FOREIGN KEY (tag_id) REFERENCES Tagi(tag_id) ON DELETE CASCADE
);

-- 14. Tabela Tagi do Zada�
CREATE TABLE TagiZadania (
    zadanie_id INT,
    tag_id INT,
    PRIMARY KEY (zadanie_id, tag_id),
    FOREIGN KEY (zadanie_id) REFERENCES Zadania(zadanie_id) ON DELETE CASCADE,
    FOREIGN KEY (tag_id) REFERENCES Tagi(tag_id) ON DELETE CASCADE
);

-- 15. Tabela Tagi do Wydarze�
CREATE TABLE TagiWydarzenia (
    wydarzenie_id INT,
    tag_id INT,
    PRIMARY KEY (wydarzenie_id, tag_id),
    FOREIGN KEY (wydarzenie_id) REFERENCES Wydarzenia(wydarzenie_id) ON DELETE CASCADE,
    FOREIGN KEY (tag_id) REFERENCES Tagi(tag_id) ON DELETE CASCADE
);

-- 16. Tabela Bud�et Projektu
CREATE TABLE BudzetProjektu (
    budzet_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    calkowity_budzet DECIMAL(15, 2),
    wydana_kwota DECIMAL(15, 2),
    pozostala_kwota DECIMAL(15, 2),
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 17. Tabela Ryzyka Projektu
CREATE TABLE RyzykaProjektu (
    ryzyko_id INT IDENTITY(1,1) PRIMARY KEY,
    projekt_id INT,
    opis TEXT,
    wplyw VARCHAR(20) CHECK (wplyw IN ('Niski', '�redni', 'Wysoki')),
    prawdopodobienstwo VARCHAR(20) CHECK (prawdopodobienstwo IN ('Niskie', '�rednie', 'Wysokie')),
    srodki_zapobiegawcze TEXT,
    FOREIGN KEY (projekt_id) REFERENCES Projekty(projekt_id) ON DELETE CASCADE
);

-- 18. Tabela Logi Zada�
CREATE TABLE LogiZadan (
    log_id INT IDENTITY(1,1) PRIMARY KEY,
    zadanie_id INT,
    dzialanie TEXT,
    status_przed VARCHAR(20) CHECK (status_przed IN ('Nie Rozpocz�te', 'W Trakcie', 'Zako�czone')),
    status_po VARCHAR(20) CHECK (status_po IN ('Nie Rozpocz�te', 'W Trakcie', 'Zako�czone')),
    data_zmiany DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (zadanie_id) REFERENCES Zadania(zadanie_id) ON DELETE CASCADE
);
