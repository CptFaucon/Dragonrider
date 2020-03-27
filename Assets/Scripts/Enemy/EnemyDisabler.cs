using UnityEngine;

public class EnemyDisabler : Hittable
{
    [HideInInspector]
    public Enemy parent;

    private TutorialManager tm;
    private SoundManager sdm;

    private void Start()
    {
        tm = FindObjectOfType<TutorialManager>();
        sdm = FindObjectOfType<SoundManager>();
    }

    public override void OnHit()
    {
        parent.EndLife();
        if (GameObject.Find("TutorialTextBox") != null) tm.EnemyKilled();
        sdm.enemyDie.Play();
    }
}
