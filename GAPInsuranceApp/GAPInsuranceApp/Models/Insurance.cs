
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAPInsuranceApp.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Coverages { get; set; }
        public double CoverageAmt { get; set; }
        public DateTime Begining { get; set; }
        public int TimePeriod { get; set; }
        public double Price { get; set; }
        public Risks Risk { get; set; }
    }
    public enum Risks
    {
        Alto = 1,
        MedioAlto,
        Medio,
        Bajo
    }
}
