using System;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;

/*
 * File: ReportingStructure.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file contains the model for an employee's reporting structure
 */
namespace CodeChallenge.Models 
{
    // This class contains the model of an employees
    public class ReportingStructure 
    {
        // Gets or sets the employee for the reporting structure
        public Employee employee { get; set; }
        // Gets or sets the number of direct reports for the employee
        public int numberOfReports { get; set; }
    }
}