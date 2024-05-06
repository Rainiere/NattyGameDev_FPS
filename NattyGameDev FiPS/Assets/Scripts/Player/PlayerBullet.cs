using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBullet : MonoBehaviour
{
    private GameObject _Player;
    private Weapons _Weapons;
    private int Damage;
    private float DeathTimer = 0f;
    [SerializeField] private float MaxDeathTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Weapons = _Player.GetComponent<Weapons>();
        Damage = _Weapons.GetDamageStat();
    }

    void Update()
    {
        DeathTimer += Time.deltaTime;
        if (DeathTimer > MaxDeathTimer) { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform HitTransform = collision.transform;
        if (HitTransform.CompareTag("Enemy"))   
        {
            Debug.Log("Ping ping!");
            HitTransform.GetComponent<Enemy>().TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
