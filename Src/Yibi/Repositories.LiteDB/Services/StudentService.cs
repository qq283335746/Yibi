using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yibi.NoSqlCore.Services;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.LiteDB.Services
{
    public class StudentService : IStudentService
    {
        private readonly LiteDbContext _db;

        public StudentService(LiteDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Students>> GetAllAsync()
        {
            var result = await Task.Run(() =>
            {
                var students = _db.Context.GetCollection<Students>();
                return students.FindAll();
            });

            return result;
        }

        public async Task<int> AddAsync(Students studentInfo)
        {
            var result = await Task.Run(() =>
            {
                var students = _db.Context.GetCollection<Students>();
                students.Insert(studentInfo);

                return 1;
            });

            return result;
        }
    }
}
