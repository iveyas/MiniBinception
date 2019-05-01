using System;
using System.Collections.Generic;

namespace MiniBinception.Models
{
    public partial class BinHierarchy
    {
        public long BinHierarchyId { get; set; }
        public DateTimeOffset SysCreated { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTimeOffset SysLastModified { get; set; }
        public string SysLastModifiedBy { get; set; }
        public long ParentId { get; set; }
        public long BinId { get; set; }

        public virtual Bin Bin { get; set; }
        public virtual Bin Parent { get; set; }
    }
}
