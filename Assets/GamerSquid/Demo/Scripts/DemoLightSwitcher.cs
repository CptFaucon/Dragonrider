using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamerSquid
{
    /***
     *  A demo class to show how to manipulate the GSLight component
     ***/
    public class DemoLightSwitcher : MonoBehaviour
    {
        [SerializeField]
        private GSLight[] lightList;

        // Use this for initialization
        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {
            //If space has been pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Toggle all lights
                foreach (GSLight l in lightList) {
                    l.Toggle();
                }
            }
        }
    }
}

