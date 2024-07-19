using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyNpc : Npc, IInteractable
{
    public void Interact()
    {
        print("You are interacting with " + gameObject.name);
    }
}
