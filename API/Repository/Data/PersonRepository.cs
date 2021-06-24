using API.Context;
using API.Models;
using API.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
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

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("ASP.NetCore", "hai.infodigital@gmail.com"));
                message.To.Add(new MailboxAddress($"{registerVM.FirstName}", $"{registerVM.Email}"));
                message.Subject = "Sucsess Registration Account";
                message.Body = new TextPart("plain")
                {
                    Text = $"Dear, {registerVM.FirstName}" +
                    $" Your Account Successfully Created."
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("hai.infodigital@gmail.com", "#Naufal1998");
                    client.Send(message);
                    client.Disconnect(true);

                }

                return result;
            }
            return result;
        }

        //public int UpdateProfile(Person person)
        //{
        //    int update = 0;
        //    if (person != null)
        //    {
        //        conn.Entry(person).State = EntityState.Modified;
        //        conn.SaveChanges();
        //        update = 1;
        //    }
        //    else
        //    {
        //        update = 0;
        //    }
        //    return update;
        //}

        public int UpdateProfile(RegisterVM registerVM)
        {
            var result = 0;

            Profiling profiling = conn.Profiling.Find(registerVM.NIK);
            Education education = conn.Education.Find(profiling.Educationid);
            education.Universityid = registerVM.Universityid;
            education.Degree = registerVM.Degree;
            education.GPA = registerVM.GPA;
            conn.Update(education);
             result= conn.SaveChanges();
                

            Account account = conn.Account.Find(registerVM.NIK);
            account.NIK = registerVM.NIK;
            if (registerVM.Password.ToString() != "")
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password.ToString());
            
            };
            account.Profiling = profiling;
            conn.Update(account);
            result = conn.SaveChanges();
     

            Person person = conn.Persons.Find(registerVM.NIK);
            person.NIK = registerVM.NIK;
            person.LastName = registerVM.LastName;
            person.Phone = registerVM.Phone;
            person.BirthDate = registerVM.BirthDate;
            person.Salary = registerVM.Salary;
            person.Email = registerVM.Email;
            person.Account = account;
            conn.Update(person);
            result = conn.SaveChanges();

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
        public int DeleteProfilbyId(int nik)
        {

            var person = conn.Persons.Find(nik);
            if (person != null)
            {
                conn.Remove(person);
                conn.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Login(LoginVM loginVM)
        {
            
            var cek = conn.Persons.FirstOrDefault(p => p.Email == loginVM.Email);
            if (cek==null)
            {
                return 404;
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginVM.Password, cek.Account.Password);
            if (isValidPassword)
            {
                return 1;
            }
            
                return 401;
            
           
        }
        public string GenerateToken(LoginVM loginVM)
        {
            var person = conn.Persons.Single(p => p.Email == loginVM.Email);
            var ar = conn.AccountRole.Single(ar => ar.NIK == person.NIK);

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                    new Claim("Email", loginVM.Email.ToString()),
                    //new Claim("roles", ar.Role.RoleName.ToString())                

                    new Claim(ClaimTypes.Role, ar.Role.RoleName.ToString())
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }






    }
}
