using CodeChallenge.Models;
using System.Threading.Tasks;

/*
 * File: ICompensationRepository.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the interface for Compensation repository operations.
 */
namespace CodeChallenge.Repositories
{
    /// <summary>
    /// Interface for Compensation repository operations.
    /// </summary>
    public interface ICompensationRepository
    {
        /// <summary>
        /// Adds a new compensation record.
        /// </summary>
        /// <param name="compensation">The compensation to add.</param>
        /// <returns>The added compensation.</returns>
        Compensation Add(Compensation compensation);

        /// <summary>
        /// Retrieves a compensation record by employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The compensation record if found, otherwise null.</returns>
        Compensation GetByEmployeeId(string employeeId);

        /// <summary>
        /// Saves changes asynchronously to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveAsync();
    }
}