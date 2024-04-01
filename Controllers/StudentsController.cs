using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentData.Data;
using StudentData.Models;
using StudentData.Models.Domain;

namespace StudentData.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Context mvcContext;

        public StudentsController(Context mvcContext)
        {
            this.mvcContext = mvcContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var students =  await mvcContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentView addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                Fee = addStudentRequest.Fee,
                DateOfBirth = addStudentRequest.DateOfBirth,
                Department = addStudentRequest.Department,
            };


         await mvcContext.Students.AddAsync(student);
         await mvcContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
      
    public async Task<IActionResult> View(Guid id)
        {
          var student = await mvcContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                var viewM = new UpdateStudentView()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Fee = student.Fee,
                    DateOfBirth = student.DateOfBirth,
                    Department = student.Department,
                };
                return await Task.Run(() => View("View", viewM));
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateStudentView model)
        {
            var student= await mvcContext.Students.FindAsync(model.Id);

            if (student != null)
            {
                student.Name = model.Name;
                student.Email = model.Email;    
                student.Fee = model.Fee;
                student.DateOfBirth = model.DateOfBirth;
                student.Department = model.Department;

               await mvcContext.SaveChangesAsync();
            return RedirectToAction("Index");
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStudentView model)
        {
            var student = await mvcContext.Students.FindAsync(model.Id);

            if (student != null)
            {
                mvcContext.Students.Remove(student);
                await mvcContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
