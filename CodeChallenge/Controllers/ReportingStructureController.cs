using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

/*
 * File: ReportingStructureController.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the controller for handling ReportingStructure related HTTP requests.
 */
namespace CodeChallenge.Controllers
{
    /// <summary>
    /// Controller for handling ReportingStructure-related HTTP requests.
    /// </summary>
    [ApiController]
    [Route("api/reportingstructure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger<ReportingStructureController> _logger;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }

        /// <summary>
        /// Retrieves a reporting structure for an employee by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The reporting structure if found, otherwise 404 Not Found.</returns>
        [HttpGet("{employeeId}")]
        public IActionResult GetReportingStructureByEmployeeId(string employeeId)
        {
            _logger.LogDebug($"Received reporting structure get request for employee '{employeeId}'");

            var reportingStructure = _reportingStructureService.GetByEmployeeId(employeeId);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }
    }
}
