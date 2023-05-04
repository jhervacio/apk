using System;
using System.Collections.Generic;
using System.Text;

namespace apk.BlockChain
{
    public interface IBlock
    {
        public byte[] Data { get; }
        public byte[] Hash { get; set; }
        public int Nonce { get; set; }
        public byte PrevHash { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public class Block
    {
        byte[] Data { get; set; }
    }
}
