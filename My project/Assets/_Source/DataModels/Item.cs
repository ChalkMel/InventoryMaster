using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name { private set; get; }
    public string Description { private set; get; }
    public int Price { private set; get; }
    public int slotId { private set; get; }
    public Sprite Icon;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private TextMeshProUGUI PriceText;

    public void Draw(string _name, string _description, int _price, int _slotId)
    {
        NameText.text = _name;
        DescriptionText.text = _description;
        PriceText.text = _price.ToString();
        slotId = _slotId;
    }
}
