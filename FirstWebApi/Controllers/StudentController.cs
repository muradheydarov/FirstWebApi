using System.Collections.Generic;
using System.Linq;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {                
        private readonly AppDbContext appDbContext;

        public StudentController(AppDbContext appDbContext)
        {            
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return appDbContext.Students.ToList();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student != null)
            {
                appDbContext.Students.Add(student);
                appDbContext.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (student != null)
            {
                var user = appDbContext.Students.FirstOrDefault(x => x.Id == student.Id);

                if (user != null)
                {
                    appDbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
                    appDbContext.Entry(student).State = EntityState.Modified;

                    appDbContext.SaveChanges();
                }                
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id > 0)
            {
                var user = appDbContext.Students.FirstOrDefault(x => x.Id == id);

                appDbContext.Remove(user);
                appDbContext.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}