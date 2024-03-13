using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private GameObject MineObject;
    private Collider MineCollider;
    [SerializeField] private GameObject Player;
    private Collider PlayerCollider;
    private PlayerHealth _PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        MineCollider = GetComponent<Collider>();
        PlayerCollider = Player.GetComponent<Collider>();
        _PlayerHealth = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col != null)
        {
            if (col == PlayerCollider)
            {
                _PlayerHealth.TakeDamage(Damage);
            }
        }
        MineObject.SetActive(false);
    }
}
