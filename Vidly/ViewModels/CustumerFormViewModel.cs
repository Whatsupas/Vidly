using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustumerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        // Ienumerable because in the view we dont need funcionality that List<T> provides
        // we want just iterate over membership types
        // and later if we change another collection we do not need to come back here and make changes
        // because of Ienumerable/ loosly copled application principe
        public Customer Customer { get; set; }

        public string Title
        {
            get { return Customer.Id > 0 ? "Edit Customer" : "New Customer"; }
        }
    }
}