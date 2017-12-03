using System;
namespace Aerococina.Models
{
    public class Employee
    {
        public int EmployeeId
        {
            get;
            set;
        }
        public int CompanyId
        {
            get;
            set;
        }
        public string EmployeeNumber
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Telephone
        {
            get;
            set;
        }
        public byte[] Photo
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
        public DateTime RegistrationDate
        {
            get;
            set;
        }
    }
}
