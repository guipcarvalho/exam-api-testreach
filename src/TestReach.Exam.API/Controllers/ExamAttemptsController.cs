using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Application.Services.Contracts;

namespace TestReach.Exam.Registration.Controllers
{
    [ApiController]
    [Route("exam-attempts")]
    public class ExamAttemptsController : ControllerBase
    {
        private readonly IExamAttemptService _service;

        public ExamAttemptsController(IExamAttemptService service)
        {
            _service = service;
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please send a file to be imported");

            using var fileStream = file.OpenReadStream();

            var result = await _service.ImportAttempts(fileStream, file.FileName.Substring(file.FileName.LastIndexOf('.') + 1), cancellationToken);

            if(result.ResponseCode == Core.Enums.Response.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("export/exam/{examId}/candidate/{candidateEmail}")]
        public async Task<IActionResult> ExportExamAttemptToFile(string examId, string candidateEmail, CancellationToken cancellationToken)
        {
            var result = await _service.ExportExamAttemptToFile(examId, candidateEmail, "csv", cancellationToken);

            var file = result.Data as byte[];
            switch (result.ResponseCode)
            {
                case Core.Enums.Response.Success:
                    return File(file, "application/octet-stream", "examAttempt.csv");

                case Core.Enums.Response.NotFound:
                    return NotFound(result);

                default:
                    return BadRequest(result);
            }
        }
    }
}
