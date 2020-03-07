using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element Data", menuName = "Element Data", order = 54)]
public class ElementData : ScriptableObject
{
    [Space]
    [SerializeField]
    private GameObject element;

    [Space]
    [TextArea]
    [SerializeField]
    private string description;

    public GameObject Element {
        get {
            return element;
        }
    }
    
    private int index;

    public int Index {
        get {
            return index;
        }
    }

    public void setIndex(int newIndex) {

        index = newIndex;
    }
}
