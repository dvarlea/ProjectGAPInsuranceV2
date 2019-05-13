using GAPInsuranceApp.Data;
using GAPInsuranceApp.Interfaces;
using GAPInsuranceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceApp.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly DataContext _context;
        public InsuranceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Insurance[]> GetInsurances(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            IQueryable<Insurance> query = _context.Insurances;

            // return 401 Unathorized from the controller
            if (user == null)
            {
                return null;
            }
            if(user.Role != Roles.Admin)
            {
                query = query.Where(i => i.ClientId == user.Id);
                return await query.ToArrayAsync();
            }

            return await query.ToArrayAsync(); ;
        }

        public async Task<Insurance> GetInsuranceById(int id, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var insurance = await _context.Insurances.FirstOrDefaultAsync(i => i.Id == id);

            if (user.Role != Roles.Admin && user.Id != insurance.ClientId)
            {
                return null;
            }

            return insurance;
        }

        public async Task<bool> Add(Insurance insurance, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user.Role != Roles.Admin)
            {
                return false;
            }
            _context.Add(insurance);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Delete(Insurance insurance, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user.Role != Roles.Admin)
            {
                return false;
            }
            _context.Remove(insurance);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(Insurance insurance, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user.Role != Roles.Admin)
            {
                return false;
            }
            _context.Update(insurance);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
