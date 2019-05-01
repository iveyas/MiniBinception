using System;
using System.Collections.Generic;

namespace MiniBinception.Models
{
    public partial class Bin
    {
        public Bin()
        {
            BinAlias = new HashSet<BinAlias>();
            BinHierarchyBin = new HashSet<BinHierarchy>();
            BinHierarchyParent = new HashSet<BinHierarchy>();
            BinItemRef = new HashSet<BinItemRef>();
        }

        public long BinId { get; set; }
        public DateTimeOffset SysCreated { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTimeOffset SysLastModified { get; set; }
        public string SysLastModifiedBy { get; set; }
        public long BinTypeId { get; set; }
        public string Name { get; set; }
        public DateTime Activation { get; set; }
        public DateTime Termination { get; set; }

        public virtual ICollection<BinAlias> BinAlias { get; set; }
        public virtual ICollection<BinHierarchy> BinHierarchyBin { get; set; }
        public virtual ICollection<BinHierarchy> BinHierarchyParent { get; set; }
        public virtual ICollection<BinItemRef> BinItemRef { get; set; }
    }
}
