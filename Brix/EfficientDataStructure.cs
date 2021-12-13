using System;
using System.Collections.Generic;


namespace Brix
{
    class EfficientDataStructure
    {
        private readonly Dictionary<string, List<string>> _dictionary;

        public EfficientDataStructure(IEnumerable<string> strings)
        {
            _dictionary = new Dictionary<string, List<string>>();

            InitDictionary(strings);
        }

        private void InitDictionary(IEnumerable<string> strings)
        {
            // Each dictionary "key" represent a set of equal strings
            // Each dictionary "value" contains a list of equal strings
            foreach (var word in strings)
            {
                var charsArray = word.ToLower().ToCharArray();
                Array.Sort(charsArray);

                var sortedString = string.Concat(charsArray);

                if (_dictionary.ContainsKey(sortedString))
                {
                    var list = _dictionary[sortedString];
                    list.Add(word);
                }
                else
                {
                    _dictionary.Add(sortedString, new List<string> { word });
                }
            }
        }

        // Search Time Complexity 10 + 5 + 5 + 2 = 22 = O(1)
        public IEnumerable<string> Search(string str)
        {
            var charsArray = str.ToLower().ToCharArray(); // cost 10 = 5 ToLower + 5 ToCharArray 
            Array.Sort(charsArray); // cost 5
            var strToSearch = string.Concat(charsArray); // cost 5 
            return _dictionary.ContainsKey(strToSearch) ? _dictionary[strToSearch] : null; // cost 2 = 1 _dictionary.ContainsKey(strToSearch)  + 1 _dictionary[strToSearch] 
        }
    }
}