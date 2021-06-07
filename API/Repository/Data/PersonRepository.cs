using API.Context;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, int>
    {

        public IConfiguration configuration;
        private readonly MyContext conn;
        private readonly DbSet<RegisterVM> registers;
        public PersonRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.conn = myContext;
            this.configuration = configuration;
            registers = conn.Set<RegisterVM>();
        }

        //public class Hashing
        //{
        //    private static string GetRandomSalt()
        //    {
        //        return BCrypt.Net.BCrypt.GenerateSalt(10);
        //    }
        //    public static string HashPassword(string password)
        //    {
        //        return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        //    }

        //    public static bool ValidatePassword(string password, string correctHash)
        //    {
        //        return BCrypt.Net.BCrypt.Verify(password, correctHash);
        //    }

        //}
        //public int Role (RegisterVM registerVM)

        public int Register(RegisterVM registerVM)
        {
            var result = 0;
            var cek = conn.Persons.FirstOrDefault(p => p.Email == registerVM.Email);

            if (cek == null)
            {
                Person person = new Person
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Phone = registerVM.Phone,
                    BirthDate = registerVM.BirthDate,
                    Email = registerVM.Email,
                    Salary = registerVM.Salary
                };
                conn.Add(person);
                result = conn.SaveChanges();


                Account account = new Account
                {
                    NIK = person.NIK,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password)

                };
                conn.Add(account);
                result = conn.SaveChanges();

                Education education = new Education
                {
                    Degree = registerVM.Degree,
                    GPA = registerVM.GPA,
                    Universityid = registerVM.Universityid
                };
                conn.Add(education);
                result = conn.SaveChanges();

                Profiling profiling = new Profiling
                {
                    NIK = person.NIK,
                    Educationid = education.Educationid,
                };
                conn.Add(profiling);
                result = conn.SaveChanges();


                AccountRole accountRole = new AccountRole
                {
                    NIK = account.NIK,
                    RoleId = 3
                };
                conn.Add(accountRole);
                result = conn.SaveChanges();

                return result;
            }
            return result;
        }


        //public int Role(RegisterVM registerVM)
        //{
        //    var result = 0;
        //    Role role = new Role
        //    {
        //        RoleName = registerVM.RoleName
        //    };
        //    conn.Add(role);
        //   return result = conn.SaveChanges();

        //}

        //public IEnumerable<RegisterVM>GetAllRole()
        //{
        //    return conn.Role.ToList();

        //}

        public IEnumerable<RegisterVM> GetAllProfile()
        {
            var result = (from p in conn.Persons
                          join a in conn.Account on p.NIK equals a.NIK
                          join pf in conn.Profiling on a.NIK equals pf.NIK
                          join ed in conn.Education on pf.Educationid equals ed.Educationid
                          join un in conn.University on ed.Universityid equals un.Universityid
                          join ar in conn.AccountRole on a.NIK equals ar.NIK
                          join r in conn.Role on ar.RoleId equals r.RoleId

                          select new RegisterVM
                          {
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              Phone = p.Phone,
                              BirthDate = p.BirthDate,
                              Email = p.Email,
                              Salary = p.Salary,
                              NIK = a.NIK,
                              Password = a.Password,
                              Degree = ed.Degree,
                              GPA = ed.GPA,
                              Universityid = un.Universityid,

                              RoleId = r.RoleId

                          }).ToList();

            return result;
        }


        public RegisterVM GetProfilbyId(int nik)
        {
            var result = (from p in conn.Persons
                          join a in conn.Account on p.NIK equals a.NIK
                          join pf in conn.Profiling on a.NIK equals pf.NIK
                          join ed in conn.Education on pf.Educationid equals ed.Educationid
                          join un in conn.University on ed.Universityid equals un.Universityid
                          //where p.NIK = nik
                          select new RegisterVM
                          {

                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              Phone = p.Phone,
                              BirthDate = p.BirthDate,
                              Email = p.Email,
                              Salary = p.Salary,
                              NIK = a.NIK,
                              Password = a.Password,
                              Degree = ed.Degree,
                              GPA = ed.GPA,
                              Universityid = un.Universityid

                          }).ToList();
            return result.FirstOrDefault(a => a.NIK == nik);
        }

        public int Login(RegisterVM registerVM)
        {
            var result = 0;


            var cek = conn.Persons.FirstOrDefault(p => p.Email == registerVM.Email);

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(registerVM.Password, cek.Account.Password);

            if (isValidPassword)
            {
                return 1;
            }
            return result;
        }
        public string GenerateToken(RegisterVM registerVM)
        {
            var person = conn.Persons.Single(p => p.Email == registerVM.Email);
            var ar = conn.AccountRole.Single(ar => ar.NIK == person.NIK);

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                    new Claim("Email", registerVM.Email.ToString()),
                    new Claim("roles", ar.Role.RoleName.ToString())                

                    //new Claim(ClaimTypes.Role, ar.Role.RoleName.ToString())                
                    };          
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);    
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
