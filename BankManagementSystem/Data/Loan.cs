using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementSystem.Data
{
    public class Loan
    {
        
        public int LoanId { get; set; }
        
        public int CustomerId { get; set; }
       
        public string LoanType { get; set; }
        
        public double LoanAmount { get; set; }
        
        public DateTime LoanDate { get; set; }
       
        public float RateOfIntrest { get; set; }
        
        public int LoanDuration { get; set; }
    }
}
