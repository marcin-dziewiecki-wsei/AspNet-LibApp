using LibApp.Domain.Models;
using System.Collections.Generic;

namespace LibApp.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
}