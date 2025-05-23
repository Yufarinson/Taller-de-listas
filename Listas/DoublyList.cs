using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas;

public class DoublyLinkedList<T>
{
    private DoubleNode<T>? head;
    private DoubleNode<T>? tail;

    public int Count { get; private set; } 
    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        Count = 0;
    }

    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);
        Count++;

        if (head == null) 
        {
            head = newNode;
            tail = newNode;
            return;
        }

        if (Comparer<T>.Default.Compare(data, head.Data) < 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
            return;
        }

        if (Comparer<T>.Default.Compare(data, tail!.Data) >= 0)
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
            return;
        }

        var current = head;
        while (current.Next != null && Comparer<T>.Default.Compare(data, current.Next.Data) >= 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }
        current.Next = newNode;
        newNode.Previous = current;
    }

    public string ShowForward()
    {
        if (head == null) return "Lista vacía";

        var output = new StringBuilder();
        var current = head;
        while (current != null)
        {
            output.Append($"{current.Data} <-> ");
            current = current.Next;
        }
        output.Append("null");
        return output.ToString();
    }

    public string ShowBackward()
    {
        if (tail == null) return "Lista vacía";

        var output = new StringBuilder();
        var current = tail;
        while (current != null)
        {
            output.Append($"{current.Data} <-> ");
            current = current.Previous;
        }
        output.Append("null (inicio)");
        return output.ToString();
    }

    public void SortDescending()
    {
        if (head == null || head.Next == null)
        {
            return; 
        }

        bool swapped;
        do
        {
            swapped = false;
            var current = head;
            while (current.Next != null)
            {
                if (Comparer<T>.Default.Compare(current.Data, current.Next.Data) < 0)
                {
                    (current.Data, current.Next.Data) = (current.Next.Data, current.Data);
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }

    public List<T> GetModes()
    {
        var modes = new List<T>();
        if (head == null) return modes;

        var frequencies = new Dictionary<T, int>();
        var current = head;
        int maxFrequency = 0;

        while (current != null)
        {
            if (current.Data == null) 
            {
                current = current.Next;
                continue;
            }
            if (frequencies.ContainsKey(current.Data))
            {
                frequencies[current.Data]++;
            }
            else
            {
                frequencies[current.Data] = 1;
            }
            if (frequencies[current.Data] > maxFrequency)
            {
                maxFrequency = frequencies[current.Data];
            }
            current = current.Next;
        }

        if (maxFrequency > 0) 
        {
            foreach (var pair in frequencies)
            {
                if (pair.Value == maxFrequency)
                {
                    modes.Add(pair.Key);
                }
            }
        }
        return modes;
    }

    public string ShowGraph()
    {
        if (head == null) return "Lista vacía, no se puede generar gráfico.";

        var frequencies = new Dictionary<T, int>();
        var current = head;
        while (current != null)
        {
            if (current.Data == null) 
            {
                current = current.Next;
                continue;
            }
            if (frequencies.ContainsKey(current.Data))
            {
                frequencies[current.Data]++;
            }
            else
            {
                frequencies[current.Data] = 1;
            }
            current = current.Next;
        }

        if (frequencies.Count == 0) return "No hay datos para graficar.";

        var graphOutput = new StringBuilder();
        var sortedFrequencies = frequencies.OrderBy(kvp => kvp.Key, Comparer<T>.Default);

        foreach (var pair in sortedFrequencies)
        {
            graphOutput.Append($"{pair.Key}: ");
            for (int i = 0; i < pair.Value; i++)
            {
                graphOutput.Append('*');
            }
            graphOutput.AppendLine();
        }
        return graphOutput.ToString();
    }

    public bool Exists(T data)
    {
        var current = head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool RemoveOne(T data)
    {
        if (head == null) return false;

        var current = head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                if (current == head)
                {
                    head = head.Next;
                    if (head != null)
                    {
                        head.Previous = null;
                    }
                    else 
                    {
                        tail = null;
                    }
                }
                else if (current == tail)
                {
                    tail = tail.Previous;
                    if (tail != null) 
                    {
                        tail.Next = null;
                    }
                }
                else
                {
                    current.Previous!.Next = current.Next; 
                    current.Next!.Previous = current.Previous; 
                }
                Count--;
                return true; 
            }
            current = current.Next;
        }
        return false; 
    }

    public int RemoveAll(T data)
    {
        int removedCount = 0;
        bool itemRemoved;
        do
        {
            itemRemoved = RemoveOne(data);
            if (itemRemoved)
            {
                removedCount++;
            }
        } while (itemRemoved);
        return removedCount;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        Count = 0;
    }
}