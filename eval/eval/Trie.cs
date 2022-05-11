using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eval
{
    public class Trie
    {
        public TrieNode root; // Racine de l'arbre
        public TrieNode currentNode; // Noeud actuel

        public Trie()
        {
            root = new TrieNode(); // On initialise le root
        }

        public TrieNode search(string word)
        {
            currentNode = root; // On set currentNode sur root
            bool trigger = false; // Il sert à voir si la suite du mot existe ou pas

            while (word.Length > 0 && !trigger) // on regarde si on arrive au bout du mot ou si la suite est introuvable
            {
                TrieNode node = find(word[0]); // on cherche si la première lettre est parmis les children

                if (node == null) 
                {
                    trigger = true;
                }
                else
                {
                    currentNode = node;
                    word = word.Remove(0, 1); // on retire la première lettre du mot pour passer au suivant
                }
            }

            if (!trigger) { return currentNode; }

            return null;
        }
        public void insert(string word)
        {
            currentNode = root;

            bool trigger = false; // permet de savoir si les lettres sont déjà enregistrés ou non

            while (word.Length > 0) // on va jusqu'au bout du mot
            {
                if (!trigger)
                {
                    TrieNode node = find(word[0]); // on regarde si la lettre existe dans les children

                    if (node == null)
                    {
                        trigger = true;
                    }
                    else
                    {
                        currentNode = node;
                        word = word.Remove(0, 1); // on retire la première lettre du mot pour passer à la suivante
                    }
                }
                else
                {
                    TrieNode node = new TrieNode(); 
                    node.value = word[0];
                    currentNode.children.Add(node); // on créer le nouveau node et on l'ajoute aux childrens de la lettre

                    currentNode = node;
                    word = word.Remove(0, 1); // on retire la première lettre du mot pour passer à la suivante
                }
            }

            if (find('*') == null) // on ajoute l'étoile à la fin du mot
            {
                TrieNode node = new TrieNode();
                node.value = '*';
                currentNode.children.Add(node);
            }
        }
        TrieNode find(char letter)
        {
            foreach(TrieNode node in currentNode.children) // on cherche une lettre dans les childrens du currentNode
            {
                if (letter == node.value)
                {
                    return node;
                }
            }
            return null;
        }
        public List<string> collectAllWords(string word)
        {
            List<string> words = new List<string>();
            word += currentNode.value; // on ajoute la lettre au mot partielement formé

            if (find('*') != null)
            {
                words.Add(word); // si on arrive au bout d'un mot, on l'ajoute à words
            }

            foreach (TrieNode node in currentNode.children) // on parcourt les childrens du currentNode
            {
                currentNode = node; // on repositionne currentNode pour la récursion
                List<string> resultTemp = collectAllWords(word); // appel récursif

                foreach (string str in resultTemp) // on récupère les résultats
                {
                    words.Add(str);
                }
            }
            return words;
        }
        public List<string> collectAllWords(bool eraze)
        {
            if (eraze) { currentNode = root; } // on regarde si on doit repositionner currentNode sur root ou pas
            List<string> result = new List<string>();

            foreach(TrieNode node in currentNode.children) // on parcourt les childrens
            {
                currentNode = node; // repositionne currentNode pour la récursion
                List<string> resultTemp = collectAllWords(""); // appel récursif

                foreach(string str in resultTemp) // récupération des résultats
                {
                    result.Add(str);
                }
            }
            return result;
        }
        public List<string> autocomplete(string prefix)
        {
            currentNode = search(prefix); // on cherche si le préfix existe

            if (currentNode == null) {

                return null; // si non, on renvoi null
            }
            return collectAllWords(false); // sinon on cherche tout les suffix commencant par le préfix
        }

    }
}
