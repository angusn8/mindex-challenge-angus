using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * File: IReportingStructureService.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file serves to define what ReportingStructure service should look like
 */
namespace CodeChallenge.Services
{
    // Defines the ReportingStructure service
    public interface IReportingStructureService
    {
        // Creates a new reporting structure for an employee
        ReportingStructure Create(String employeeId);
    }
}