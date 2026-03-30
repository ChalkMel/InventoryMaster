using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemCollection itemCollection;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChooseItem);
    }

    public void ChooseItem()
    {
        var availableItems = new List<ItemData>();
    
        foreach (var item in itemCollection.allItems)
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber <= item.DropChance)
            {
                availableItems.Add(item);
            }
        }
        
        if (availableItems.Count > 0)
        {
            int rand = Random.Range(0, availableItems.Count);
            var item = availableItems[rand];
            inventory.AddItem(item);
            item.ApplyReceiveEffects(inventory);
        }
        else
        {
            Debug.Log("No items dropped");
        }
    }
}
