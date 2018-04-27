using System.Collections.Generic;

namespace code.util
{
    public class ElementLimitCache<TElementKey, TElementValue>
    {
        private long _maxNumberOfElements;
        private Dictionary<TElementKey, TElementValue> _cache;
        private List<TElementKey> _elementsOrder;

        public ElementLimitCache(long maxNumberOfElements)
        {
            _maxNumberOfElements = maxNumberOfElements;
            
            _cache = new Dictionary<TElementKey, TElementValue>();
            _elementsOrder = new List<TElementKey>();
        }
        
        public TElementValue this[TElementKey key]
        {
            get { return _cache[key]; }
            set
            {
                if (_cache.ContainsKey(key))
                    _elementsOrder.Remove(key);
                else if(_cache.Count >= _maxNumberOfElements)
                {
                    var keyToRemove = _elementsOrder[0];

                    Remove(keyToRemove);
                }
                
                _cache[key] = value;
                _elementsOrder.Add(key);
            }
        }

        public void Remove(TElementKey keyToRemove)
        {
            _elementsOrder.Remove(keyToRemove);
            _cache.Remove(keyToRemove);
        }

        public bool ContainsKey(TElementKey key)
        {
            return _cache.ContainsKey(key);
        }
    }
}