using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreMarient.Data;
using StoreMarient.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using StoreMarient.Services;

namespace StoreMarient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet("generate")]
        public async  Task<IActionResult> GeneratePdf()
        {
            var pdfBytes = await _pdfService.GeneratePdfReport();
            return File(pdfBytes, "application/pdf", $"Report_{DateTime.Now.ToString("dd/MM/yyyy")}.pdf");
        }
    }
}
