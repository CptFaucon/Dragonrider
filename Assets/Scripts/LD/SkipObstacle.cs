using UnityEngine;

public class SkipObstacle : MonoBehaviour
{
    private Obstacle o;
    private ScoreManager sm;
    private TutorialManager tm;
    private DodgeObstacle d;

    private void Start()
    {
        d = GetComponentInParent<DodgeObstacle>();
        sm = FindObjectOfType<ScoreManager>();
        tm = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(d.hasDodged != true)
        {
            if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleAvoided();
        }
    }
}
