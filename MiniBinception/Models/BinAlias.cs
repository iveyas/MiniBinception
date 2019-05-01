using System;
using System.Collections.Generic;

namespace MiniBinception.Models
{
    public partial class BinAlias
    {
        public long BinAliasId { get; set; }
        public DateTimeOffset SysCreated { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTimeOffset SysLastModified { get; set; }
        public string SysLastModifiedBy { get; set; }
        public long BinId { get; set; }
        public long BinAliasFamilyId { get; set; }
        public string Name { get; set; }

        public virtual Bin Bin { get; set; }
        public virtual BinAliasFamily BinAliasFamily { get; set; }
    }
}
