using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Situation Data", menuName = "Situation Data", order = 53)]
public class SituationData : ScriptableObject
{
    public enum Challenge { Spear, Dodging, Observation }

    [Space]
    [SerializeField]
    private Challenge majorChallenge;

    [Range(1, 3)]
    [SerializeField]
    private int difficulty;

    [Serializable]
    public struct Element {

        public ElementData element;
        public Vector3 localPosition;
    }
    
    [Space]
    [SerializeField]
    private Element[] elements;

    public int challengeInt {
        get {
            return Array.IndexOf(Enum.GetValues(majorChallenge.GetType()), majorChallenge);
        }
    }

    public int Difficulty {
        get {
            return difficulty - 1;
        }
    }

    public Element[] Elements {
        get {
            return elements;
        }
    }
}