using System;
using BCrypt.Net;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("David1234", SaltRevision.Revision2Y));
            string password = BCrypt.Net.BCrypt.HashPassword("David1234", SaltRevision.Revision2X);
            Console.WriteLine(password);
            Console.WriteLine(BCrypt.Net.BCrypt.Verify("David1234", password));
        }
    }
}