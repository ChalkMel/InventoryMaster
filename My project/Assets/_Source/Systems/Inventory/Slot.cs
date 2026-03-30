using System;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public int Id;
    public Image itemImage;
    public ItemData item = null;

    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }

    public void DrawItem(ItemData newitem)
    {
        item = newitem;
        itemImage.sprite = newitem.Icon;
    }

    public void ClearItem()
    {
        item = null;
        itemImage.sprite = null;
    }
    
}
