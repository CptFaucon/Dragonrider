using UnityEngine;

public class AvoidObstacle : MonoBehaviour
{
    private Obstacle o;

    public void Assign(ScoreManager score, Obstacle parent)
    {
        sm = score;
        o = parent;
    }

    private void OnTriggerExit(Collider other)
    {
        if(o.hasCollided != true && d.hasDodged != true)
        {
            if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleAvoided();
        }
    }
}
