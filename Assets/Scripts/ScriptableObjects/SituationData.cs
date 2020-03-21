using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Situation Data", menuName = "Situation Data", order = 53)]
public class SituationData : ScriptableObject
{
    public enum Attribute { City, Land, Road, None }

    [Space]
    [Header("__________________VARIABLES__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    private Attribute attribute = Attribute.None;

    public enum Challenge { Spear, Dodging, Observation }
    
    [SerializeField]
    private Challenge majorChallenge;
    
    [Range(1, 2)]
    [SerializeField]
    private int length = 1;
    
    [Range(1, 3)]
    [SerializeField]
    private int difficulty = 1;
    
    [Space]
    [Header("__________________PATH__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    private Vector3[] path;

    [Serializable]
    public class Element {

        public ElementData element;
        public Vector3 localPosition;
        public Vector3 localRotation;
        public Vector3 localScale = Vector3.one;
    }
    
    [Space]
    [Header("__________________ELEMENTS__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    private Element[] elements;

    public int attributeInt {
        get {
            return Array.IndexOf(Enum.GetValues(attribute.GetType()), attribute);
        }
    }

    public int challengeInt {
        get {
            return Array.IndexOf(Enum.GetValues(majorChallenge.GetType()), majorChallenge);
        }
    }

    public int Length {
        get {
            return length - 1;
        }
    }

    public int Difficulty {
        get {
            return difficulty - 1;
        }
    }

    public Vector3[] Path {
        get {
            return path;
        }
    }

    public Element[] Elements {
        get {
            return elements;
        }
    }
}