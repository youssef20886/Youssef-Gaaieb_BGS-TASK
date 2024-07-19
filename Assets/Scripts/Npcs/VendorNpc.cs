using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorNpc : Npc, IInteractable
{
    public void Interact()
    {
        print("You are interacting with " + npcName);
    }
}
