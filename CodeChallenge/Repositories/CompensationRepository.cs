using System;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/*
 * File: CompensationRepository.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file implements the Compensation repository for handling data operations.
 */
namespace CodeChallenge.Repositories
{
    /// <summary>
    /// Repository for handling Compensation data operations.
    /// </summary>
    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new compensation record to the database.
        /// </summary>
        /// <param name="compensation">The compensation to add.</param>
        /// <returns>The added compensation with generated ID.</returns>
        public Compensation Add(Compensation compensation)
        {
            compensation.CompensationId = Guid.NewGuid().ToString();
            _compensationContext.Compensations.Add(compensation);
            return compensation;
        }

        /// <summary>
        /// Retrieves a compensation record by employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The compensation record if found, otherwise null.</returns>
        public Compensation GetByEmployeeId(string employeeId)
        {
            return _compensationContext.Compensations
                .Include(c => c.Employee)
                .FirstOrDefault(c => c.Employee.EmployeeId == employeeId);
        }

        /// <summary>
        /// Saves changes asynchronously to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }
    }
}