using System.Collections;
using UnityEngine;

public class MovementRestricter : MonoBehaviour
{
    private PlayerController pc;

    private void OnTriggerEnter(Collider other)
    {
        if (!pc) {

            pc = other.GetComponent<PlayerController>();
        }
        StartCoroutine(Restrict(transform.localScale.x));
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        RestrictMovement(pc.Limit);
    }

    private IEnumerator Restrict(float aimedMovementRestriction)
    {
        while (Mathf.Abs(pc.currentLimit - aimedMovementRestriction) > .05f) { 

            if (!pc.isOnPause) { 

                float movementRestriction = Mathf.Lerp(pc.currentLimit, aimedMovementRestriction, .05f);
                RestrictMovement(movementRestriction);
            }
            yield return null;
        }
        RestrictMovement(aimedMovementRestriction);
    }

    
    public void RestrictMovement(float movementRestriction)
    {
        pc.currentLimit = movementRestriction;
    }
}
