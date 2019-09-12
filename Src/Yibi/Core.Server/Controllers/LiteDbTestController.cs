using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yibi.Core.Server.Enums;
using Yibi.NoSqlCore.Services;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Core.Server.Controllers
{
    public class LiteDbTestController: Controller
    {
        private readonly IStudentService _studentService;

        public LiteDbTestController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var result = await Task.Run(() => {
                return "this is LiteDbTest default!";
            });

            return result;
        }

        [HttpGet]
        public async Task<string> HelloWorld()
        {
            var result = await Task.Run(()=>{
                return "this is HelloWorld!";
            });

            return result;
        }

        [HttpGet]
        public async Task<ResponseResult<IEnumerable<Students>>> GetAllAsync()
        {
            try
            {
                var datas = await _studentService.GetAllAsync();

                return new ResponseResult<IEnumerable<Students>> { ResCode = ResCodeOptions.Success, Data = datas };
            }
            catch(Exception ex)
            {
                return new ResponseResult<IEnumerable<Students>> { ResCode = ResCodeOptions.Error, Message = ex.Message };
            }
        }

        [HttpPut]
        public async Task<ResponseResult<int>> AddAsync([FromBody]Students studentInfo)
        {
            try
            {
                if (studentInfo == null) return new ResponseResult<int> { ResCode = ResCodeOptions.Error };

                var effect = await _studentService.AddAsync(studentInfo);

                return new ResponseResult<int> { ResCode = ResCodeOptions.Success,Data = effect };
            }
            catch(Exception ex)
            {
                return new ResponseResult<int> { ResCode = ResCodeOptions.Error,Message=ex.Message };
            }
        }

        [HttpPut]
        public async Task<ResponseResult<int>> EditAsync([FromBody]Students studentInfo)
        {
            try
            {
                if (studentInfo == null) return new ResponseResult<int> { ResCode = ResCodeOptions.Error };

                var effect = await _studentService.EditAsync(studentInfo);

                return new ResponseResult<int> { ResCode = ResCodeOptions.Success };
            }
            catch (Exception ex)
            {
                return new ResponseResult<int> { ResCode = ResCodeOptions.Error, Message = ex.Message };
            }
        }

        [HttpPut]
        public async Task<ResponseResult<int>> DeleteAsync(Guid id)
        {
            try
            {
                var effect = await _studentService.DeleteAsync(id);

                return new ResponseResult<int> { ResCode = ResCodeOptions.Success };
            }
            catch (Exception ex)
            {
                return new ResponseResult<int> { ResCode = ResCodeOptions.Error, Message = ex.Message };
            }
        }
    }
}
