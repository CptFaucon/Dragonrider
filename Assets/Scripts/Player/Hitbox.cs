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
        if (!hitBoxesManager.isHitboxActivated[HitBoxIndex])
        {
            hitBoxesManager.isHitboxActivated[HitBoxIndex] = true;
        }
        
        hitBoxesManager.enemiesOnTrigger[HitBoxIndex].Add(other.GetComponent<EnemyDisabler>());
    }

    private void OnTriggerExit(Collider other)
    {
        hitBoxesManager.enemiesOnTrigger[HitBoxIndex].Remove(other.GetComponent<EnemyDisabler>());
        if (hitBoxesManager.enemiesOnTrigger[HitBoxIndex].Count == 0)
        {
            hitBoxesManager.isHitboxActivated[HitBoxIndex] = false;
        }
    }
}
