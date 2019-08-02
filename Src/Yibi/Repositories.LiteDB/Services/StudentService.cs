using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yibi.NoSqlCore.Services;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.LiteDB.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILiteDbContext _context;

        public StudentService(ILiteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Students>> GetAllAsync()
        {
            var result = await Task.Run(() =>
            {
                return _context.Students.FindAll();
            });

            return result;
        }

        public async Task<int> AddAsync(Students studentInfo)
        {
            var result = await Task.Run(() =>
            {
                _context.Students.Insert(studentInfo);

                return 1;
            });

            return result;
        }

        public async Task<int> EditAsync(Students studentInfo)
        {
            var result = await Task.Run(() =>
            {
                var oldStudentInfo = _context.Students.FindOne(m => m.Id.Equals(studentInfo.Id));
                if (oldStudentInfo == null) return 0;

                var effect = _context.Students.Update(studentInfo);

                return effect ? 1 : 0;
            });

            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await Task.Run(() =>
            {
                return _context.Students.Delete(m => m.Id.Equals(id));
            });

            return result;
        }
    }
}
