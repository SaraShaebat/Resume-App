using AutoMapper;
using BackendPart.Core.Context;
using BackendPart.Core.Dtos.Candidate;
using BackendPart.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext ConDbContext;
        private IMapper ConMapper { get; }

        public CandidateController(AppDbContext dbContext, IMapper mapper)
        {
            ConDbContext = dbContext;
            ConMapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
        {
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaByte || pdfMimeType != pdfMimeType)
            {
                return BadRequest("File Not Valid!");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Docs", "pdfs", resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
                var newCand = ConMapper.Map<Candidate>(dto);
                newCand.ResumeUrl = resumeUrl;
                await ConDbContext.Candidates.AddAsync(newCand);
                await ConDbContext.SaveChangesAsync();

                return Ok("Candidate Saved Successfully");
            }

        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            var candidates = await ConDbContext.Candidates.Include(c => c.Job).ToListAsync();
            var convertedcandidates = ConMapper.Map<IEnumerable<CandidateGetDto>>(candidates);
            return Ok(convertedcandidates);
        }

        // Read(Download Pdf File)
        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Docs", "pdfs", url);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File Not Found!");
            }
            var pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes, "application/pdf", url);
            return file;
        }
    }
}
