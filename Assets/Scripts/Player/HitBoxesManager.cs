using UnityEngine;
using System.Collections.Generic;

public class HitBoxesManager : MonoBehaviour
{
    public bool[] isHitboxActivated;

    public KeyCode[] inputs;

    public List<List<Hittable>> enemiesOnTrigger = new List<List<Hittable>>();
    public ScoreManager sm;
    public DisableEnemy ed;
    public Enemy e;


    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();
        foreach (var item in isHitboxActivated)
        {
            enemiesOnTrigger.Add(new List<Hittable>());
        }
    }


    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(inputs[i]) && isHitboxActivated[i])
            {
                for (int k = 0; k < enemiesOnTrigger[i].Count; k++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int l = 0; l < enemiesOnTrigger[j].Count; l++)
                        {
                            if (i != j && enemiesOnTrigger[i][k] == enemiesOnTrigger[j][l])
                            {
                                enemiesOnTrigger[j].Remove(enemiesOnTrigger[j][l]);

                                if (enemiesOnTrigger[j].Count == 0)
                                {
                                    isHitboxActivated[j] = false;
                                }
                            }
                        }
                    }
                    enemiesOnTrigger[i][k].OnHit();
                    enemiesOnTrigger[i].Remove(enemiesOnTrigger[i][k]);
                }

                
                if (enemiesOnTrigger[i].Count == 0)
                {
                    isHitboxActivated[i] = false;
                }
            }
        }
    }
}
