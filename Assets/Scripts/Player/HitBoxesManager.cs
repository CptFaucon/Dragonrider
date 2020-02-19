using UnityEngine;
using System.Collections.Generic;

public class HitBoxesManager : MonoBehaviour
{
    public bool[] isHitboxActivated;

    public KeyCode[] inputs;

    public List<List<EnemyScript>> enemiesOnTrigger = new List<List<EnemyScript>>();
    public ScoreManager sm;


    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();
        foreach (var item in isHitboxActivated)
        {
            enemiesOnTrigger.Add(new List<EnemyScript>());
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
                    enemiesOnTrigger[i][k].gameObject.SetActive(false);
                    sm.modifyScoreGauge(enemiesOnTrigger[i][k].scoreBonus);
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
