using UnityEngine;

public class EquipementSlot : MonoBehaviour
{
    public Enums.EquipementType equipementType;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    public void EquipItem(ItemSO item)
    {
        spriteRenderer.sprite = item.sprite;
    }

}
