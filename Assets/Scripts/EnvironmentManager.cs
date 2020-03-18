using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
[RequireComponent(typeof(BoxCollider))]

public class EnvironmentManager : MonoBehaviour
{
    [Space]
    [Header("__________________DATA__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    private ElementData[] elementData;
    [SerializeField]
    private SituationData[] situationData;
    [SerializeField]
    private FieldData[] fieldData;
    [SerializeField]
    private TransitionData[] transitionData;

    private PathManager player;

    [Space]
    [Header("__________________FIELD__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    private Vector3 dimensions = new Vector3(15, 30, 50);

    [SerializeField]
    private int numberOfFields = 15;

    [SerializeField]
    [Range(0, 100)]
    private int firstChancesToRepeatAttribute = 100;

    [SerializeField]
    [Range(0, 100)]
    private int chanceDecreaseToRepeatAttribute = 25;

    private int repeatCount = 0;
    private Transform[] fields;
    private Transform[] transitions;
    private Vector3[] fieldPositions;
    private Vector3[] transitionPositions;
    private int[] directions;

    [Space]
    [Header("__________________DIFFICULTY__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    [Range(50, 100)]
    private int difficultRateUp = 80;

    [SerializeField]
    [Range(0, 50)]
    private int difficultRateDown = 40;

    [SerializeField]
    [Range(0, 100)]
    private int chanceToHaveLength1Situations = 34;

    private int currentDifficulty;


    [Serializable]
    public class ChallengeChances {

        [SerializeField]
        [Range(0, 100)]
        private int spearChallengeChances = 30;

        [SerializeField]
        [Range(0, 100)]
        private int dodgingChallengeChances = 40;

        [SerializeField]
        [Range(0, 100)]
        private int observationChallengeChances = 30;

        public int[] chances {
            get {
                return new int[] { spearChallengeChances, dodgingChallengeChances, observationChallengeChances };
            }
        }
    }

    [Space]
    [Header("__________________CHALLENGE__________________________________________________________________________________________________________________________________________________________________")]
    [SerializeField]
    private ChallengeChances[] chances = new ChallengeChances[1];


    private int nbOfChallenges = 1;
    private int challengeDone = 0;
    private List<List<List<List<List<SituationData>>>>> situations = new List<List<List<List<List<SituationData>>>>>();
    private List<List<List<List<List<SituationData>>>>> backup = new List<List<List<List<List<SituationData>>>>>();
    private Scorable[,] elements;
    private int[] indexes;
    private int maxIndex = 6;
    
    private int[] majorChallenges;
    private int[] attributes;

    private int fieldIndex = 1;
    private List<Scorable> currentElements = new List<Scorable>();
    private ScoreManager sm;



    private void Awake()
    {
        #region Instantiate all Elements
        
        int length = elementData.Length;
        
        indexes = new int[length];
        
        for (int i = 0; i < length; i++) {
            
            for (int j = 0; j < situationData.Length; j++) {

                for (int k = 0; k < situationData[j].Elements.Length; k++) {

                    if (situationData[j].Elements[k].element == elementData[i]) {

                        situationData[j].Elements[k].element.setIndex(i);
                    }
                }
            }

            indexes[i] = 0;
        }


        elements = new Scorable[length, maxIndex];

        for (int i = 0; i < length; i++) {

            for (int j = 0; j < maxIndex; j++) {

                elements[i, j] = Instantiate(elementData[i].Element);
                elements[i, j].gameObject.SetActive(false);
            }
        }

        #endregion


        #region Classify Situation Data by Difficulty, Major Challenge, Length and Attribute
        
        for (int i = 0; i < 3; i++) {

            situations.Add(new List<List<List<List<SituationData>>>>());
            backup.Add(new List<List<List<List<SituationData>>>>());

            for (int j = 0; j < 3; j++) {

                situations[i].Add(new List<List<List<SituationData>>>());
                backup[i].Add(new List<List<List<SituationData>>>());

                for (int k = 0; k < 3; k++) {

                    situations[i][j].Add(new List<List<SituationData>>());
                    backup[i][j].Add(new List<List<SituationData>>());

                    for (int l = 0; l < 2; l++) {

                        situations[i][j][k].Add(new List<SituationData>());
                        backup[i][j][k].Add(new List<SituationData>());
                    }
                }
            }
        }

        foreach (SituationData data in situationData) {

            int attribute = data.attributeInt;

            if (attribute == 3) {

                for (int i = 0; i < 3; i++) {
                    
                    situations[data.Difficulty][data.challengeInt][i][data.Length].Add(data);
                    backup[data.Difficulty][data.challengeInt][i][data.Length].Add(data);
                }
            }
            else {

                situations[data.Difficulty][data.challengeInt][attribute][data.Length].Add(data);
                backup[data.Difficulty][data.challengeInt][attribute][data.Length].Add(data);
            }
        }

        #endregion


        #region Classify Fields by Attribute
        
        List<List<FieldData>> fieldDatas = new List<List<FieldData>>();

        for (int i = 0; i < 3; i++) {

            fieldDatas.Add(new List<FieldData>());
        }
        
        foreach (FieldData data in fieldData) {
            
            fieldDatas[data.attributeInt].Add(data);
        }

        #endregion


        #region Classify Transitions by Attribute In and Out

        List<List<List<TransitionData>>> transitionDatas = new List<List<List<TransitionData>>>();

        for (int i = 0; i < 3; i++) {

            transitionDatas.Add(new List<List<TransitionData>>());

            for (int j = 0; j < 3; j++) {

                transitionDatas[i].Add(new List<TransitionData>());
            }
        }
        
        foreach (TransitionData data in transitionData) {

            transitionDatas[data.InAttribute][data.OutAttribute].Add(data);
        }

        #endregion


        #region Set Field Indexes (which Field will appear when) and Transition Indexes

        attributes = new int[numberOfFields];

        int[] iterations = new int[3] { 0, 0, 0 };

        int currentAttribute = UnityEngine.Random.Range(0, 3);
        attributes[0] = currentAttribute;
        iterations[currentAttribute]++;

        int currentIndex = UnityEngine.Random.Range(0, fieldDatas[currentAttribute].Count);
        
        List<int[]> fieldIndexes = new List<int[]>();
        fieldIndexes.Add(new int[] { currentAttribute, currentIndex });

        List<int[]> transitionIndexes = new List<int[]>();

        for (int i = 1; i < numberOfFields; i++) {

            float random = UnityEngine.Random.Range(0, 100);
            int repeat = Mathf.Clamp(firstChancesToRepeatAttribute - repeatCount * chanceDecreaseToRepeatAttribute, 0, 100);

            List<int> types = new List<int>();

            for (int j = 0; j < 3; j++) {

                types.Add(j);
            }
            types.Remove(currentAttribute);

            int otherOne = types[0];
            int otherTwo = types[1];
            int newAttribute = currentAttribute;


            if (random >= repeat) {

                float rapport;

                if (iterations[otherOne] == 0) {
                    if (iterations[otherTwo] == 0) {
                        rapport = .5f;
                    }
                    else {
                        rapport = 1;
                    }
                }
                else {
                    if (otherTwo == 0) {
                        rapport = 0;
                    }
                    else {
                        rapport = (float)iterations[otherOne] / iterations[otherTwo];
                    }
                }

                if (random < repeat + (100f - repeat) * rapport) {

                    newAttribute = otherOne;
                    repeatCount = 0;
                }
                else {

                    newAttribute = otherTwo;
                    repeatCount = 0;
                }
            }
            else  {

                repeatCount++;
            }

            attributes[i] = newAttribute;
            iterations[newAttribute]++;

            int newIndex = UnityEngine.Random.Range(0, fieldDatas[newAttribute].Count);

            int[] fIndex = new int[2] { newAttribute, newIndex };

            while (AreIntsEqual(fieldIndexes[i - 1], fIndex)) {

                newIndex = UnityEngine.Random.Range(0, fieldDatas[newAttribute].Count);

                fIndex[1] = newIndex;
            }


            #region Set Transition
            
            int TIndex = UnityEngine.Random.Range(0, transitionDatas[currentAttribute][newAttribute].Count);

            int[] tIndex = new int[4] { currentAttribute, newAttribute, TIndex, transitionDatas[currentAttribute][newAttribute][TIndex].OutDirection };

            if (i > 1) {

                while (AreIntsEqual(transitionIndexes[i - 2], tIndex)) {

                    TIndex = UnityEngine.Random.Range(0, transitionDatas[currentAttribute][newAttribute].Count);

                    tIndex[2] = TIndex;
                    tIndex[3] = transitionDatas[currentAttribute][newAttribute][TIndex].OutDirection;
                }
            }

            transitionIndexes.Add(tIndex);

            #endregion

            
            currentIndex = newIndex;
            currentAttribute = newAttribute;

            fieldIndexes.Add(fIndex);
        }

        #endregion


        #region Instantiate needed Fields and Transitions

        fields = new Transform[numberOfFields];
        transitions = new Transform[numberOfFields - 1];

        for (int i = 0; i < numberOfFields; i++) {

            int index = FieldIndex(i, fieldIndexes);

            if (i > 0 && index != i) {

                fields[i] = fields[index];
            }
            else {

                fields[i] = Instantiate(
                    fieldDatas
                    [fieldIndexes[i][0]]
                    [fieldIndexes[i][1]]
                    .Field.transform
                    );
                fields[i].gameObject.SetActive(false);
            }

            if (i < numberOfFields - 1) { 

                index = FieldIndex(i, transitionIndexes);
                if (i > 0 && index != i) {

                    transitions[i] = transitions[index];
                }
                else {

                    transitions[i] = Instantiate(
                        transitionDatas
                        [transitionIndexes[i][0]]
                        [transitionIndexes[i][1]]
                        [transitionIndexes[i][2]]
                        .Transition.transform
                        );
                    transitions[i].gameObject.SetActive(false);
                }
            }
        }

        #endregion


        #region Set Position && Rotation of Fields and Transitions

        fieldPositions = new Vector3[numberOfFields];
        transitionPositions = new Vector3[numberOfFields];
        directions = new int[numberOfFields];
        int direction = 0;
        directions[0] = direction;

        Vector3 position = Vector3.zero;
        fieldPositions[0] = position;

        for (int i = 1; i < numberOfFields; i++) {

            position += TransitionPosition(direction);
            transitionPositions[i - 1] = position;

            int lastDirection = direction;
            if (transitionIndexes[i - 1][3] == 0) {

                direction = (direction + 3) % 4;
            }
            else {

                direction = (direction + 1) % 4;
            }
            position += FieldPosition(direction, lastDirection);
            fieldPositions[i] = position;
            directions[i] = direction;
        }

        position += TransitionPosition(direction);
        transitionPositions[numberOfFields - 1] = position;

        #endregion


        #region Set Major Challenges

        int chalRandom = UnityEngine.Random.Range(0, chances.Length);
        int[] chal = chances[chalRandom].chances;
        for (int i = 0; i < 3; i++) {
            chal[i] = Mathf.RoundToInt(chal[i] * (float)numberOfFields / 100);
        }

        List<int> chalInt = new List<int>();
        List<int> chalBackup = new List<int>();
        for (int i = 0; i < 3; i++) {

            chalBackup.Add(i);

            for (int j = 0; j < chal[i]; j++) {

                chalInt.Add(i);
            }
        }

        List<int> majorChal = new List<int>();
        for (int i = 0; i < numberOfFields; i++) {

            if (chalInt.Count == 0) {

                int count = chalBackup.Count;
                if (count == 0) {

                    for (int j = 0; j < 3; j++) {

                        chalBackup.Add(i);
                    }
                }

                chalRandom = UnityEngine.Random.Range(0, chalBackup.Count);
                majorChal.Add(chalBackup[chalRandom]);
                chalBackup.Remove(chalBackup[chalRandom]);
            }
            else {

                chalRandom = UnityEngine.Random.Range(0, chalInt.Count);
                majorChal.Add(chalInt[chalRandom]);
                chalInt.Remove(chalInt[chalRandom]);
            }
        }

        majorChallenges = majorChal.ToArray();

        #endregion

        
        player = FindObjectOfType<PathMovement>().PathToFollow;
        sm = FindObjectOfType<ScoreManager>();
        GetComponent<Collider>().isTrigger = true;
        SetFieldActive(0);
    }


    private int FieldIndex(int currentIndex, List<int[]> indexes)
    {
        for (int i = 0; i < currentIndex; i++) {

            if (AreIntsEqual(indexes[currentIndex], indexes[i])) {

                return i;
            }
        }

        return currentIndex;
    }


    private bool AreIntsEqual(int[] a, int[] b)
    {
        for (int i = 0; i < a.Length; i++) {

            if (a[i] != b[i]) {

                return false;
            }
        }

        return true;
    }


    private Vector3 TransitionPosition(int direction)
    {
        if (direction == 0) {

            return new Vector3(0, 0, dimensions[2]);   /// Forward
        }
        else if (direction == 1) {

            return new Vector3(dimensions[2], 0, 0);   /// Right
        }
        else if (direction == 2) {

            return new Vector3(0, 0, -dimensions[2]);   /// Back
        }
        else {

            return new Vector3(-dimensions[2], 0);   /// Left
        }
    }

    
    private Vector3 FieldPosition(int currentDirection, int lastDirection)
    {
        if (currentDirection == 0) {

            int direction = -(lastDirection - 2);
            return new Vector3(direction * dimensions[0], 0, dimensions[1]);   /// Forward
        }
        else if (currentDirection == 1) {

            int direction = -(lastDirection - 1);
            return new Vector3(dimensions[1], 0, direction * dimensions[0]);   /// Right
        }
        else if (currentDirection == 2) {

            int direction = -(lastDirection - 2);
            return new Vector3(direction * dimensions[0], 0, -dimensions[1]);   /// Back
        }
        else {

            int direction = -(lastDirection - 1);
            return new Vector3(-dimensions[1], 0, direction * dimensions[0]);   /// Left
        }
    }


    private Vector3 Rotation(int direction)
    {
        return new Vector3(0, direction * 90, 0);
    }


    private SituationData Situation(int majorChallenge, int attribute, int length)
    {
        int random = 0;
        SituationData sd;

        if (challengeDone / nbOfChallenges * 100 >= difficultRateDown) {

            if (challengeDone / nbOfChallenges * 100 >= difficultRateUp) {

                currentDifficulty = Mathf.Min(currentDifficulty + 1, 2);
            }
        }
        else {

            currentDifficulty = Mathf.Max(currentDifficulty - 1, 0);
        }

        if (situations[currentDifficulty][majorChallenge][attribute][length].Count == 0) {

            foreach (var sit in backup[currentDifficulty][majorChallenge][attribute][length]) {

                situations[currentDifficulty][majorChallenge][attribute][length].Add(sit);
            }
        }

        random = UnityEngine.Random.Range(0, situations[currentDifficulty][majorChallenge][attribute][length].Count);

        sd = situations[currentDifficulty][majorChallenge][attribute][length][random];

        for (int i = 0; i < 3; i++) {

            for (int j = 0; j < situations[currentDifficulty][majorChallenge][i][length].Count; j++) {

                if (sd == situations[currentDifficulty][majorChallenge][i][length][j]) {

                    situations[currentDifficulty][majorChallenge][i][length].Remove(situations[currentDifficulty][majorChallenge][i][length][j]);
                    j--;
                }
            }
        }

        nbOfChallenges = sd.Elements.Length;

        return sd;
    }


    private void SetElementsActive(SituationData situation, Transform currentField, int iteration, Vector3 lastPoint)
    {
        Vector3 position = new Vector3(0, 0, dimensions[2] / 2 * iteration);

        int total = 0;
        foreach (var element in situation.Elements) {

            total += element.element.Score;
        }

        foreach (var element in situation.Elements) {

            int index = element.element.Index;
            elements[index, indexes[index]].transform.SetParent(currentField);
            elements[index, indexes[index]].transform.localPosition = element.localPosition + position;
            elements[index, indexes[index]].transform.localRotation = Quaternion.Euler(element.localRotation);
            elements[index, indexes[index]].gameObject.SetActive(true);
            elements[index, indexes[index]].transform.SetParent(null);
            elements[index, indexes[index]].scoreBonus = sm.bonus[element.element.Score] / total * sm.total[situation.Difficulty];
            currentElements.Add(elements[index, indexes[index]]);
            indexes[index] = (indexes[index] + 1) % maxIndex;
        }

        foreach (var point in situation.Path) {

            AddPathPoint(point + position, currentField);
        }
        
        AddPathPoint(lastPoint, currentField);
    }


    private void AddPathPoint(Vector3 position, Transform parent)
    {
        Transform newPoint = Instantiate(new GameObject(), parent).transform;
        newPoint.localPosition = position;
        newPoint.SetParent(player.transform);
        player.pathTransforms.Add(newPoint);
    }


    private void SetFieldActive(int index)
    {
        SetFieldUnactive(index - 1);

        fields[index].gameObject.SetActive(true);
        fields[index].position = fieldPositions[index];
        fields[index].rotation = Quaternion.Euler(Rotation(directions[index]));

        float random = UnityEngine.Random.Range(0, 100);

        int[] length = random >= chanceToHaveLength1Situations ?
            new int[2] { 0, 1 } :
            new int[2] { 1, 0 } ;
        for (int i = 0; i <= length[1]; i++) {

            Vector3 lastPoint = new Vector3(0, 0, dimensions[2] * (2 + i - length[1]) / 2);
            SetElementsActive(Situation(majorChallenges[index], attributes[index], length[0]), fields[index], i, lastPoint);
        }

        if (index < numberOfFields - 1) {

            transitions[index].gameObject.SetActive(true);
            transitions[index].position = transitionPositions[index];
            transitions[index].rotation = Quaternion.Euler(Rotation(directions[index]));

            PathManager path = transitions[index].GetComponentInChildren<PathManager>();

            if (path) {

                foreach (var point in path.pathTransforms) {

                    AddPathPoint(point.localPosition, path.transform);
                }
            }

            AddPathPoint(fieldPositions[index + 1], null);
        }

        transform.position = transitionPositions[index];
    }


    private void SetFieldUnactive(int index)
    {
        if (index > 0) {

            fields[index - 1].gameObject.SetActive(false);
            transitions[index - 1].gameObject.SetActive(false);
        }

        for (int i = 0; i < currentElements.Count; i++) {

            currentElements[i].gameObject.SetActive(false);
            currentElements.Remove(currentElements[i]);
            i--;
        }
    }


    public void Success()
    {
        challengeDone++;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (fieldIndex < numberOfFields) {

            SetFieldActive(fieldIndex);
            fieldIndex++;
        }
        else {

            /// LAST SITUATION
        }
    }
}