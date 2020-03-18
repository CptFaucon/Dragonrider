using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ScoreManager sm;
    private Renderer r;
    private TutorialManager tm;

    public bool hasCollided;
    public float scoreMalus;
    public float scoreBonus;

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        r = GetComponent<Renderer>();
        tm = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sm.modifyScore(scoreMalus);
        r.enabled = false;
        hasCollided = true;
        if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleTouched();
    }
}
