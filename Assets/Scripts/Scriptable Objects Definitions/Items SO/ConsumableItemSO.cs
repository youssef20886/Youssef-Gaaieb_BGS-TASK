using UnityEngine;

[CreateAssetMenu(fileName = "Consumable Item_", menuName = "Consumable ItemSO", order = 1)]
public class ConsumableItemSO : ItemSO 
{
    public bool isStackable = false;
    public int maxNumberOfStacks = 1;
}
