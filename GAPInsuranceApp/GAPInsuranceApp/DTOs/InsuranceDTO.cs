using GAPInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceApp.DTOs
{
    public class InsuranceDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Coverages { get; set; }
        [Required]
        public double CoverageAmt { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        [Required]
        public int TimePeriod { get; set; }
        public double Price { get; set; }
        [Required]
        public Risks Risk { get; set; }
    }
}
