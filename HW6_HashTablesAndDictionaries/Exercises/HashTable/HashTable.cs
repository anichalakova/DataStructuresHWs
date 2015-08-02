using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    public LinkedList<KeyValue<TKey, TValue>>[] Slots { get; set; }
    public int Count { get; private set; }
    public const int InitialCapacity = 16;
    public const float FIllFactor = 0.75f;

    public int Capacity
    {
        get { return this.Slots.Length; }
    }

    public HashTable(int capacity = InitialCapacity)
    {
        this.Slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        this.GrowIfNeeded();

        int slotNumber = FindSlotNumber(key);
        if (this.Slots[slotNumber] == null) 
        {
            this.Slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.Slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists! Key:" + key);
            }
        }

        this.Slots[slotNumber].AddLast(new KeyValue<TKey, TValue>(key, value));
        this.Count++;
        // Note: throw an exception on duplicated key
    }

    public int FindSlotNumber(TKey key)
    {
        var slotNumber = Math.Abs(key.GetHashCode())%this.Slots.Length;
        return slotNumber;
    }

    public void GrowIfNeeded()
    {
        if ((float)(this.Count+1)/this.Capacity > FIllFactor)
        {
            this.Grow();
        }
    }

    public void Grow()
    {
        var newHashTable = new HashTable<TKey, TValue>(this.Capacity*2);
        foreach (var element in this)
        {
            newHashTable.Add(element.Key, element.Value);
        }

        this.Slots = newHashTable.Slots;
        this.Count = newHashTable.Count;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        this.GrowIfNeeded();

        int slotNumber = FindSlotNumber(key);
        if (this.Slots[slotNumber] == null)
        {
            this.Slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        var keyFound = false;
        foreach (var element in this.Slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                keyFound = true;
            }
        }

        if (!keyFound)
        {
            this.Slots[slotNumber].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
        }
        return true;
    }

    public TValue Get(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            throw new KeyNotFoundException("Key not found! Key: " + key);
        }
        return element.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key); 
        }
        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var element = this.Find(key);
        if (element != null)
        {
            value = element.Value;
            return true;
        }
        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        var slotNumber = FindSlotNumber(key);
        if (this.Slots[slotNumber] != null)
        {
            foreach (var element in this.Slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    return element;
                }
            }
        }
        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var slotNumber = FindSlotNumber(key);
        if (this.Slots[slotNumber] != null)
        {
            foreach (var element in this.Slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool Remove(TKey key)
    {
        var slotNUmber = FindSlotNumber(key);
        if (this.Slots[slotNUmber] != null)
        {
            foreach (var element in this.Slots[slotNUmber])
            {
                if (element.Key.Equals(key))
                {
                    this.Slots[slotNUmber].Remove(element);
                    this.Count--;
                    return true;
                }
            }
        }
        return false;
    }

    public void Clear()
    {
        this.Slots = new LinkedList<KeyValue<TKey, TValue>>[this.Capacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get { return this.Select(element => element.Key); }
    }

    public IEnumerable<TValue> Values
    {
        get { return this.Select(element => element.Value); }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var elements in this.Slots)
        {
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    yield return element;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
