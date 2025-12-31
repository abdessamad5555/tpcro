using Basee.Models;
using Basee.ViewModel;
using System.Security.Cryptography;
using System.Text;

namespace Basee.Mappers
{
    public static class RegistrationMapper
    {
        // ViewModel → Entity
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

        // Entity → ViewModel (optionnel)
        public static registrationVM ToViewModel(registration entity)
        {
            return new registrationVM
            {
                login = entity.login,
                nom = entity.nom,
                prenom = entity.prenom
            };
        }

        // Hash mot de passe (simple mais propre)
        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
