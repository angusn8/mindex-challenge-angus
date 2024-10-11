using CodeChallenge.Models;

/*
 * File: ICompensationService.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the interface for Compensation service operations.
 */
namespace CodeChallenge.Services
{
    /// <summary>
    /// Interface for Compensation service operations.
    /// </summary>
    public interface ICompensationService
    {
        /// <summary>
        /// Creates a new compensation record.
        /// </summary>
        /// <param name="compensation">The compensation to create.</param>
        /// <returns>The created compensation.</returns>
        Compensation Create(Compensation compensation);

        /// <summary>
        /// Retrieves a compensation record by employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The compensation record if found, otherwise null.</returns>
        Compensation GetByEmployeeId(string employeeId);
    }
}