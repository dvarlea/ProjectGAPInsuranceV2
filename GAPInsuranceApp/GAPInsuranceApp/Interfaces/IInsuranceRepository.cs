using GAPInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceApp.Interfaces
{
    public interface IInsuranceRepository
    {
        Task<Insurance[]> GetInsurances(int userId);

        Task<Insurance> GetInsuranceById(int id, int userId);

        Task<bool> Add(Insurance insurance, int userId);

        Task<bool> Delete(Insurance insurance, int userId);

        Task<bool> Update(Insurance insurance, int userId);
    }
}
