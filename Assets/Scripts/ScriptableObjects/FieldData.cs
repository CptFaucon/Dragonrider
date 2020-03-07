using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Field Data", menuName = "Field Data", order = 51)]
public class FieldData : ScriptableObject
{
    public enum Attribute { City, Land, Road }

    [Space]
    [SerializeField]
    private Attribute attribute;

    [Space]
    [SerializeField]
    private GameObject field;

    public int attributeInt {
        get {
            return Array.IndexOf(Enum.GetValues(attribute.GetType()), attribute);
        }
    }

    public GameObject Field {
        get {
            return field;
        }
    }
}