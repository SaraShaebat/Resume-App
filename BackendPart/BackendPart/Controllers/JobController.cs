using AutoMapper;
using BackendPart.Core.Context;
using BackendPart.Core.Dtos.Job;
using BackendPart.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly AppDbContext ConDbContext;
        private IMapper ConMapper { get; }

        public JobController(AppDbContext dbContext, IMapper mapper)
        {
            ConDbContext = dbContext;
            ConMapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var newJob = ConMapper.Map<Job>(dto);
            await ConDbContext.Jobs.AddAsync(newJob);
            await ConDbContext.SaveChangesAsync();

            return Ok("Job Created Successfully");

        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await ConDbContext.Jobs.Include(job => job.Company).ToListAsync();
            var covertdJobs = ConMapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(covertdJobs);

        }
    }
}
