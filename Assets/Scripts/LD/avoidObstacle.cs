using UnityEngine;

public class AvoidObstacle : MonoBehaviour
{
    private Obstacle o;
    private DodgeObstacle d;
    private TutorialManager tm;
    
    void Start()
    {
        o = FindObjectOfType<Obstacle>();
        d = FindObjectOfType<DodgeObstacle>();
        tm = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(o.hasCollided != true && d.hasDodged != true)
        {
            if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleAvoided();
        }
    }
}
