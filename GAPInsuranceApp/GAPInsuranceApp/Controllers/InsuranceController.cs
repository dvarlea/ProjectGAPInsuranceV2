using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GAPInsuranceApp.DTOs;
using GAPInsuranceApp.Interfaces;
using GAPInsuranceApp.Models;
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
                if (results == null || results.Count() == 0)
                {
                    return NoContent();
                }
                InsuranceDTO[] insurances = _mapper.Map<InsuranceDTO[]>(results);
                return Ok(insurances);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{userId}/userId")]
        public async Task<IActionResult> DeleteInsurance(int userId, [FromBody] InsuranceDTO insuranceDTO)
        {
            try
            {
                Insurance insurance = _mapper.Map<Insurance>(insuranceDTO);
                var results = await _insuranceRepo.Delete(insurance, userId);
                if (results == false)
                {
                    return BadRequest(false);
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{userId}/userId")]
        public async Task<IActionResult> UpdateInsurance(int userId, [FromBody] InsuranceDTO insuranceDTO)
        {
            try
            {
                Insurance insurance = _mapper.Map<Insurance>(insuranceDTO);
                if (!Validate(insurance))
                {
                    return BadRequest("La covertura no puede ser superior al 50% en caso de riesgo alto");
                }
                var results = await _insuranceRepo.Update(insurance, userId);
                if (results == false)
                {
                    return BadRequest(false);
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("{userId}/userId")]
        public async Task<IActionResult> AddInsurance(int userId, [FromBody] InsuranceDTO insuranceDTO)
        {
            try
            {
                Insurance insurance = _mapper.Map<Insurance>(insuranceDTO);
                if(!Validate(insurance))
                {
                    return BadRequest("La covertura no puede ser superior al 50% en caso de riesgo alto");
                }
                var results = await _insuranceRepo.Add(insurance, userId);
                if (results == false)
                {
                    return BadRequest(false);
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool Validate(Insurance insurance)
        {
            if (insurance.Risk == Risks.Alto && insurance.CoverageAmt > 0.5)
            {
                return false;
            }
            return true;
        }

    }
}
