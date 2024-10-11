using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

/*
 * File: EmployeeService.cs
 * Modified By: Nathaniel Angus
 * Modified: 2024-10-10
 * Description: This file implements the Employee service for handling business logic.
 */
namespace CodeChallenge.Services
{
    /// <summary>
    /// Service for handling Employee business logic.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The employee to create.</param>
        /// <returns>The created employee.</returns>
        public Employee Create(Employee employee)
        {
            if(employee != null)
            {
                _employeeRepository.Add(employee);
                _employeeRepository.SaveAsync().Wait();
            }

            return employee;
        }

        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee if found, otherwise null.</returns>
        public Employee GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return _employeeRepository.GetById(id);
            }

            return null;
        }

        /// <summary>
        /// Replaces an existing employee with a new employee.
        /// </summary>
        /// <param name="originalEmployee">The original employee to be replaced.</param>
        /// <param name="newEmployee">The new employee data.</param>
        /// <returns>The new employee if successful, otherwise null.</returns>
        public Employee Replace(Employee originalEmployee, Employee newEmployee)
        {
            if(originalEmployee != null)
            {
                _employeeRepository.Remove(originalEmployee);
                if (newEmployee != null)
                {
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _employeeRepository.SaveAsync().Wait();

                    _employeeRepository.Add(newEmployee);
                    // overwrite the new id with previous employee id
                    newEmployee.EmployeeId = originalEmployee.EmployeeId;
                }
                _employeeRepository.SaveAsync().Wait();
            }

            return newEmployee;
        }
    }
}
