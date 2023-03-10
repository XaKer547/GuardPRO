using GuardPRO.API7.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Server=10.0.0.2;User=sa;Password=R1409p1209;Trusted_Connection=true;TrustServerCertificate=true;Integrated Security=false;Database=GuardPRO");


            using MD5 md5Hasher = MD5.Create();
            using var dbContext = new GuardDbContext(optionsBuilder.Options);

            foreach (var user in dbContext.Users.ToArray())
            {
                if (user.Id == 31)
                    continue;

                var hashPassword = Convert.ToHexString(md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                user.Password = hashPassword;
            }
            dbContext.SaveChanges();
        }
    }
}
