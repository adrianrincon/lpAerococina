using System;
using SQLite;

namespace Aerococina.Models
{
    public class EmployeeProduct
    {
        public int EmployeeProductId { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CompanyId { get; set; }
        public string CompanyDescription { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string ProductDescription { get; set; }
        public string StatusDescription { get; set; }
        public bool AddedToService { get; set; }
    }
}