using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Interactables
{

    [SerializeField] private float HealingAmount;

    [SerializeField] private GameObject _Player;
                     private PlayerHealth _PlayerScript;

    [SerializeField] private GameObject MedkitObject;
    void Start()
    {
        _PlayerScript = _Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if (_PlayerScript.GetHealthValue() != _PlayerScript.MaxHealth) {
            _PlayerScript.RestoreHealth(HealingAmount);
            MedkitObject.SetActive(false);
        }
    }
}
