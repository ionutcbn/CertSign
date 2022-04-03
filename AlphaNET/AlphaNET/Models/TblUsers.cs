using System;
using System.Collections.Generic;

namespace AlphaNET.Models
{
    public partial class TblUsers
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Cnp { get; set; }
        public string IdCardSerial { get; set; }
        public long IdCardNumber { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public string IssuanceDate { get; set; }
        public string ExpiryDate { get; set; }

        public TblCards TblCards { get; set; }
    }
}
