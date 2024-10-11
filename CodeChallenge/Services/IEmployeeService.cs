using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * File: IEmployeeService.cs
 * Modified By: Nathaniel Angus
 * Modified: 2024-10-10
 * Description: This file defines the interface for Employee service operations.
 */
namespace CodeChallenge.Services
{
    /// <summary>
    /// Interface for Employee service operations.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee if found, otherwise null.</returns>
        Employee GetById(String id);

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The employee to create.</param>
        /// <returns>The created employee.</returns>
        Employee Create(Employee employee);

        /// <summary>
        /// Replaces an existing employee with a new employee.
        /// </summary>
        /// <param name="originalEmployee">The original employee to be replaced.</param>
        /// <param name="newEmployee">The new employee data.</param>
        /// <returns>The new employee if successful, otherwise null.</returns>
        Employee Replace(Employee originalEmployee, Employee newEmployee);
    }
}
