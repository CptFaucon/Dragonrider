using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    GameObject playerReference;
    PlayerController pcReference;

    [Header("Nouvelle vitesse du joueur")]
    public float speedModifier;

    void Start()
    {
        playerReference = GameObject.Find("Player");
        pcReference = playerReference.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        pcReference.SpeedModification(speedModifier);
    }
}
