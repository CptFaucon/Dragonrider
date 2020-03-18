using UnityEngine;

public class EnemyDisabler : Hittable
{
    [HideInInspector]
    public Enemy parent;

    private TutorialManager tm;

    private void Start()
    {
        tm = FindObjectOfType<TutorialManager>();
    }

    public override void OnHit()
    {
        parent.EndLife();

        if (GameObject.Find("TutorialTextBox") != null) tm.EnemyKilled();
    }
}
