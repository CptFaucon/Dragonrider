using UnityEngine;

public class HitBoxesManager : MonoBehaviour
{
    public bool[] isHitboxActivated;

    public KeyCode[] inputs;

    public EnemyScript[] enemiesOnTrigger;
    public ScoreManager sm;


    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();
    }


    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(inputs[i]) && isHitboxActivated[i])
            {
                enemiesOnTrigger[i].gameObject.SetActive(false);
                for (int j = 0; j < 6; j++)
                {
                    if (i != j && enemiesOnTrigger[i] == enemiesOnTrigger[j])
                    {
                        enemiesOnTrigger[j] = null;
                        isHitboxActivated[j] = false;
                    }
                }
                sm.modifyScoreGauge(enemiesOnTrigger[i].scoreBonus);
                enemiesOnTrigger[i] = null;
                isHitboxActivated[i] = false;
            }
        }
    }
}
