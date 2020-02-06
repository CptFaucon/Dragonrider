using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private HitBoxesManager hitBoxesManager;
    
    public int HitBoxIndex;

    private void Start()
    {
        hitBoxesManager = FindObjectOfType<HitBoxesManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hitBoxesManager.isHitboxActivated[HitBoxIndex] = true;
        hitBoxesManager.enemiesOnTrigger[HitBoxIndex] = other.GetComponent<EnemyScript>();
    }

    private void OnTriggerExit(Collider other)
    {
        hitBoxesManager.isHitboxActivated[HitBoxIndex] = false;
        hitBoxesManager.enemiesOnTrigger[HitBoxIndex] = null;
    }
}
