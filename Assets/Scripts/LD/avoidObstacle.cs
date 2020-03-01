using UnityEngine;

public class avoidObstacle : MonoBehaviour
{
    private ScoreManager sm;
    private Obstacle o;

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        o = GetComponentInParent<Obstacle>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (o.hasCollided == false)
        {
            sm.modifyScore(o.scoreBonus);
        }
    }
}
