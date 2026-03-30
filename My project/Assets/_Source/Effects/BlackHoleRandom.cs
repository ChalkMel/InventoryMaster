using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlackHoleRandomEffect", menuName = "ItemEffects/BlackHoleRandom")]
public class BlackHoleRandom : ItemEffect
{
  [Range(0f, 100f)]
  public float minPercent = 20f;
  [Range(0f, 100f)]
  public float maxPercent = 80f; 
    
  public override void OnReceive(Inventory inventory)
  {
    var filledSlots = inventory.GetFilledSlots();
    if (filledSlots == null || filledSlots.Count == 0)
    {
      Debug.Log("Inventory is empty");
      return;
    }
 
    float removePercent = Random.Range(minPercent, maxPercent);
    int itemsToRemove = Mathf.CeilToInt(filledSlots.Count * removePercent / 100f);
    
    itemsToRemove = Mathf.Min(itemsToRemove, filledSlots.Count);
    
    var slotsToRemove = new List<Slot>(filledSlots);
        
   
    for (int i = 0; i < slotsToRemove.Count; i++)
    {
      int randomIndex = Random.Range(i, slotsToRemove.Count);
      (slotsToRemove[i], slotsToRemove[randomIndex]) = (slotsToRemove[randomIndex], slotsToRemove[i]);
    }
    
    for (int i = 0; i < itemsToRemove; i++)
    {
      if (slotsToRemove[i] != null)
      {
        inventory.RemoveItem(slotsToRemove[i].Id);
      }
    }
  }
}