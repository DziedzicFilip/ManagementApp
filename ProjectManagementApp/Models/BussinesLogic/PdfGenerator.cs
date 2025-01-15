using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ProjectManagementApp.Models.BussinesLogic;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
namespace ProjectManagementApp.Models.BussinesLogic
{
    internal class PdfGenerator : DateBaseClass
    {
        public PdfGenerator( ZarzadanieProjektami2Entities db) : base(db)
        {

        }

        public void GenerateProjectSummaryPdf(int projectId, 
            string outputPath, decimal? calkowityCzas, int? dniOpoznienia, decimal? wartoscEuroBezRabatu, 
            decimal? wartoscPLNBezRabatu, decimal? wartoscNettoPLN, decimal? wartoscNettoEUR, decimal? wartoscBruttoPLN, 
            decimal? wartoscBruttoEUR, string wybranaWaluta, decimal stawkaGodzinowa, string wybranyTypUmowy, decimal rabat, 
            int liczbaZadan, int liczbaWykonanychZadan, List<RejestrCzasuPracyProjekt> rejestrCzasuDane, List<Zadania> zadania, DateTime dataWystawienia)
        {
            var project = (from p in db.Projekty
                           where p.projekt_id == projectId
                           select p).FirstOrDefault();
            if (project == null)
            {
                throw new ArgumentException("Invalid project ID");
            }

            var document = new Document();
            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
            document.Open();

            // Dodaj tytuł
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var title = new Paragraph($"Podsumowanie Projektu: {project.nazwa}", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Dodaj szczegóły projektu
            var normalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            document.Add(new Paragraph($"Data rozpoczęcia: {project.data_rozpoczecia?.ToString("dd-MM-yyyy")}", normalFont));
            document.Add(new Paragraph($"Data zakończenia: {project.data_zakonczenia?.ToString("dd-MM-yyyy")}", normalFont));
            document.Add(new Paragraph($"Opis: {project.opis}", normalFont));

            // Dodaj wartości z PodsumowanieCzasuProjektuViewModel
            document.Add(new Paragraph($"Całkowity Czas: {calkowityCzas}", normalFont));
            document.Add(new Paragraph($"Dni Opóźnienia: {dniOpoznienia}", normalFont));
            document.Add(new Paragraph($"Wartość Euro Bez Rabatu: {wartoscEuroBezRabatu}", normalFont));
            document.Add(new Paragraph($"Wartość PLN Bez Rabatu: {wartoscPLNBezRabatu}", normalFont));
            document.Add(new Paragraph($"Wartość Netto PLN: {wartoscNettoPLN}", normalFont));
            document.Add(new Paragraph($"Wartość Netto EUR: {wartoscNettoEUR}", normalFont));
            document.Add(new Paragraph($"Wartość Brutto PLN: {wartoscBruttoPLN}", normalFont));
            document.Add(new Paragraph($"Wartość Brutto EUR: {wartoscBruttoEUR}", normalFont));
            document.Add(new Paragraph($"Wybrana Waluta: {wybranaWaluta}", normalFont));
            document.Add(new Paragraph($"Stawka Godzinowa: {stawkaGodzinowa}", normalFont));
            document.Add(new Paragraph($"Wybrany Typ Umowy: {wybranyTypUmowy}", normalFont));
            document.Add(new Paragraph($"Rabat: {rabat}", normalFont));
            document.Add(new Paragraph($"Liczba Zadań: {liczbaZadan}", normalFont));
            document.Add(new Paragraph($"Liczba Wykonanych Zadań: {liczbaWykonanychZadan}", normalFont));

            // Dodaj listę czasu pracy
            document.Add(new Paragraph("Rejestr Czasu Pracy:", titleFont));
            foreach (var rejestr in rejestrCzasuDane)
            {
                document.Add(new Paragraph($"Data: {rejestr.data?.ToString("dd-MM-yyyy")}, Czas Spędzony: {rejestr.czas_spedzony}", normalFont));
            }

            // Dodaj listę zadań
            document.Add(new Paragraph("Zadania:", titleFont));
            foreach (var zadanie in zadania)
            {
                document.Add(new Paragraph($"Nazwa: {zadanie.nazwa}, Opis: {zadanie.opis}, Status: {zadanie.status}", normalFont));
            }
            document.Add(new Paragraph($"Data Wystawienia: {dataWystawienia.ToShortDateString()}"));
            document.Close();
        }

        public string GetOutputPath(int projectId)
        {
            var project = (from p in db.Projekty
                           where p.projekt_id == projectId
                           select p).FirstOrDefault();
            if (project == null)
            {
                throw new ArgumentException("Invalid project ID");
            }

            string projectName = project.nazwa;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string baseFileName = $"{projectName}_PodsumowanieProjektu";
            string fileExtension = ".pdf";
            string filePath = Path.Combine(documentsPath, baseFileName + fileExtension);

            int fileIndex = 1;
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(documentsPath, $"{baseFileName}_{fileIndex}{fileExtension}");
                fileIndex++;
            }

            return filePath;
        }
        public string GetOutputPathBudget(int projectId)
        {
            var project = (from p in db.Projekty
                           where p.projekt_id == projectId
                           select p).FirstOrDefault();
            if (project == null)
            {
                throw new ArgumentException("Invalid project ID");
            }

            string projectName = project.nazwa;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string baseFileName = $"{projectName}_PodsumowanieBudgetu";
            string fileExtension = ".pdf";
            string filePath = Path.Combine(documentsPath, baseFileName + fileExtension);

            int fileIndex = 1;
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(documentsPath, $"{baseFileName}_{fileIndex}{fileExtension}");
                fileIndex++;
            }

            return filePath;
        }
        public void GenerateBudgetPdf(int projectId, string recenzja, string outputPath)
        {
            var project = db.Projekty.FirstOrDefault(p => p.projekt_id == projectId);
            if (project == null)
            {
                throw new ArgumentException("Invalid project ID");
            }

            var document = new Document();
            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
            document.Open();

            // Dodanie tytułu
            var titleFont = FontFactory.GetFont("Arial", 20, Font.BOLD);
            var title = new Paragraph("Budżet Projektu", titleFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20
            };
            document.Add(title);

            // Dodanie nazwy projektu
            var projectNameFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
            var projectName = new Paragraph($"Nazwa projektu: {project.nazwa}", projectNameFont)
            {
                SpacingAfter = 10
            };
            document.Add(projectName);

            // Dodanie szczegółów budżetu
            

            // Dodanie recenzji
            var reviewFont = FontFactory.GetFont("Arial", 12, Font.ITALIC);
            var review = new Paragraph($"Recenzja:\n{recenzja}", reviewFont);
            document.Add(review);

            document.Close();
        }

    }
}
