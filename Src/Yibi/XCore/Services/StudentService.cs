using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yibi.Core.Entities;

namespace Yibi.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IContext _context;

        public StudentService(IContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Students studentInfo)
        {
            //await _context.Students.AddAsync(studentInfo);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Students>> GetAllAsync()
        {
            //return await _context.Students.ToListAsync();

            return null;
        }
    }
}
