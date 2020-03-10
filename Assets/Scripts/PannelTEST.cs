using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelTEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G");
        }
    }
}
