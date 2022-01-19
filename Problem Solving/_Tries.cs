using System;
using System.Linq;
using System.Collections.Generic;

namespace coding
{

    public class Tries
    {

        class Node
        {
            public char val;
            public bool isWord;
            public Node[] children = new Node[26];

            public Node() { }
            public Node(char c)
            {
                Node node = new Node();
                node.val = c;
            }
        }

        private Node root;

        public Trie()
        {
            root = new Node();
            root.val = ' ';
        }

        public void Insert(string word)
        {
            Node ws = root;
            foreach (char c in word)
            {
                if (ws.children[c - 'a'] == null)
                {
                    ws.children[c - 'a'] = new Node(c);
                }
                ws = ws.children[c - 'a'];
            }
            ws.isWord = true;
        }

        public bool Search(string word)
        {
            Node ws = root;
            foreach (char c in word)
            {
                if (ws.children[c - 'a'] == null) return false;
                ws = ws.children[c - 'a'];
            }
            return ws.isWord;
        }

        public bool StartsWith(string prefix)
        {
            Node ws = root;
            foreach (char c in prefix)
            {
                if (ws.children[c - 'a'] == null) return false;
                ws = ws.children[c - 'a'];
            }
            return true;
        }
    }
}