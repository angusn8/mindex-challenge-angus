using System;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

/*
 * File: CompensationService.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file implements the Compensation service for handling business logic.
 */
namespace CodeChallenge.Services
{
    /// <summary>
    /// Service for handling Compensation business logic.
    /// </summary>
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository, IEmployeeRepository employeeRepository)
        {
            _compensationRepository = compensationRepository;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new compensation record.
        /// </summary>
        /// <param name="compensation">The compensation to create.</param>
        /// <returns>The created compensation.</returns>
        public Compensation Create(Compensation compensation)
        {
            if(compensation != null)
            {
                // Fetch the full employee details
                var employee = _employeeRepository.GetById(compensation.Employee.EmployeeId);
                if (employee == null)
                {
                    _logger.LogWarning($"Employee with ID {compensation.Employee.EmployeeId} not found.");
                    return null;
                }

                // Set the full employee details in the compensation
                compensation.Employee = employee;

                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        /// <summary>
        /// Retrieves a compensation record by employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The compensation record if found, otherwise null.</returns>
        public Compensation GetByEmployeeId(string employeeId)
        {
            if(!String.IsNullOrEmpty(employeeId))
            {
                return _compensationRepository.GetByEmployeeId(employeeId);
            }

            return null;
        }
    }
}