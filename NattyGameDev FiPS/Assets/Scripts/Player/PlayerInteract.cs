using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _Camera;

    [SerializeField] private float RayDistance = 3;
    [SerializeField] private LayerMask Layer;

    private PlayerUI _PlayerUI;
    private InputManager _InputManager;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = GetComponent<PlayerLook>()._Camera;
        _PlayerUI = GetComponent<PlayerUI>();
        _InputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _PlayerUI.UpdateText(string.Empty);
        //Creates a ray at the center of the camera
        Ray ray = new Ray(_Camera.transform.position, _Camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * RayDistance);
        RaycastHit HitInfo; //Variable to store what gets hit by the Raycast

        if (Physics.Raycast(ray, out HitInfo, RayDistance, Layer))
        {
            if(HitInfo.collider.GetComponent<Interactables>()  != null)
            {
                Interactables Interactable = HitInfo.collider.GetComponent<Interactables>();
                _PlayerUI.UpdateText(Interactable.PromptMessage);
                if (_InputManager._OnFootActions.Interact.triggered)
                {
                    Interactable.BaseInteract();
                }
            }
        };
    }
}
