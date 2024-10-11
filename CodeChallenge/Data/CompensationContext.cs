using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

/*
 * File: CompensationContext.cs
 * Author: Nathaniel Angus
 * Created: 2024-10-10
 * Description: This file defines the DbContext for handling Compensation data.
 */
namespace CodeChallenge.Data
{
    /// <summary>
    /// DbContext for handling Compensation data.
    /// </summary>
    public class CompensationContext : DbContext
    {
        public CompensationContext(DbContextOptions<CompensationContext> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet for Compensation entities.
        /// </summary>
        public DbSet<Compensation> Compensations { get; set; }
    }
}