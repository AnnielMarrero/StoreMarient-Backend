using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Colors;
using StoreMarient.Entities;
using StoreMarient.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreMarient.Services
{
    public interface IPdfService {
        Task<byte[]> GeneratePdfReport();
    }
    public class PdfService : IPdfService
    {
        private readonly IProductService _productService;
        private readonly IPhoneService _phoneService;
        private readonly IMicaService _micaService;
        private readonly ICoverStockService _coverStockService;
        private readonly StoreContext _context;
        public PdfService(IProductService productService, IPhoneService phoneService, IMicaService micaService, StoreContext context, ICoverStockService coverStockService) { 
            _productService = productService;
            _phoneService = phoneService;
            _micaService = micaService;
            _context = context;
            _coverStockService = coverStockService;
        }

        public async Task<byte[]> GeneratePdfReport()
        {
            // Create a memory stream to hold the PDF
            using (var memoryStream = new MemoryStream())
            {
                // Initialize PdfWriter and PdfDocument
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new iText.Layout.Document(pdf);

                // Add a title to the PDF
                document.Add(new Paragraph("Miscelaneas, Bebidas, confituras, utiles, bebe")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                // Create a table with 3 columns
                var table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(new float []{0.1f,0.3f,0.5f,0.1f })).UseAllAvailableWidth();
                // Define a background color for headers (e.g., light gray)
                Color headerBackgroundColor = new DeviceRgb(220, 220, 220); // Light gray

                
                // Add table headers
                table.AddHeaderCell(CreateHeaderCell("No.", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Categoria", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Nombre", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Cantidad", headerBackgroundColor));

                var products = (await _productService.GetAllAsync(_ => _.Category)).OrderBy(_ => _.Id);
                int rowNo = 0;
                foreach (var product in products) {
                    // Add rows to the table
                    table.AddCell((++rowNo).ToString());
                    table.AddCell(product.Category.Name);
                    table.AddCell(product.Name);
                    table.AddCell(product.Quantity.ToString());
                }
                

                // Add the table to the document
                document.Add(table);

                //adicionar celulares
                // Add a title to the PDF
                document.Add(new Paragraph("Celulares")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                // Create a table with 3 columns
                table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(new float[] { 0.1f, 0.3f, 0.5f, 0.1f })).UseAllAvailableWidth();
                // Define a background color for headers (e.g., light gray)
                
                // Add table headers
                table.AddHeaderCell(CreateHeaderCell("No.", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Pieza", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Modelo", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Cantidad", headerBackgroundColor));

                var phones = (await _phoneService.GetAllAsync(_ => _.Piece)).OrderBy(_ => _.Id);
                rowNo = 0;
                foreach (var phone in phones)
                {
                    // Add rows to the table
                    table.AddCell((++rowNo).ToString());
                    table.AddCell(phone.Piece.Name);
                    table.AddCell(phone.Model);
                    table.AddCell(phone.Quantity.ToString());
                }


                // Add the table to the document
                document.Add(table);
                
                //adicionar covers
                // Add a title to the PDF
                document.Add(new Paragraph("Covers")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                // Create a table with 3 columns
                table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(new float[] { 0.1f, 0.2f, 0.3f, 0.13f, 0.13f, 0.13f })).UseAllAvailableWidth();
                // Define a background color for headers (e.g., light gray)

                // Add table headers
                table.AddHeaderCell(CreateHeaderCell("No.", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Telefono", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Modelo", headerBackgroundColor));

                var coverTypes = (await _context.CoverTypes.ToListAsync()).Select(_ => _.Name);
                foreach (var ct in coverTypes)
                {
                    table.AddHeaderCell(CreateHeaderCell(ct, headerBackgroundColor));
                }
                var coverStocks = (await _coverStockService.GetAllAsync()).GroupBy(_ => _.CoverId);
                rowNo = 0;
                foreach (var coverStockGroup in coverStocks)
                {   
                    int temp = 0;
                    foreach (var coverStock in coverStockGroup)
                    {
                        if (temp == 0) { //solo se ejecuta la primera vez
                            temp++;
                            table.AddCell((++rowNo).ToString());
                            table.AddCell(coverStock.Cover.PhoneType.Name);
                            table.AddCell(coverStock.Cover.Model);
                        }
                        table.AddCell(coverStock.Quantity.ToString());
                    }
                    
                }
                // Add the table to the document
                document.Add(table);

                //adicionar micas
                // Add a title to the PDF
                document.Add(new Paragraph("Micas")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                // Create a table with 3 columns
                table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(new float[] { 0.1f, 0.3f, 0.5f, 0.1f })).UseAllAvailableWidth();
                // Define a background color for headers (e.g., light gray)

                // Add table headers
                table.AddHeaderCell(CreateHeaderCell("No.", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Telefono", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Modelo", headerBackgroundColor));
                table.AddHeaderCell(CreateHeaderCell("Cantidad", headerBackgroundColor));

                var micas = (await _micaService.GetAllAsync(_ => _.PhoneType)).OrderBy(_ => _.Id);
                rowNo = 0;
                foreach (var mica in micas)
                {
                    // Add rows to the table
                    table.AddCell((++rowNo).ToString());
                    table.AddCell(mica.PhoneType.Name);
                    table.AddCell(mica.Model);
                    table.AddCell(mica.Quantity.ToString());
                }
                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();

                // Return the PDF as a file
                return memoryStream.ToArray();

            }
            
        }
        private Cell CreateHeaderCell(string text, Color backgroundColor)
        {
            // Create a cell with the specified text and background color
            var cell = new Cell().Add(new Paragraph(text));
            cell.SetBackgroundColor(backgroundColor);
            cell.SetTextAlignment(TextAlignment.LEFT);
            cell.SetFontSize(12);
            //cell.SetBol
            return cell;
        }
    }
}
