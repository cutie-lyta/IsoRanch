using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializedDictionnary<TKey, TValue>
{
    [SerializeField]
    private List<Element> _elements;

    [Serializable]
    private struct Element
    {
        public TKey Key;
        public TValue Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            var elm = _elements.Find(element => element.Key.Equals(key));
            return elm.Value;
        }

        set
        {
            var elm = _elements.Find(element => element.Key.Equals(key));
            if (elm.Equals(null))
            {
                throw new KeyNotFoundException("Key was not found in the dictionnary.");
            }

            elm.Value = value;

            var index = _elements.IndexOf(elm);
            _elements[index] = elm;
        }
    }
}
