using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Element Data", menuName = "Element Data", order = 54)]
public class ElementData : ScriptableObject
{
    [Space]
    [SerializeField]
    private Scorable element;

    [Space]
    [TextArea]
    [SerializeField]
    private string description;

    public enum ScoreBonus { Low, Medium, High }
    [SerializeField]
    private ScoreBonus score;

    public Scorable Element {
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

    public int Score {
        get {
            return Array.IndexOf(Enum.GetValues(score.GetType()), score);
        }
    }
}
