using GAPInsuranceApp.Data;
using GAPInsuranceApp.Interfaces;
using GAPInsuranceApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GAPInsuranceApp.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                int result;
                if(!int.TryParse(username, out result))
                {
                    return null;
                }
                user = await _context.Users.FirstOrDefaultAsync(u => u.Id == result);
                if (user == null)
                {
                    return null;
                }
            }
            if (user.PasswordSalt != null) ///ONLY FOR TESTING PORPUSES FOR TEST USERS IN THE DB
            {
                // return 401 Unathorized from the controller
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username)) return true;

            return false;
        }

        public async Task<bool> IdExists(int id)
        {
            if (await _context.Users.AnyAsync(u => u.Id == id)) return true;

            return false;
        }
    }
}
