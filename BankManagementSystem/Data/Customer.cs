using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementSystem.Data
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters.")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "State cannot exceed 20 characters.")]
        public string State { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "Country cannot null.")]
        public string Country { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "EmailId cannot be empty.")]
        public string EmailId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "Please enter a valid PAN.")]
        public string Pan { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "ContactNo cannot exceed 10 digits.")]
        public string ContactNo { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "AccountType cannot exceed 10 characters.")]
        public string AccountType { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? Updateddate { get; set; }
        public virtual List<Loan> Loans { get; set; }

    }
}
