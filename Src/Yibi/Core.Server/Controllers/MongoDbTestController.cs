using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yibi.Core.Server.Enums;
using Yibi.NoSqlCore.Services;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Core.Server.Controllers
{
    public class MongoDbTestController : Controller
    {
        private readonly IStudentService _studentService;

        public MongoDbTestController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var result = await Task.Run(() => {
                return "this is MongoDbTest default!";
            });

            return result;
        }

        [HttpGet]
        public async Task<string> HelloWorld()
        {
            var result = await Task.Run(() => {
                return "this is MongoDbTest HelloWorld!";
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
                return new ResponseResult<IEnumerable<Students>> { ResCode = ResCodeOptions.Error, Message=ex.Message };
            }
        }

        [HttpPut]
        public async Task<ResponseResult<int>> AddAsync([FromBody]Students studentInfo)
        {
            try
            {
                if (studentInfo == null) return new ResponseResult<int> { ResCode = ResCodeOptions.Error };

                var effect = await _studentService.AddAsync(studentInfo);

                return new ResponseResult<int> { ResCode = ResCodeOptions.Success };
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
