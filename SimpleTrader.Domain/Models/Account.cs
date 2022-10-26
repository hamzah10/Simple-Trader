using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Models
{
    public class Account :DomainName
    {
        public double Balance { get; set; }
        public User AccountHandler { get; set; }

        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }
    }       
}
