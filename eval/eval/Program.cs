using System;
using System.Collections.Generic;

namespace eval
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();

            Console.WriteLine("Test n°1 : Ajout du mot \"Bonjour\"\n");

            trie.insert("Bonjour");

            Console.WriteLine("Test n°2 : Ajout du mot \"Bagette\"\n");

            trie.insert("Bagette");

            Console.WriteLine("Test n°3 : Ajout du mot \"Chapeau\"\n");

            trie.insert("Chapeau");

            Console.WriteLine("Test n°4 : Ajout du mot \"Chateau\"\n");

            trie.insert("Chateau");

            Console.WriteLine("Test n°5 : Test si \"Chateau\" existe\n");

            IsNodeNull(trie.search("Chateau"));

            Console.WriteLine("Test n°6 : Test si \"Chameau\" existe\n");

            IsNodeNull(trie.search("Chameau"));

            Console.WriteLine("Test n°7 : Afficher tous les mots enregistés\n\n");

            List<string> result = trie.collectAllWords(true);
            foreach(string str in result)
            {
                Console.WriteLine(str + "\n");
            }

            Console.WriteLine("Test n°8 : On recommence\n\n");

            result = trie.collectAllWords(true);
            foreach (string str in result)
            {
                Console.WriteLine(str + "\n");
            }

            Console.WriteLine("Test n°9 : Autocompletion de \"Cha\"\n\n");

            result = trie.autocomplete("Cha");
            foreach (string str in result)
            {
                Console.WriteLine(str + "\n");
            }

            Console.WriteLine("Test n°10 : Autocompletion de rien\n\n");

            result = trie.autocomplete("");
            foreach (string str in result)
            {
                Console.WriteLine(str + "\n");
            }
        }

        public static void IsNodeNull(TrieNode node)
        {
            string str;

            str = node == null ? "Le mot n'existe pas." : "Le mot existe, la dernière lettre est " + node.value;

            Console.WriteLine(str + "\n");
        }
    }
}
