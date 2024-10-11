using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * File: IReportingStructureService.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the interface for ReportingStructure service operations.
 */
namespace CodeChallenge.Services
{
    /// <summary>
    /// Interface for ReportingStructure service operations.
    /// </summary>
    public interface IReportingStructureService
    {
        /// <summary>
        /// Retrieves a reporting structure for an employee by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The reporting structure for the employee.</returns>
        ReportingStructure GetByEmployeeId(string employeeId);
    }
}