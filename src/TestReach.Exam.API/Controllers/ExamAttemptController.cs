using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> Import()
        {
            return Ok();
        }
    }
}
