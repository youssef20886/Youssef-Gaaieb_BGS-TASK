using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalGoldTmpro;
    [SerializeField] private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory.OnGoldModified += PlayerInventory_OnGoldModified;  
    }

    private void PlayerInventory_OnGoldModified(object sender, PlayerInventory.OnGoldModifiedEventArgs e)
    {
        totalGoldTmpro.text = e.amount.ToString();
    }
}
