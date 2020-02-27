using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnvironmentManager : MonoBehaviour
{
    /*
    public enum Type {

        City, Land, Road
    }
    public enum Direction {

        Left, Forward, Right
    }

    [Serializable]
    public class Path {

        public Direction direction;
        public PathManager path;
        public GameObject situations;
        public int numberOfObstacles;
    }
    
    [Serializable]
    public class Terrain {

        public Type type;
        public GameObject terrain;
        public Path[] easyPaths;
        public Path[] difficultPaths;
    }
    [Header("   Terrains && Transitions")]
    [SerializeField]
    private Terrain[] terrains;
    
    [Serializable]
    public class Transition {

        public Type currentType;
        public Type newType;
        public PathManager transition;
    }
    [SerializeField]
    private Transition[] transitions;


    [Header("Terrain Variables")]
    [SerializeField]
    private Vector2 dimensions;
    private Vector2[] whereToSpawn = new Vector2[3];

    
    [Header("   Terrains Choice Variables")]
    [SerializeField]
    [Range(0, 100)]
    private int firstChancesToRepeatType;

    [SerializeField]
    [Range(0, 100)]
    private int chanceDecreaseToRepeatType;

    [SerializeField]
    [Range(0, 100)]
    private int difficultRate;
    private int obstacleNb;


    private Terrain[] currentTerrain = new Terrain[2];
    private Transition[] currentTransition = new Transition[2];
    private List<List<Terrain>> terrainTypes = new List<List<Terrain>>();
    private PathManager[] paths = new PathManager[4];
    private int[] iterations = new int[3] { 0, 0, 0 };
    private int repeatCount = 0;
    private int failedObstacles;


    private void Awake()
    {
        for (int i = 0; i < 3; i++) {

            List<Terrain> terrainList = new List<Terrain>();
            Type type = (Type)Enum.GetValues(i.GetType()).GetValue(i);

            foreach (var terrain in terrains) {

                if (terrain.type == type) {

                    terrainList.Add(terrain);
                }
            }

            terrainTypes.Add(terrainList);
        }
    }


    private Transition newTransition(Type currentType, Type newType)
    {
        List<Transition> possibilities = new List<Transition>();

        foreach (var transition in transitions) {

            if (transition.currentType == currentType && transition.newType == newType) {

                possibilities.Add(transition);
            }
        }

        int i = 0;
        return possibilities[UnityEngine.Random.Range(i, possibilities.Count)];
    }


    private Terrain newTerrain(Terrain currentTerrain)
    {
        int currentType = Array.IndexOf(Enum.GetValues(currentTerrain.type.GetType()), currentTerrain.type);

        float random = UnityEngine.Random.Range(0, 100);
        int repeat = Mathf.Clamp(firstChancesToRepeatType - repeatCount * chanceDecreaseToRepeatType, 0, 100);

        List<int> types = new List<int>();

        for (int i = 0; i < 3; i++) {

            types.Add(i);
        }
        types.Remove(currentType);

        int otherOne = types[0];
        int otherTwo = types[1];
        int newType = currentType;


        if (random >= repeat) { 
            
            if (random < repeat + (100 - repeat) * ((float)iterations[otherOne] / iterations[otherTwo])) {

                newType = otherOne;
                repeatCount = 0;
            }
            else {

                newType = otherTwo;
                repeatCount = 0;
            }
        }
        else {

            repeatCount++;
        }

        iterations[newType]++;


        Terrain terrain = terrainTypes[newType][UnityEngine.Random.Range(0, terrainTypes[newType].Count - 1)];

        while (terrain == currentTerrain) {

            terrain = terrainTypes[newType][UnityEngine.Random.Range(0, terrainTypes[newType].Count - 1)];
        }
        return terrain;
    }


    public void ChangeTerrain()
    {
        for (int i = 0; i < 2; i++) {

            paths[i].gameObject.SetActive(false);
        }
        currentTerrain[0].terrain.SetActive(false);
        currentTransition[0].transition.gameObject.SetActive(false);


        currentTerrain[0] = currentTerrain[1];
        currentTerrain[1] = newTerrain(currentTerrain[0]);
        
        currentTransition[0] = currentTransition[1];
        currentTransition[1] = newTransition(currentTerrain[0].type, currentTerrain[1].type);


        /// Activer Current Transition, Current Terrain et leurs Paths
        currentTransition[1].transition.gameObject.SetActive(true);
        currentTerrain[1].terrain.SetActive(true);

        paths[2] = currentTransition[1].transition;


        Path[] possibilities;

        if ((float)failedObstacles / obstacleNb * 100 >= difficultRate) {

            possibilities = currentTerrain[1].difficultPaths;
        }
        else {

            possibilities = currentTerrain[1].easyPaths;
        }


        int random = UnityEngine.Random.Range(0, possibilities.Length);
        obstacleNb = possibilities[random].numberOfObstacles;
        paths[3] = possibilities[random].path;


        for (int i = 2; i < 4; i++) {

            paths[i].gameObject.SetActive(true);
        }
    }
    */
}
