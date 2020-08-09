using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApi.Models
{
    public class Repo : IRepo
    {
        private readonly AppDbContext appDbContext;

        public Repo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public List<Student> GetStudents()
        {
            return appDbContext.Students.ToList();
        }
    }
}
