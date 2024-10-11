using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data;

/*
 * File: EmployeeRespository.cs
 * Modified By: Nathaniel Angus
 * Modified: 2024-10-10
 * Description: This file implements the Employee repository for handling data operations.
 */
namespace CodeChallenge.Repositories
{
    /// <summary>
    /// Repository for handling Employee data operations.
    /// </summary>
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee with generated ID.</returns>
        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee if found, otherwise null.</returns>
        public Employee GetById(string id)
        {
            _logger.LogInformation($"Fetching employee with ID: {id}");
            var employee = _employeeContext.Employees
                .Include(e => e.DirectReports)
                .ThenInclude(e => e.DirectReports)
                .SingleOrDefault(e => e.EmployeeId == id);

            if (employee != null)
            {
                _logger.LogInformation($"Found employee: {employee.FirstName} {employee.LastName}");
                _logger.LogInformation($"Direct reports count: {employee.DirectReports?.Count ?? 0}");
            }
            else
            {
                _logger.LogWarning($"Employee with ID {id} not found");
            }

            return employee;
        }

        /// <summary>
        /// Saves changes asynchronously to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an employee from the database.
        /// </summary>
        /// <param name="employee">The employee to remove.</param>
        /// <returns>The removed employee.</returns>
        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>An enumerable collection of all employees.</returns>
        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees
                .Include(e => e.DirectReports)
                .ToList();
        }
    }
}
