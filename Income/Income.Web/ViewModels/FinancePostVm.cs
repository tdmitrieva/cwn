using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Income.Web.ViewModels
{
    public class FinancePostVm
    {
        public string Email { get; set; }
        public FinanceVm Finance { get; set; }
    }
}