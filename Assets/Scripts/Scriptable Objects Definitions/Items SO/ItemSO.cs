using UnityEngine;

public abstract class ItemSO : ScriptableObject 
{
    public string itemName;
    public Sprite icon;
    public int price;
    public Enums.Rarity rarity;

}