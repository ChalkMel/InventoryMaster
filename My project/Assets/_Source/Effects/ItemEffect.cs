using System;
using System.Collections.Generic;
using UnityEngine;
public abstract class ItemEffect : ScriptableObject
{
  public abstract void OnReceive(Inventory inventory);
}