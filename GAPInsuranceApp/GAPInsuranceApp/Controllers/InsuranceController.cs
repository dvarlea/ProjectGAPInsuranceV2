using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GAPInsuranceApp.DTOs;
using GAPInsuranceApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAPInsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : Controller
    {
        private readonly IInsuranceRepository _insuranceRepo;
        private readonly IMapper _mapper;

        public InsuranceController(IInsuranceRepository insuranceRepo, IMapper mapper)
        {
            _insuranceRepo = insuranceRepo;
            _mapper = mapper;
        }

        [HttpGet("{userId}/userId")]
        public async Task<IActionResult> GetInsurances(int userId)
        {
            try
            {
                var results = await _insuranceRepo.GetInsurances(userId);
                if(results == null || results.Count() == 0)
                {
                    return NoContent();
                }
                InsuranceDTO[] insurances = _mapper.Map<InsuranceDTO[]>(results);
                return Ok(insurances);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
