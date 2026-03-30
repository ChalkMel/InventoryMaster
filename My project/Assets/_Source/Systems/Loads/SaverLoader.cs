using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Collections.Generic;
public class SaverLoader : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemCollection itemCollection;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    
    private const string file_name = "inventory_save.json";
    private string _filePath;

    private void Start()
    {
        _filePath = Path.Combine(Application.persistentDataPath, file_name);
        Load();
        inventory.OnInventoryChange += Save;
    }

    public void Save()
    { 
        InventoryDataModel dataModel = new InventoryDataModel();
        
        List<Slot> filledSlots = inventory._slots;
        foreach (var slot in filledSlots)
        {
            if (slot.item != null)
            {
                ItemDataModel itemModel = new ItemDataModel
                {
                    ItemId = slot.item.ItemId,
                    SlotId = slot.Id,
                    Name = slot.item.Name,
                    Description = slot.item.Description,
                    Price = slot.item.Price
                };
                dataModel.Items.Add(itemModel);
            }
        }
            
        string json = JsonConvert.SerializeObject(dataModel, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    public void Load()
    {
        if (!File.Exists(_filePath))
        {
            Debug.LogWarning("No save found");
            inventory.ClearWhole();
            return;
        }
        
        string json = File.ReadAllText(_filePath);
        InventoryDataModel dataModel = JsonConvert.DeserializeObject<InventoryDataModel>(json);
        inventory.ClearWhole();

        foreach (var itemModel in dataModel.Items)
        {
            ItemData foundItem = FindItemById(itemModel.ItemId);

            if (foundItem != null)
            {
                inventory.AddItemToSlot(foundItem, itemModel.SlotId);
            }
        }

        Debug.Log($"Loaded");
    }
    
    private ItemData FindItemById(int itemId)
    {
        return itemCollection.allItems.Find(item => item.ItemId == itemId);
    }
    
    private void OnDestroy()
    {
        if (inventory != null)
            inventory.OnInventoryChange -= Save;
    }
}