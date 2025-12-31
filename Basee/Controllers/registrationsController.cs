using Basee.Mappers;
using Basee.Repositories.Interfaces;
using Basee.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Basee.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly IRegistrationRepository _repository;

        public RegistrationsController(IRegistrationRepository repository)
        {
            _repository = repository;
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(registrationVM vm)
        {
            if (vm.password != vm.confpass)
            {
                ModelState.AddModelError("confpass", "Les mots de passe ne correspondent pas");
                return View(vm);
            }

            if (!ModelState.IsValid)
                return View(vm);

            var entity = RegistrationMapper.ToEntity(vm);
            await _repository.AddAsync(entity);

            return RedirectToAction("Index");
        }
    }
}
