using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Income.Web.ViewModels
{
    public class FinanceVm
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual string Currency { get; set; }
    }
}