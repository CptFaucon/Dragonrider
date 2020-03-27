
using UnityEngine;

namespace GamerSquid
{
    /***
     *  This class 
     ***/

    [System.Serializable]
    public class EmissiveGameObject
    {

        [SerializeField]
        private GameObject _emissiveObject;     //A game objects that has an emissive material

        [SerializeField]
        private int _emissiveMatIndex;          //0 based index of the emissive material that will be manipulated

        [SerializeField]
        private Color _onColor;                 //The color of the light when turned on

        /***
         *  Get the emissive object 
         ***/
        public GameObject GetEmissiveObject()
        {
            return _emissiveObject;
        }

        /***
         *  Get the index of the material which should have the emissive property modified
         ***/
        public int GetEmissiveMatIndex()
        {
            return _emissiveMatIndex;
        }

        /***
         *  Get the color of the emissive material when the emissive value is on
         ***/
        public Color GetOnColor()
        {
            return _onColor;
        }

    }
}