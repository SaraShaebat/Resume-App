using AutoMapper;
using BackendPart.Core.Context;
using BackendPart.Core.Dtos.Company;
using BackendPart.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackendPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext ConDbContext;
        private IMapper ConMapper { get; }

        public CompanyController(AppDbContext dbContext, IMapper mapper)
        {
            ConDbContext = dbContext;
            ConMapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
        {
            Company newCompany = ConMapper.Map<Company>(dto);
            await ConDbContext.Companies.AddAsync(newCompany);
            await ConDbContext.SaveChangesAsync();

            return Ok("Company Created Successfully");

        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await ConDbContext.Companies.ToListAsync();
            var convertedCompanies = ConMapper.Map<IEnumerable<CompanyGetDto>>(companies);

            return Ok(convertedCompanies);
        }

    }
}
