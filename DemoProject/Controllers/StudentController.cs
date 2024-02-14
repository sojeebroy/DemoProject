using DempProect.Database;
using DempProect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DempProect.Controllers
{
    public class StudentController : Controller
    {
        private readonly DemoProjectDbContext demoProjectDbContext;

        public StudentController(DemoProjectDbContext demoProjectDbContext)
        {
            this.demoProjectDbContext = demoProjectDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students =await demoProjectDbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student )
        {
            var students = new Student()
            {
                Id=Guid.NewGuid(),
                Name=student.Name,
                ClassId=student.ClassId,
                DOB=student.DOB,
                Gender=student.Gender,
                CreateDate=DateTime.Now
            };

            await demoProjectDbContext.Students.AddAsync(students);
            await demoProjectDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(Guid id) 
        {
            var student = await demoProjectDbContext.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if (student!=null)
            {
                var viewModel = new Student()
                {
                    Id = student.Id,
                    Name = student.Name,
                    ClassId = student.ClassId,
                    Gender = student.Gender,
                    DOB = student.DOB,  
                    ModificationDate = DateTime.Now,
                      
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student model ) 
        {
            var student = await demoProjectDbContext.Students.FindAsync(model.Id);
            if(student!=null)
            {
                student.Name = model.Name;
                student.ClassId = model.ClassId;
                student.Gender = model.Gender;
                student.DOB = model.DOB;
                student.ModificationDate = DateTime.Now;

                await demoProjectDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View("Index");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            // var student = await demoProjectDbContext.Students.FindAsync(model.Id);
            var student = await demoProjectDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student != null)
            {
                demoProjectDbContext.Students.Remove(student);  
                await demoProjectDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await demoProjectDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                var viewModel = new Student()
                {
                    Id = student.Id,
                    Name = student.Name,
                    ClassId = student.ClassId,
                    Gender = student.Gender,
                    DOB = student.DOB,
                    ModificationDate = DateTime.Now,

                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
    }
}
