using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

/*
 * File: CompensationController.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the controller for handling Compensation related HTTP requests.
 */
namespace CodeChallenge.Controllers
{
    /// <summary>
    /// Controller for handling Compensation-related HTTP requests.
    /// </summary>
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        /// <summary>
        /// Creates a new compensation record.
        /// </summary>
        /// <param name="compensation">The compensation data to create.</param>
        /// <returns>The created compensation record.</returns>
        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for employee '{compensation.Employee.EmployeeId}'");

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationByEmployeeId", new { employeeId = compensation.Employee.EmployeeId }, compensation);
        }

        /// <summary>
        /// Retrieves a compensation record by employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The compensation record if found, otherwise 404 Not Found.</returns>
        [HttpGet("{employeeId}", Name = "getCompensationByEmployeeId")]
        public IActionResult GetCompensationByEmployeeId(string employeeId)
        {
            _logger.LogDebug($"Received compensation get request for employee '{employeeId}'");

            var compensation = _compensationService.GetByEmployeeId(employeeId);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
    }
}