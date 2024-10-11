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
 * Description: This file controls the reporting structure API endpoints
 */
namespace CodeChallenge.Controllers
{
    // Controller for reporting structures
    [ApiController]
    [Route("api/reportingstructure")]
    public class ReportingStructureController : ControllerBase
    {
        // Log information and errors
        private readonly ILogger _logger;

        // Service for reporting structures
        private readonly IReportingStructureService _reportingStructureService;

        // Constructor to initialize ReportingStructureController
        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }

        // Get a reporting structure by employee id
        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult GetReportingStructureById(String id)
        {
            try 
            {
                // Log the request
                _logger.LogDebug($"Received reporting structure get request for '{id}'");

                // Create a reporting structure
                var reportingStructure = _reportingStructureService.Create(id);

                // If the reporting structure is not found, return a 404 error
                if (reportingStructure == null)
                {
                    return NotFound();
                }

                // Return the reporting structure
                return Ok(reportingStructure);
            }
            catch (ArgumentException ex)
            {
                // Log a warning if the employee id is invalid
                _logger.LogWarning(ex, $"Invalid EmployeeID: {id}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log an error if there is an error getting the reporting structure
                _logger.LogError(ex, $"Error getting reporting structure for employee '{id}'");
                return StatusCode(500);
            }            
        }
    }
}
