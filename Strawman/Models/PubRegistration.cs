using System;
using System.Collections.Generic;

namespace PubApi.Models
{
    public partial class PubRegistration
    {
        public int PubId { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string VisitDate { get; set; }
    }
}
