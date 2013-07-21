using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace _01.MongoDictionary
{
    class Word : IWord
    {
        public Word(string word, string translation)
        {
            this.GetWord = word;
            this.GetTranslation = translation;
        }

        public ObjectId _id { get; set; }

        public string GetWord { get; set; }
        public string GetTranslation { get; set; }

    }

    interface IWord
    {
        string GetWord { get; set; }
        string GetTranslation { get; set; }
    }
}
