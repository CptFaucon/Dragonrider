public class EnemyScript : PathFollower
{
    private ScoreManager sm;
    public float scoreMalus = -10;
    public float scoreBonus = 10;

    public override void Awake()
    {
        base.Awake();
        OnFinishedPath += DisableEnemy;
        sm = FindObjectOfType<ScoreManager>();
    }

    public void DisableEnemy()
    {
        pm.CurrentWayPointID = 0;
        gameObject.SetActive(false);
        sm.modifyScore(scoreMalus);
    }
}
