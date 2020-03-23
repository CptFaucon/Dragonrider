using UnityEngine;

public class CibleRatee : MonoBehaviour
{
    private Cible c;
    private TutorialManager tm;

    private void Start()
    {
        c = GetComponentInParent<Cible>();
        tm = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(c.touched == false)
        {
            if (GameObject.Find("TutorialTextBox") != null) tm.TargetNotHit();
        }
    }
}
