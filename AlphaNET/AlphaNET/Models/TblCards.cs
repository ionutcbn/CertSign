using System;
using System.Collections.Generic;

namespace AlphaNET.Models
{
    public partial class TblCards
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string ScanType { get; set; }
        public string FileName { get; set; }

        public TblUsers User { get; set; }
    }
}
