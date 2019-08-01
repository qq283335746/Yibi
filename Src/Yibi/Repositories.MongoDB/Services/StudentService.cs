using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yibi.NoSqlCore.Services;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.MongoDB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoDbContext _context;

        public StudentService(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Students>> GetAllAsync()
        {
            var datas = await _context.Students.FindAsync(FilterDefinition<Students>.Empty);
 
            return await datas.ToListAsync();
        }

        public async Task<int> AddAsync(Students studentInfo)
        {
            studentInfo.Id = Guid.NewGuid();

            await _context.Students.InsertOneAsync(studentInfo);

            return 1;
        }

        public async Task<int> EditAsync(Students studentInfo)
        {
            var oldStudentInfo = await (await _context.Students.FindAsync(m => m.Id.Equals(studentInfo.Id))).FirstOrDefaultAsync();
            if (oldStudentInfo == null) return 0;

            var result = await _context.Students.ReplaceOneAsync(m => m.Id.Equals(studentInfo.Id), studentInfo);

            return result.IsAcknowledged ? 1 : 0;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await _context.Students.DeleteOneAsync(m => m.Id.Equals(id));
            return result.IsAcknowledged ? 1 : 0;
        }
    }
}
