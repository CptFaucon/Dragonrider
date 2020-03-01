using UnityEngine;

public class HitBoxesManager : MonoBehaviour
{
    public bool[] isHitboxActivated;

    public KeyCode[] inputs;

    public EnemyDisabler[] enemiesOnTrigger;
    public ScoreManager sm;
    public EnemyDisabler ed;
    public Enemy e;


    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();
        ed = FindObjectOfType<EnemyDisabler>();
        e = FindObjectOfType<Enemy>();
    }


    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(inputs[i]) && isHitboxActivated[i])
            {
                enemiesOnTrigger[i].DisableEnemy();
                for (int j = 0; j < 6; j++)
                {
                    if (i != j && enemiesOnTrigger[i] == enemiesOnTrigger[j])
                    {
                        enemiesOnTrigger[j] = null;
                        isHitboxActivated[j] = false;
                    }
                }
                sm.modifyScore(e.scoreBonus);
                enemiesOnTrigger[i] = null;
                isHitboxActivated[i] = false;
            }
        }
    }
}
