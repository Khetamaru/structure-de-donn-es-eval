using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eval
{
    public class TrieNode
    {
        public char value;
        public List<TrieNode> children;
        public TrieNode()
        {
            children = new List<TrieNode>();
        }
    }
}
