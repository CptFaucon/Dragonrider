using UnityEngine;

public class DodgeObstacle : MonoBehaviour
{
    private ScoreManager sm;
    private Obstacle o;
    private TutorialManager tm;
    private SoundManager sdm;

    public bool hasDodged;

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        tm = FindObjectOfType<TutorialManager>();
        sdm = FindObjectOfType<SoundManager>();
        o = GetComponentInParent<Obstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hasDodged = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (o.hasCollided == false)
        {
            sm.modifyScore(o.scoreBonus);
            sdm.playerDodge.Play();
            if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleDodged();
        }
    }
}
