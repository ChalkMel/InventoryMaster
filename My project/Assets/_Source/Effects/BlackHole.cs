using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BlackHoleEffect", menuName = "ItemEffects/BlackHole")]
public class BlackHole : ItemEffect
{
   public override void OnReceive(Inventory inventory)
   {
      inventory.ClearWhole();
   }
}
