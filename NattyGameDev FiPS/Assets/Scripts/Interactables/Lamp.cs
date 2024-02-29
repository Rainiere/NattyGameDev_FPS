using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactables
{
    [SerializeField] private GameObject LightSource;
    [SerializeField] private bool IsActive;
    
    // Start is called before the first frame update
    void Start()
    {
        LightSource.SetActive(IsActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        IsActive = !IsActive;
        LightSource.SetActive(IsActive);
    }
}
