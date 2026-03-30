using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
  [SerializeField] private GameObject slotPrefab;
  [SerializeField] public List<Slot> _slots = new List<Slot>();
  public List<ItemData> Items = new List<ItemData>();
  public Action OnInventoryChange;

  private void Awake()
  {
    Slot[] allSlots = gameObject.GetComponentsInChildren<Slot>();
    for (int i = 0; i < allSlots.Length; i++)
    {
      allSlots[i].Id = i;
      _slots.Add(allSlots[i]);
    }
  }

  public void AddItem(ItemData item)
  {
    int slot = GetFreeSlot();
    if (slot >= 0)
    {
      Items.Add(item);
      _slots[slot].DrawItem(item);
      OnInventoryChange?.Invoke();
    }
    else
    {
      Debug.Log($"No free space");
    }
  }
  
  public void AddItemToSlot(ItemData item, int slotId)
  {

    if (_slots[slotId].item != null)
    {
      Debug.Log($"Slot is already occupied");
      return;
    }
    _slots[slotId].DrawItem(item);
    Items.Add(item);
    OnInventoryChange?.Invoke();
  }
  
  public int GetFreeSlot()
  {
    for (int i = 0; i < _slots.Count; i++)
    {
     if (_slots[i].item == null)
     {
        return i;
     }
    }

    return -1;
  }

  public List<Slot> GetFilledSlots()
  {
    List<Slot> filledSlots = new List<Slot>();
    
    foreach (var slot in _slots)
    {
      if (slot.item != null)
      {
        filledSlots.Add(slot);
      }
    }

    return filledSlots.Count == 0 ? null : filledSlots;
  }

  public void RemoveItem(int slotId)
  {
    if (_slots[slotId].item != null)
    {
      Items.Remove(_slots[slotId].item);
      _slots[slotId].ClearItem();
      OnInventoryChange?.Invoke();
    }
  }
    
  public void ClearWhole()
  {
    Items.Clear();
    foreach (var slot in _slots)
    {
      slot.ClearItem();
    }
    OnInventoryChange?.Invoke();
  }
}