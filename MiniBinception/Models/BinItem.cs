using System;
using System.Collections.Generic;

namespace MiniBinception.Models
{
    public partial class BinItem
    {
        public BinItem()
        {
            BinItemRef = new HashSet<BinItemRef>();
        }

        public long BinItemId { get; set; }
        public DateTimeOffset SysCreated { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTimeOffset SysLastModified { get; set; }
        public string SysLastModifiedBy { get; set; }
        public long ItemId { get; set; }
        public string Uic { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
        public string ItemType { get; set; }
        public string Source { get; set; }

        public virtual ICollection<BinItemRef> BinItemRef { get; set; }
    }
}
