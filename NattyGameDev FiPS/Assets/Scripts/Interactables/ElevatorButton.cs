using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : Interactables
{
    [SerializeField] private GameObject Platform; //GameObject player stands on
                     private Rigidbody PlatformRB;
    private Vector3 PlatformStartPosition;
    [SerializeField] private GameObject HighestPoint; //Invisible GameObject for modifying elevator length and setting its highest point
    [SerializeField] private GameObject LowestPoint; //Invisible GmaeObject for modifying elevator length and setting its lowest point
    [SerializeField] private bool IsUp;
    [SerializeField] private float ElevatorSpeed;
    private bool InMotion = false; //Bool to set if the elevator should be moving or not

    void Start()
    {
        PlatformRB = Platform.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (InMotion)
        {
            if (IsUp) //if the platform is being lowered
            {
                //Platform omhoog doen met lerp
                // OF platform met een rigdbody en velocity bewegen - Player "stotterde" nog steeds, en met een collider ging de elevator niet meer omhoog, en leek de player juist te zwaar.
                // OF OF MoveTo(Waarnaartu, snelheid);
                 //Platform.transform.position =  Vector3.Lerp(PlatformStartPosition, LowestPoint.transform.position, ElevatorSpeed);
                Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, LowestPoint.transform.position, ElevatorSpeed * Time.deltaTime);
                if (Platform.transform.position.y <= LowestPoint.transform.position.y) // Stop the elevator
                {
                    InMotion = false;
                    IsUp = !IsUp;
   
                }
            }
            else //if the platform is being raised
            {
                //Platform omhoog doen met lerp
                // OF Platform met een rigidbody en velocity bewegen
                // OF OF MoveTo(Waarnaartu, snelheid);
                //Platform.transform.position = Vector3.Lerp(PlatformStartPosition, HighestPoint.transform.position, ElevatorSpeed);
                Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, HighestPoint.transform.position, ElevatorSpeed * Time.deltaTime);
                if (Platform.transform.position.y >= HighestPoint.transform.position.y) // Stop the elevator
                {
                    InMotion = false;
                    IsUp = !IsUp;
                }
            }
        }
    }


    protected override void Interact()
{
    
        InMotion = true;
        PlatformStartPosition = Platform.transform.position;
    }
}