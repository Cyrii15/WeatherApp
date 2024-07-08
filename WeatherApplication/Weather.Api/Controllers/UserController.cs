//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Cryptography;
//using System.Text;
//using Weather.Api.Data;
//using Weather.Api.Entities;

//namespace Weather.Api.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly ApplicationDataContext _context;

//    public AuthController(ApplicationDataContext context)
//    {
//        _context = context;
//    }

//    // POST: api/Auth/Register
//    [HttpPost("Register")]
//    public async Task<ActionResult<User>> Register(UserRegisterDto request)
//    {
//        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
//        {
//            return BadRequest("User already exists.");
//        }

//        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

//        var user = new User
//        {
//            Id = Guid.NewGuid(),
//            Username = request.Username,
//            Email = request.Email,
//            PasswordHash = Convert.ToBase64String(passwordHash),
//            PasswordSalt = Convert.ToBase64String(passwordSalt)
//        };

//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();

//        return Ok(user);
//    }

//    // POST: api/Auth/Login
//    [HttpPost("Login")]
//    public async Task<ActionResult<User>> Login(UserLoginDto request)
//    {
//        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
//        if (user == null)
//        {
//            return BadRequest("User not found.");
//        }

//        if (!VerifyPasswordHash(request.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt)))
//        {
//            return BadRequest("Invalid password.");
//        }

//        // Here you can generate JWT tokens or other logic for logged in users

//        return Ok(user);
//    }

//    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//    {
//        using (var hmac = new HMACSHA512())
//        {
//            passwordSalt = hmac.Key;
//            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
//        }
//    }

//    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
//    {
//        using (var hmac = new HMACSHA512(storedSalt))
//        {
//            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
//            for (int i = 0; i < computedHash.Length; i++)
//            {
//                if (computedHash[i] != storedHash[i]) return false;
//            }
//        }
//        return true;
//    }
//}
