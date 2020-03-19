using UnityEngine;

public class avoidObstacle : MonoBehaviour
{
    private ScoreManager sm;
    private Obstacle o;

    public void Assign(ScoreManager score, Obstacle parent)
    {
        sm = score;
        o = parent;
    }

    private void OnTriggerExit(Collider other)
    {
        if (o.hasCollided == false)
        {
            sm.modifyScore(o.scoreBonus);
        }
    }
}
