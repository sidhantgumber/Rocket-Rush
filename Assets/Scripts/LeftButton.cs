using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour
{
    private Button leftButton;
    // Start is called before the first frame update
    void Start()
    {
        leftButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (leftButton.on)
        {
            Debug.Log("Pressed");
        }
        else
        {
            Debug.Log("Not Pressed");
        }*/
    }
}
