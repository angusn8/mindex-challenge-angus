using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
 * File: IEmployeeRepository.cs
 * Modified By: Nathaniel Angus
 * Modified: 2024-10-10
 * Description: This file defines the interface for Employee repository operations.
 */
namespace CodeChallenge.Repositories
{
    /// <summary>
    /// Interface for Employee repository operations.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee if found, otherwise null.</returns>
        Employee GetById(String id);

        /// <summary>
        /// Adds a new employee to the repository.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee.</returns>
        Employee Add(Employee employee);

        /// <summary>
        /// Removes an employee from the repository.
        /// </summary>
        /// <param name="employee">The employee to remove.</param>
        /// <returns>The removed employee.</returns>
        Employee Remove(Employee employee);

        /// <summary>
        /// Saves changes asynchronously to the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveAsync();

        /// <summary>
        /// Retrieves all employees from the repository.
        /// </summary>
        /// <returns>An enumerable collection of all employees.</returns>
        IEnumerable<Employee> GetAll();
    }
}