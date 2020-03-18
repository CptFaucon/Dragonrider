using UnityEngine;

public class Obstacle : Scorable
{
    private ScoreManager sm;
    private Renderer r;

    public bool hasCollided;

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        r = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sm.modifyScore(scoreMalus);
        r.enabled = false;
        hasCollided = true;
    }
}
