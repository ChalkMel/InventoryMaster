using UnityEngine;
using UnityEngine.UI;
public class Seller : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private Button _button;
    private System.Random _random;
    private void Awake()
    {
      _random = new System.Random();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChooseItem);
    }
    
    public void ChooseItem()
    {
      var filledSlots = inventory.GetFilledSlots();
      if (filledSlots == null)
      {
        Debug.Log("Nothing to sell");
      }
      else
      {
        int rand = _random.Next(filledSlots.Count);
        var slot = filledSlots[rand];
        inventory.RemoveItem(slot.Id);
      }
    }
}
