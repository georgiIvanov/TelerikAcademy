using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _06.Phonebook
{
    class PhoneBook
    {
        MultiDictionary<string, PhoneEntry> firstNames;
        MultiDictionary<string, PhoneEntry> middleNames;
        MultiDictionary<string, PhoneEntry> lastNames;
        MultiDictionary<string, PhoneEntry> towns;


        public PhoneBook(List<PhoneEntry> entries)
        {
            firstNames = new MultiDictionary<string, PhoneEntry>(true);
            middleNames = new MultiDictionary<string, PhoneEntry>(true);
            lastNames = new MultiDictionary<string, PhoneEntry>(true);
            towns = new MultiDictionary<string, PhoneEntry>(true);

            foreach (var entry in entries)
            {
                firstNames.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.FirstName, new PhoneEntry[] { entry }));
                middleNames.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.MiddleName, new PhoneEntry[] { entry }));
                lastNames.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.LastName, new PhoneEntry[] { entry }));
                towns.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.Town, new PhoneEntry[] { entry }));
            }

        }

        public List<PhoneEntry> Find(string name)
        {
            List<PhoneEntry> foundEntries = new List<PhoneEntry>();

            foundEntries.AddRange(firstNames[name]);
            foundEntries.AddRange(middleNames[name]);
            foundEntries.AddRange(lastNames[name]);

            return foundEntries;
        }

        public List<PhoneEntry> Find(string name, string town)
        {
            List<PhoneEntry> foundEntries = new List<PhoneEntry>();

            ICollection<PhoneEntry> entry = firstNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = middleNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = lastNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            return foundEntries;
        }
    }
}
