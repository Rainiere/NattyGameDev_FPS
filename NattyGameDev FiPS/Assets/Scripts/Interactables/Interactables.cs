using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    //Displayed when looking at object
    public string PromptMessage;

    public void BaseInteract()
    {
        Interact();
    }
protected virtual void Interact()
    {
        //Template to be overridden by subclasses
    }
}
