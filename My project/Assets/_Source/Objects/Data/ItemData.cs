using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/NewItem")]
public class ItemData : ScriptableObject
{
  [SerializeField] private int _itemId;
  public int ItemId => _itemId;
  
  public string Name;
  public string Description;
  public int Price;
  public Sprite Icon;
  public ItemEffect Effect;
  [Range(0f, 100f)]
    public float DropChance = 100f;
  
  private void OnValidate()
  {
    if (_itemId == 0 && !string.IsNullOrEmpty(name))
    {
      _itemId = Mathf.Abs(name.GetHashCode());
#if UNITY_EDITOR
      UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
  }
  
  public void ApplyReceiveEffects(Inventory inventory)
  {  
    if (Effect == null) return;
    Effect.OnReceive(inventory);
  }
}
