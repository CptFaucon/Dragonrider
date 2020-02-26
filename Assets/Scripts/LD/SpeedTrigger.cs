using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    GameObject playerReference;
    PathMovement pmReference;

    [Header("Nouvelle vitesse du joueur")]
    public float speedModifier;

    void Start()
    {
        playerReference = GameObject.Find("Player");
        pmReference = playerReference.GetComponent<PathMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        pmReference.SpeedModification(speedModifier);
    }
}
