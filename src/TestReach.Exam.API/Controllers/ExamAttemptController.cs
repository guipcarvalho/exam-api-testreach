using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Application.Services.Contracts;

namespace TestReach.Exam.Registration.Controllers
{
    [ApiController]
    [Route("exam-attempt")]
    public class ExamAttemptController : ControllerBase
    {
        private readonly IExamAttemptService _service;

        public ExamAttemptController(IExamAttemptService service)
        {
            _service = service;
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file, CancellationToken cancellationToken)
        {
            using var fileStream = file.OpenReadStream();

            var result = await _service.ImportAttempts(fileStream, file.Name.Substring(file.Name.LastIndexOf('.')), cancellationToken);

            if(result.ResponseCode == Core.Enums.Response.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
