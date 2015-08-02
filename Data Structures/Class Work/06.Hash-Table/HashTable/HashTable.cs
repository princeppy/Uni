using System;
using System.Collections;
using System.Collections.Generic;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int InitialCapacity = 16;
    private const float LoadFactor = 0.75f;

    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    public HashTable(int capacity = InitialCapacity)
    {
        this.Count = 0;
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    public void Add(TKey key, TValue value)
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }
        int slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException(string.Format("Key already exist: {0}", key));
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);

        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
    }

    private int FindSlotNumber(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % this.slots.Length;

    }

    private void Grow()
    {
        var newSlots = new HashTable<TKey, TValue>(2 * this.Capacity);


        foreach (var element in this.slots)
        {
            if (element != null)
            {
                foreach (var item in element)
                {
                    newSlots.Add(item.Key, item.Value);
                }
            }
        }

        this.slots = newSlots.slots;

    }

    public bool AddOrReplace(TKey key, TValue value)
    {

        var slotNumber = this.FindSlotNumber(key);

        
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }


        foreach (var keyValue in this.slots[slotNumber])
        {
            if (keyValue.Key.Equals(key))
            {
                keyValue.Value = value;
                return true;
            }

        }
        this.slots[slotNumber].AddLast(new KeyValue<TKey, TValue>(key, value));
        this.Count++;

        return false;
    }

    public TValue Get(TKey key)
    {
        var slotNumber = this.FindSlotNumber(key);
        var element = this.slots[slotNumber];
        if (element != null)
        {
            foreach (var keyValue in element)
            {
                if (keyValue.Key.Equals(key))
                {
                    return keyValue.Value;
                }
            }
        }
        else
        {
            throw new KeyNotFoundException("EBAAASI EXCEPTION-a");
        }

        return default(TValue);
    }

    public TValue this[TKey key]
    {
        get
        {
            throw new NotImplementedException();
            // Note: throw an exception on missing key
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        foreach (var linkedList in this.slots)
        {
            if (linkedList != null)
            {
                foreach (var keyValue in linkedList)
                {
                    if (keyValue.Key.Equals(key))
                    {
                        value = keyValue.Value;
                        return true;
                    }
                }
            }
        }
        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slotNumber = this.FindSlotNumber(key);
        var linkedList = this.slots[slotNumber];
        if (linkedList != null)
        {
            foreach (var keyValue in linkedList)
            {
                if (keyValue.Key.Equals(key))
                {
                    return keyValue;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var slotNumber = this.FindSlotNumber(key);
        var element = this.slots[slotNumber];
        if (element == null)
        {
            return false;
        }
        return true;
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var linkedList in this.slots)
        {
            if (linkedList != null)
            {
                foreach (var element in linkedList)
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
