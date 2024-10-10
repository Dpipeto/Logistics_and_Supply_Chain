using Backend.Context;
using Backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task CreateUserAsync(string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId);
        Task UpdateUserAsync(int id, string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DeliveryDbContext _context;

        public UserRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.users
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.users
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.users
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateUserAsync(string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId)
        {
            // Fetch the UserType
            var userType = await _context.usersTypes.FindAsync(userTypesId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, password);

            // Create a new User object
            var user = new User
            {
                First_Name = first_Name,
                Last_Name = last_Name,
                Username = username,
                Email = email,
                Password = hashedPassword,
                Address = address,
                Phone = phone,
                ID_Document = iD_Document,
                Date = date,
                UserType = userType
            };

            try
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task UpdateUserAsync(int id, string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId)
        {
            // Find the existing user by ID
            var user = await _context.users.FindAsync(id) ?? throw new Exception("User not found");

            // Fetch the User object based on userId and attendantId
            var userType = await _context.usersTypes.FindAsync(userTypesId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, password);

            // Update
            user.First_Name = first_Name;
            user.Last_Name = last_Name;
            user.Username = username;
            user.Email = email;
            user.Password = hashedPassword;
            user.Address = address;
            user.Phone = phone;
            user.ID_Document = iD_Document;
            user.Date = date;
            user.UserType = userType;


            try
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
        // Check user password and email
        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            // Fetch the user by email
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("User not found");

            // User does not exist
            if (user == null) return false;

            // Initialize PasswordHasher
            var passwordHasher = new PasswordHasher<User>();

            // Verify the password
            var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            // Check if password is correct
            if (userVerification == PasswordVerificationResult.Success) return true;

            // Password is invalid
            return false;
        }
    }
}
