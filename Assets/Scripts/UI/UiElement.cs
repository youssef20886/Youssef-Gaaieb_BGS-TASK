using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiElement : MonoBehaviour, IUiElement
{
    private void Start()
    {
        SetActive(false);
    }
    
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }
    
}
