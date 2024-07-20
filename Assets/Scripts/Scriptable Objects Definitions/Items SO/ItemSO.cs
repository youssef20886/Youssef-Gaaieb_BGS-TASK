using UnityEngine;

public abstract class ItemSO : ScriptableObject 
{
    public string itemName;
    public Sprite icon;
    public Sprite sprite;
    public int price;
    public Enums.Rarity rarity;

}