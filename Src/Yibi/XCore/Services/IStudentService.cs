using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yibi.Core.Entities;

namespace Yibi.Core.Services
{
    public interface IStudentService
    {
        Task<int> AddAsync(Students studentInfo);

        Task<IEnumerable<Students>> GetAllAsync();
    }
}
