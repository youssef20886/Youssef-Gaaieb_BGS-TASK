public class MerchantNpc : Npc, IInteractable
{
    public void Interact()
    {
        print("You are interacting with " + npcName);
    }
}
