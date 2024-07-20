using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public event EventHandler OnSelected;
    private ItemSO itemSO;

    [SerializeField] private Image slotIcon;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedFrame;

    public bool IsEmpty { get; set; }
    public bool IsSelected { get; set; }

    private void Awake()
    {
        button.onClick.AddListener(() => SetIsSelected(true)); 
    }

    public void ClearSlot()
    {
        itemSO = null;
        slotIcon.sprite = null;
        SetIsSelected(false);
        IsEmpty = true;
    }

    public void AddItem(ItemSO item)
    {
        itemSO = item;
        slotIcon.sprite = item.icon;
        IsEmpty = false;
    }

    public ItemSO GetItem()
    {
        return itemSO;
    }

    public void SetIsSelected(bool state)
    {
        if (IsEmpty) return;

        IsSelected = state;

        if (IsSelected)
        {
            OnSelected?.Invoke(this, EventArgs.Empty);
            selectedFrame.SetActive(true);
        }
        else
        {
            selectedFrame.SetActive(false);
        }
    }

    public void PointerEnter()
    {
        if (itemSO == null) return;
        
        print("You are hovering");
    }

    public void PointerExit()
    {
        print("Exit");
    }
}
