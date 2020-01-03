using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace AoC.Console
{
    public class CustomResourceReader : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly ResourceManager _resourceManager;
        public CustomResourceReader(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            var resourceSet = _resourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                yield return new KeyValuePair<string, string>((string)entry.Key, (string)entry.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
