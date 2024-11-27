-- Przyk³adowe projekty
INSERT INTO Projekty (nazwa, opis, data_rozpoczecia, data_zakonczenia, status, priorytet, termin) 
VALUES 
('Projekt A', 'Rozwój nowego systemu', '2024-12-01', '2025-06-01', 'W Trakcie', 'Wysoki', '2025-06-01'),
('Projekt B', 'Tworzenie kampanii reklamowej', '2024-11-15', '2025-01-15', 'Nie Rozpoczêty', 'Œredni', '2025-01-15');

-- Przyk³adowe zadania dla projektów
INSERT INTO Zadania (projekt_id, nazwa, opis, status, data_rozpoczecia, data_zakonczenia)
VALUES
(1, 'Analiza wymagañ', 'Przygotowanie analizy wymagañ dla systemu.', 'Nie Rozpoczête', '2024-12-02', '2024-12-10'),
(1, 'Projektowanie architektury', 'Opracowanie struktury systemu.', 'W Trakcie', '2024-12-11', '2024-12-20'),
(2, 'Opracowanie pomys³u na kampaniê', 'Stworzenie koncepcji kampanii reklamowej.', 'Zakoñczone', '2024-11-20', '2024-11-30'),
(2, 'Produkcja materia³ów reklamowych', 'Tworzenie grafik i tekstów do kampanii.', 'Nie Rozpoczête', '2024-12-01', '2024-12-15');

-- Przyk³adowe tagi
INSERT INTO Tagi (nazwa) 
VALUES 
('System'),
('Reklama'),
('Analiza'),
('Kampania');

-- Przypisanie tagów do projektów
-- Projekt 1 -> Tag: System
-- Projekt 2 -> Tag: Reklama, Kampania
INSERT INTO TagiProjekty (projekt_id, tag_id) 
VALUES 
(1, 1), -- Projekt A -> Tag: System
(2, 2), -- Projekt B -> Tag: Reklama
(2, 4); -- Projekt B -> Tag: Kampania

-- Przypisanie tagów do zadañ
-- Zadanie 1 (Analiza wymagañ) -> Tag: Analiza
-- Zadanie 2 (Projektowanie architektury) -> Tag: System
-- Zadanie 3 (Opracowanie pomys³u na kampaniê) -> Tag: Reklama
-- Zadanie 4 (Produkcja materia³ów reklamowych) -> Tag: Kampania
INSERT INTO TagiZadania (zadanie_id, tag_id) 
VALUES 
(1, 3), -- Analiza wymagañ -> Tag: Analiza
(2, 1), -- Projektowanie architektury -> Tag: System
(3, 2), -- Opracowanie pomys³u na kampaniê -> Tag: Reklama
(4, 4); -- Produkcja materia³ów reklamowych -> Tag: Kampania
