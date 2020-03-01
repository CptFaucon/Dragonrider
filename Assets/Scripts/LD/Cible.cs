using UnityEngine;

public class Cible : MonoBehaviour
{
    private ScoreManager sm;
    public float scoreBonus;

    private void Start()
    {
        sm = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        sm.modifyScore(scoreBonus);
    }
}
