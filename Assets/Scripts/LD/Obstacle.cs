using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ScoreManager sm;
    private Renderer r;

    public bool hasCollided;
    public float scoreMalus;
    public float scoreBonus;

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
