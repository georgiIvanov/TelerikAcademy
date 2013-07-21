using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace _02.RedisDictionary
{
    class RedisDbActions
    {
        const string keyPredicate = "word:";

        public static void StoreInHash(string key, string value)
        {
            using (IRedisClient client = new RedisClient())
            {
                var objClient = client.GetTypedClient<string>();

                var hash = objClient.GetHash<string>(keyPredicate + key.ToString());

                hash.Add(key, value);
            }
        }

        public static string GetValue(string key)
        {
            string returnedValue;
            using (IRedisClient client = new RedisClient())
            {

                var objClient = client.GetTypedClient<string>();

                var hash = objClient.GetHash<string>(keyPredicate + key);
                returnedValue = hash[key];
            }

            return returnedValue;
        }

        public static List<KeyValuePair<string, string>> GetKeysAndValues()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            using (IRedisClient client = new RedisClient())
            {

                var objClient = client.GetTypedClient<string>();

                var keys = objClient.GetAllKeys().Where(x => x.StartsWith(keyPredicate));

                foreach (var key in keys)
                {
                    var hash = objClient.GetHash<string>(key);
                    var word = key.Substring(keyPredicate.Length);
                    var val = hash[word];
                    result.Add(new KeyValuePair<string, string>(word, val));
                }
            }

            return result;
        }

    }
}
