using UnityEngine;

public class HitBoxesManager : MonoBehaviour
{
    public bool[] isHitboxActivated;

    public KeyCode[] inputs;

    public GameObject[] enemiesOnTrigger;

    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(inputs[i]) && isHitboxActivated[i])
            {
                enemiesOnTrigger[i].SetActive(false);
                for (int j = 0; j < 6; j++)
                {
                    if (i != j && enemiesOnTrigger[i] == enemiesOnTrigger[j])
                    {
                        enemiesOnTrigger[j] = null;
                        isHitboxActivated[j] = false;
                    }
                }
                enemiesOnTrigger[i] = null;
                isHitboxActivated[i] = false;
            }
        }
    }
}
