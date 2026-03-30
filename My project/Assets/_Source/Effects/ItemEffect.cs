using System;
using System.Collections.Generic;
using UnityEngine;
public abstract class ItemEffect : ScriptableObject
{
  public abstract void OnReceive(Inventory inventory);

  public void OnUse(Inventory inventory, ItemData item)
  {
    throw new NotImplementedException();
  }

  public void OnDrop(Inventory inventory, ItemData item)
  {
    throw new NotImplementedException();
  }
}