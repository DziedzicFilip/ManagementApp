-- Przyk³adowe wydarzenia
INSERT INTO Wydarzenia (nazwa, data_rozpoczecia, data_zakonczenia, opis) 
VALUES 
('Spotkanie z klientem', '2024-12-05 10:00', '2024-12-05 12:00', 'Spotkanie w sprawie nowego projektu.'),
('Warsztaty marketingowe', '2024-12-10 09:00', '2024-12-10 15:00', 'Warsztaty dla zespo³u marketingowego.'),
('Prezentacja produktu', '2024-12-15 14:00', '2024-12-15 16:00', 'Prezentacja nowego produktu na targach.');

-- Przyk³adowe tagi
INSERT INTO Tagi (nazwa) 
VALUES 
('Marketing'),
('Spotkanie'),
('Warsztaty'),
('Prezentacja');

-- Przypisanie tagów do wydarzeñ
-- Wydarzenie 1 (Spotkanie z klientem) -> Tag: Spotkanie
-- Wydarzenie 2 (Warsztaty marketingowe) -> Tag: Marketing, Warsztaty
-- Wydarzenie 3 (Prezentacja produktu) -> Tag: Prezentacja
INSERT INTO TagiWydarzenia (wydarzenie_id, tag_id) 
VALUES 
(1, 2), -- Spotkanie -> Tag: Spotkanie
(2, 1), -- Warsztaty marketingowe -> Tag: Marketing
(2, 3), -- Warsztaty marketingowe -> Tag: Warsztaty
(3, 4); -- Prezentacja produktu -> Tag: Prezentacja
