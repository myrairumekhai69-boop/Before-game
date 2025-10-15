using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    public int maxSlots = 8;
    public List<string> items = new List<string>();

    public bool AddItem(string id)
    {
        if (items.Count >= maxSlots) return false;
        items.Add(id);
        Debug.Log("Picked up: " + id);
        return true;
    }

    public bool RemoveItem(string id)
    {
        return items.Remove(id);
    }

    public bool HasItem(string id)
    {
        return items.Contains(id);
    }
}
