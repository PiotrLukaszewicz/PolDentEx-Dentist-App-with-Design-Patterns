using OfficeOpenXml;
using OfficeOpenXml.Style;
using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace PolDentEx.DocumentationGenerator
{

    public class XLSXDocumentationGenerator :DocumentationGenerator
    {
        /// <summary>
        /// Generowanie pliku Excel z dokumentacją medyczną pacjenta z wykorzystaniem EPPlus
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>ReportViewModel</returns>
        public override ReportViewModel GenerateDocumentation(Patient patient)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PatientCard");
                if (patient.Date== null)
                {
                    patient.Date = DateTime.Now;
                }

                DataTable fileData = new DataTable();
                DataRow row;

                //nagłówki]
                fileData.Columns.Add(new DataColumn("Naglowek"));
                fileData.Columns.Add(new DataColumn("Wartosc"));

                row = fileData.NewRow();
                row["Naglowek"] = "Imie";
                row["Wartosc"] = patient.PatientDetails.FirstName;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "Nazwisko";
                row["Wartosc"] = patient.PatientDetails.LastName;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "PESEL";
                row["Wartosc"] = patient.PESEL;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "Lekarz Prowadzący";
                row["Wartosc"] = patient.Doctor.FirstName + patient.Doctor.LastName;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "Alergie";
                row["Wartosc"] = patient.PatientCard.AllergiesFile;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "Choroby przewlekłe";
                row["Wartosc"] = patient.PatientCard.DiseaseFile;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "Historia ";
                row["Wartosc"] = patient.PatientCard.HistoryFile;
                fileData.Rows.Add(row);

                row = fileData.NewRow();
                row["Naglowek"] = "Przyjmowane Leki";
                row["Wartosc"] = patient.PatientCard.TakenMedicinesFile;
                fileData.Rows.Add(row);

                
                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells.LoadFromDataTable(fileData, false);


                
                DataTable jawData = new DataTable();
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
                ws.Cells["A10"].LoadFromDataTable(jawData, true);

                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells["A1:A8"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }

                using (ExcelRange rng = ws.Cells["A1:B8"])
                {
                    rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                using (ExcelRange rng = ws.Cells["A10:G10"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }

                using (ExcelRange rng = ws.Cells["A10:G62"])
                {
                    rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                //Tworzenie nazwy  Dokumentacja_Imie_Nazwisko_Data
                string fileName = "attachment;  filename=" + "Dokumentacja_" +patient.PatientDetails.FirstName + "_" + patient.PatientDetails.LastName + "_";
                fileName += DateTime.Now.Date.ToString(" dd-MM-yyyy") + ".xlsx";

                return new ReportViewModel() {FileBytes = pck.GetAsByteArray(), FileName = fileName};

            }
        }
    }
}