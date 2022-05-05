using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Data
{
    public class Customer
    {
       
        public int CustomerId { get; set; }
       
        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Address { get; set; }
       
        public string State { get; set; }
        
        public string Country { get; set; }
        
        public string EmailId { get; set; }
        
        public string Pan { get; set; }
       
        public string ContactNo { get; set; }
       
        public DateTime DOB { get; set; }
       
        public string AccountType { get; set; }
       
        public DateTime CreatedDate { get; set; }

        public DateTime? Updateddate { get; set; }
        
        public virtual List<Loan> Loans { get; set; }

    }
}
