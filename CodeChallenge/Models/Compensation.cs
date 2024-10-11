using System;

/*
 * File: Compensation.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the Compensation model representing an employee's compensation information.
 */
namespace CodeChallenge.Models
{
    /// <summary>
    /// Represents an employee's compensation information.
    /// </summary>
    public class Compensation
    {
        /// <summary>
        /// Unique identifier for the compensation record.
        /// </summary>
        public string CompensationId { get; set; }

        /// <summary>
        /// The employee associated with this compensation.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The salary amount for the employee.
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// The date from which this compensation is effective.
        /// </summary>
        public DateTime EffectiveDate { get; set; }
    }
}