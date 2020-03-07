using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Transition Data", menuName = "Transition Data", order = 52)]
public class TransitionData : ScriptableObject
{
    public enum Direction { Left, Right }

    [Space]
    [SerializeField]
    private FieldData.Attribute inAttribute;

    [SerializeField]
    private FieldData.Attribute outAttribute;

    [Space]
    [SerializeField]
    private Direction outDirection;

    [Space]
    [SerializeField]
    private GameObject transition;

    public int OutDirection {
        get {
            return Array.IndexOf(Enum.GetValues(outDirection.GetType()), outDirection);
        }
    }

    public int InAttribute {
        get {
            return Array.IndexOf(Enum.GetValues(inAttribute.GetType()), inAttribute);
        }
    }

    public int OutAttribute {
        get {
            return Array.IndexOf(Enum.GetValues(outAttribute.GetType()), outAttribute);
        }
    }

    public GameObject Transition {
        get {
            return transition;
        }
    }
}