using Basee.Data;
using Basee.Mappers;
using Basee.ViewModel;
using Microsoft.AspNetCore.Mvc;

public class RegistrationsController : Controller
{
    private readonly BaseeContext _context;

    public RegistrationsController(BaseeContext context)
    {
        _context = context;
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
        _context.registration.Add(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
