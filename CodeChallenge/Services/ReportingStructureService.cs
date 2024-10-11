using System;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

/*
 * File: ReportingStructureService.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file adds business logic to create reporting structures
 */
namespace CodeChallenge.Services
{
    // Manages reporting structures implementing IReportingStructureService
    public class ReportingStructureService : IReportingStructureService
    {
        // Repository for data operations with employees
        private readonly IEmployeeRepository _employeeRepository;

        // Log information and errors
        private readonly ILogger<ReportingStructureService> _logger;

        // Constructor to initialize ReportingStructureService
        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        // Create a reporting structure for an employee
        public ReportingStructure Create(String employeeId) 
        {
            // Get the employee by their id
            Employee employee = _employeeRepository.GetById(employeeId);

            // Recursive case
            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID '{employeeId}' not found");
                return null;
            }

            // Get a total count of reports
            int totalReports = GetTotalReports(employee);

            // Create a new ReportingStructure instance and set its properties
            var reportingStructure = new ReportingStructure();
            reportingStructure.employee = employee;
            reportingStructure.numberOfReports = totalReports;


            return reportingStructure;
        }

        // Get the total number of reports for an employee
        public int GetTotalReports(Employee employee)
        {
            // Initialize a count of reports
            int reportCount = 0;

            // Base case
            if (employee == null)
            {
                return reportCount;
            }

            // Count direct reports
            if (employee.DirectReports != null)
            {
                // Add direct reports to count
                reportCount += employee.DirectReports.Count;

                // Recursively count indirect reports
                foreach (var directReport in employee.DirectReports) 
                {
                    // Add indirect reports
                    reportCount += GetTotalReports(directReport);
                }
            }

            return reportCount;
        }
    }
}
