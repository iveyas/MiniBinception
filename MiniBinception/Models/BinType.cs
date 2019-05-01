using System;
using System.Collections.Generic;

namespace MiniBinception.Models
{
    public partial class BinType
    {
        public long BinTypeId { get; set; }
        public DateTimeOffset SysCreated { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTimeOffset SysLastModified { get; set; }
        public string SysLastModifiedBy { get; set; }
        public string Name { get; set; }
    }
}
