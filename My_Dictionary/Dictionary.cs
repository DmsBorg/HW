using System.Collections.Generic;

namespace My_Dictionary
{
    class Dictionary
    {
        public string Name { get; set; }
        public List<DictionaryContent> Contents { get; set; } = new List<DictionaryContent>();
    }
}
