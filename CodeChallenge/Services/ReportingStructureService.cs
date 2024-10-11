using System;
using System.Collections.Generic;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

/*
 * File: ReportingStructureService.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file implements the ReportingStructure service for handling business logic.
 */
namespace CodeChallenge.Services
{
    /// <summary>
    /// Service for handling ReportingStructure business logic.
    /// </summary>
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a reporting structure for an employee by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The reporting structure for the employee.</returns>
        public ReportingStructure GetByEmployeeId(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                _logger.LogWarning("Empty employeeId provided");
                return null;
            }

            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID {employeeId} not found");
                return null;
            }

            _logger.LogInformation($"Found employee: {employee.FirstName} {employee.LastName}");

            var reportCount = CountTotalReports(employee);
            _logger.LogInformation($"Counted {reportCount} total reports for employee {employeeId}");

            var reportingStructure = new ReportingStructure
            {
                Employee = employee,
                NumberOfReports = reportCount
            };

            return reportingStructure;
        }

        /// <summary>
        /// Recursively counts the total number of reports under an employee.
        /// </summary>
        /// <param name="employee">The employee to count reports for.</param>
        /// <returns>The total number of reports.</returns>
        private int CountTotalReports(Employee employee)
        {
            if (employee.DirectReports == null || employee.DirectReports.Count == 0)
            {
                return 0;
            }

            int totalReports = 0;
            foreach (var directReport in employee.DirectReports)
            {
                totalReports++;
                var fullDirectReport = _employeeRepository.GetById(directReport.EmployeeId);
                if (fullDirectReport != null)
                {
                    _logger.LogInformation($"Counting reports for {fullDirectReport.FirstName} {fullDirectReport.LastName}");
                    totalReports += CountTotalReports(fullDirectReport);
                }
            }

            return totalReports;
        }
    }
}
