using UnityEngine;

public class AudioManager : SingletonMonobehaviour<AudioManager>
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private NpcInventory npcInventory;
    [SerializeField] private TradesManager tradesManager;

    public AudioClipRefsSO audioClipRefsSO;
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        playerInventory.OnGoldModified += PlayerInventory_OnGoldModified;
        playerInventory.OnInventoryUpdate += Inventory_OnInventoryUpdate;        
        npcInventory.OnInventoryUpdate += Inventory_OnInventoryUpdate;        

        tradesManager.OnBuy += TradesManager_OnBuy;
        tradesManager.OnSell += TradesManager_OnSell;
    }

    private void OnDisable()
    {
        playerInventory.OnGoldModified += PlayerInventory_OnGoldModified;
        playerInventory.OnInventoryUpdate += Inventory_OnInventoryUpdate;        
        npcInventory.OnInventoryUpdate += Inventory_OnInventoryUpdate;  

        tradesManager.OnBuy -= TradesManager_OnBuy;
        tradesManager.OnSell -= TradesManager_OnSell;
    }

    private void PlayerInventory_OnGoldModified(object sender, PlayerInventory.OnGoldModifiedEventArgs e)
    {
        PlaySound(audioClipRefsSO.coinsSound);
    }

    private void Inventory_OnInventoryUpdate(object sender, Inventory.OnInventoryOpenedEventArgs e)
    {
        if (e.inventoryState)
        {
            PlaySound(audioClipRefsSO.inventoryOpenSound);
        }
        else
        {
            PlaySound(audioClipRefsSO.inventoryCloseSound);
        }
    }

    private void TradesManager_OnBuy(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.purchaseSound);
    }

    private void TradesManager_OnSell(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.sellSound);
    }

    private void PlaySound(AudioClip audioClip, float volume = 0.5f) 
    {
        audioSource.PlayOneShot(audioClip, volume);
    }

    public void PlayRandomFootstepSound()
    {
        int randomClipIndex = Random.Range(0, audioClipRefsSO.footstepSounds.Length);
        float footstepVolume = 0.05f;
        audioSource.PlayOneShot(audioClipRefsSO.footstepSounds[randomClipIndex], footstepVolume);
    }
}
