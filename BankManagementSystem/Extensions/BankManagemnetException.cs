using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Extensions
{
    public class BankManagemnetException:Exception
    {
        
            public BankManagemnetException() { }

            public BankManagemnetException(string message)
                : base(String.Format("Please resolve the error: {0}", message))
            {

            }
        
    }
}
