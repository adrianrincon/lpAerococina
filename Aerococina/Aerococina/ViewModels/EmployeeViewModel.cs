using System;
namespace Aerococina.ViewModels
{
    public class EmployeeViewModel
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
        public string StatusDescr
        {
            get
            {
                return Status ? "Activo" : "Inactivo";
            }
        }
        public string NameConcat
        {
            get
            {
                return EmployeeNumber + " - " + Name;
            }
        }
        public DateTime RegistrationDate
        {
            get;
            set;
        }
        public string StatusColor
        {
            get
            {
                return Status ? "Green" : "Red";
            }
        }
    }
}
