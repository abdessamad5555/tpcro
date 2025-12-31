using Basee.Models;
using Basee.ViewModel;
using System.Security.Cryptography;
using System.Text;

namespace Basee.Mappers
{
    public static class RegistrationMapper
    {
        public static registration ToEntity(registrationVM vm)
        {
            return new registration
            {
                login = vm.login,
                password = HashPassword(vm.password),
                nom = vm.nom,
                prenom = vm.prenom,
                tentetive = 0,
                bloque = false
            };
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
