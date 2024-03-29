using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple serializable dictionary.
/// </summary>
/// <typeparam name="TKey"> The type of the Key of the element. </typeparam>
/// <typeparam name="TValue"> The type of the Value. </typeparam>
[Serializable]
public class SerializedDictionnary<TKey, TValue>
{
    /// <summary>
    /// All of the elements in the dictionary.
    /// </summary>
    [SerializeField]
    private List<Element> _elements;

    /// <summary>
    /// The struct of the element : Contain a key and a value.
    /// </summary>
    [Serializable]
    private struct Element
    {
        [field: SerializeField]
        public TKey Key { get; set; }

        [field: SerializeField]
        public TValue Value { get; set; }
    }

    /// <summary>
    /// The indexer of the dictionary.
    /// </summary>
    /// <param name="key"> The key you want to search. </param>
    /// <exception cref="KeyNotFoundException"> Thrown if the key isn't in the dictionary. </exception>
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
