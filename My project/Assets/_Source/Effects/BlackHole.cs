using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BlackHoleEffect", menuName = "ItemEffects/BlackHole")]
public class BlackHole : ItemEffect
{
   public override void OnReceive(Inventory inventory)
   {
      inventory.ClearWhole();
   }

   public void OnUse(Inventory inventory, ItemData item)
   {
      
   }

   public void OnDrop(Inventory inventory, ItemData item)
   {
      
   }
}
