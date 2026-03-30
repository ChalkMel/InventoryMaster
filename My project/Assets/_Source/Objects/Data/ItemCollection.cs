using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;
[CreateAssetMenu(fileName = "NewCollection", menuName = "ScriptableObjects/NewCollection")]
public class ItemCollection : ScriptableObject
{ 
  public List<ItemData> allItems = new List<ItemData>();
}
