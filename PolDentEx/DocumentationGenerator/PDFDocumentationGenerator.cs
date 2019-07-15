using iTextSharp.text;
using iTextSharp.text.pdf;
using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PolDentEx.DocumentationGenerator
{
    public class PDFDocumentationGenerator : DocumentationGenerator
    {
        /// <summary>
        /// Generowanie pliku PDF z dokumentacją medyczną pacjenta z wykorzystaniem iTextSharp
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>ReportViewModel</returns>
        public override ReportViewModel GenerateDocumentation( Patient patient)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                document.AddTitle("Dokumentacja " + patient.PatientDetails.FirstName + " " + patient.PatientDetails.LastName);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                //Zrobienie polskich znaków
                BaseFont timesNewRoman = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED); 
                Font times14 = new Font(timesNewRoman, 14);

                //Chunk chunk = new Chunk("This is from chunk. ");
                //document.Add(chunk);

                //Phrase phrase = new Phrase("This is from Phrase.");
                //document.Add(phrase);

                //Paragraph para = new Paragraph("This is from paragraph.");
                //document.Add(para);

                //Sekcja górna
                string text =  "Imię: " + patient.PatientDetails.FirstName + "\n";
                text += "Nazwisko: " + patient.PatientDetails.LastName + "\n";
                text += "PESEL: " + patient.PESEL + "\n";
                text += "Lekarz Prowadzacy: " + patient.Doctor.FirstName + " " + patient.Doctor.LastName + "\n";
                text += "Alergie: " + patient.PatientCard.AllergiesFile + "\n";
                text += "Choroby Przewlekłe: " + patient.PatientCard.DiseaseFile + "\n";
                text += "Historia: " + patient.PatientCard.HistoryFile + "\n";
                text += "Przyjmowane leki: " + patient.PatientCard.TakenMedicinesFile + "\n\n";

                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 10;
                paragraph.SpacingAfter = 10;
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = times14;
                paragraph.Add(text);
                document.Add(paragraph);

                //Tabela zębów
                DataTable jawData = new DataTable();
                DataRow row;
                jawData.Columns.Add(new DataColumn("Nazwa zęba"));
                jawData.Columns.Add(new DataColumn("Czy wyrwany"));
                jawData.Columns.Add(new DataColumn("Notka1"));
                jawData.Columns.Add(new DataColumn("Notka2"));
                jawData.Columns.Add(new DataColumn("Notka3"));
                jawData.Columns.Add(new DataColumn("Notka4"));
                jawData.Columns.Add(new DataColumn("Rodzaj zęba"));

                ToothRepository toothRepository = new ToothRepository();
                List<Tooth> jaw =
                    toothRepository.GetAll().ToList().Where(t => t.PatientCardId == patient.PatientCardId).ToList();

                foreach (var tooth in jaw)
                {
                    row = jawData.NewRow();
                    row["Nazwa zęba"] = tooth.HumanTooth.ToothName;
                    if (tooth.Extracted)
                    {
                        row["Czy wyrwany"] = "wyrwany";
                    }
                    else
                    {
                        row["Czy wyrwany"] = "istnieje";
                    }
                    row["Notka1"] = tooth.Note1;
                    row["Notka2"] = tooth.Note2;
                    row["Notka3"] = tooth.Note3;
                    row["Notka4"] = tooth.Note4;
                    if (tooth.HumanTooth.IsMilkTooth)
                    {
                        row["Rodzaj zęba"] = "mleczny";
                    }
                    else
                    {
                        row["Rodzaj zęba"] = "stały";
                    }
                    jawData.Rows.Add(row);
                }

                PdfPTable table = new PdfPTable(new float[] { 2, 1, 1, 1, 1, 1, 1 });
                foreach (DataColumn c in jawData.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName,times14));
                }
                foreach (DataRow r in jawData.Rows)
                {
                    foreach (var item in r.ItemArray)
                    {
                        table.AddCell(new Phrase(item.ToString(),times14));
                    }
                }

                Paragraph paragraphTable = new Paragraph();
                paragraphTable.SpacingBefore = 10;
                paragraphTable.SpacingAfter = 10;
                paragraphTable.Alignment = Element.ALIGN_LEFT;
                paragraphTable.Font = times14;
                paragraphTable.Add(table);
                document.Add(paragraphTable);
                

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //Tworzenie nazwy  Dokumentacja_Imie_Nazwisko_Data
                string fileName = "attachment;  filename=" + "Dokumentacja_" + patient.PatientDetails.FirstName + "_" + patient.PatientDetails.LastName + "_";
                fileName += DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                return new ReportViewModel() { FileBytes = bytes, FileName = fileName };
            }
            
        }
    }
}