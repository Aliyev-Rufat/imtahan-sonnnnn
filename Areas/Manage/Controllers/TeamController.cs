using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication15.DAL;
using WebApplication15.Models;

namespace WebApplication15.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public TeamController(AppDbContext context,IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Teams.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Team team)
        {

            if (!ModelState.IsValid) return View();
            if (!team.PhotoFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("PhotoFile", "Duzgun daxil et");
                return View();
            }
            string path = _environment.WebRootPath + @"\Upload\";
            string filename = Guid.NewGuid()+team.PhotoFile.FileName;
            using(FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                team.ImgUrl = filename;
            }
            team.ImgUrl = filename;
            _context.Teams.Add(team);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team newteam)
        {
            Team oldteam = _context.Teams.FirstOrDefault(x => x.Id == newteam.Id);
            if (oldteam == null) return NotFound();
            if (!ModelState.IsValid) return View(oldteam);
            if (newteam.PhotoFile != null)
            {

                string path = _environment.WebRootPath + @"\Upload\Team\";
                FileInfo info = new FileInfo(path + oldteam.ImgUrl);
                if (info.Exists)
                {
                    info.Delete();
                }
                string filename = Guid.NewGuid() + newteam.PhotoFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    newteam.PhotoFile.CopyTo(stream);
                }
                oldteam.ImgUrl = filename;

            }
            oldteam.FullName = newteam.FullName;
            oldteam.Position = newteam.Position;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
