using System;
using System.Collections.Generic;

namespace MiniBinception.Models
{
    public partial class BinAliasFamily
    {
        public BinAliasFamily()
        {
            BinAlias = new HashSet<BinAlias>();
        }

        public long BinAliasFamilyId { get; set; }
        public DateTimeOffset SysCreated { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTimeOffset SysLastModified { get; set; }
        public string SysLastModifiedBy { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BinAlias> BinAlias { get; set; }
    }
}
