using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    private Quaternion CurrentRotation;// = enemy.transform.rotation;
    private Quaternion EndRotation;
    private float RotationTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        CurrentRotation = gameObject.transform.rotation;
        EndRotation = new Quaternion(45, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        RotationTimer += Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Lerp(CurrentRotation, EndRotation, 0.1f * RotationTimer);
    }
}
