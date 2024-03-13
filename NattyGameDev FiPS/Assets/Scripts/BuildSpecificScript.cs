using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpecificScript : MonoBehaviour
{

    [SerializeField] private GameObject PlayerUI;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        PlayerUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
