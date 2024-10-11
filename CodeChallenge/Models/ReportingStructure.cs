using System;

/*
 * File: ReportingStructure.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the ReportingStructure model representing an employee's reporting structure.
 */
namespace CodeChallenge.Models
{
    /// <summary>
    /// Represents an employee's reporting structure.
    /// </summary>
    public class ReportingStructure
    {
        /// <summary>
        /// The employee for whom this reporting structure is created.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The number of reports under this employee.
        /// </summary>
        public int NumberOfReports { get; set; }
    }
}