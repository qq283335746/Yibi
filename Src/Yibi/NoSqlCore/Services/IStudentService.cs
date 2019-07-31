using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yibi.NoSqlCore.Tables;

namespace Yibi.NoSqlCore.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllAsync();

        Task<int> AddAsync(Students studentInfo);
    }
}
