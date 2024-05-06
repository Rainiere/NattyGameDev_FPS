using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int Damage;
private void OnCollisionEnter(Collision collision)
    {
        Transform HitTransform = collision.transform;
        if (HitTransform.CompareTag("Player")){
            Debug.Log("Player hit!");
            HitTransform.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
