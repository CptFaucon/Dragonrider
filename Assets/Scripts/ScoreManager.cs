using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private Transform needleTransform;
    private TextMeshProUGUI score;

    [Header("Gestion des multiplicateurs de score")]
    public float minScoreMultiplier = 1f;
    public float normalScoreMultiplier = 2f;
    public float maxScoreMultiplier = 4f;

    private float scoreValue = 0f;
    [SerializeField]
    private float scoreMultiplier = 1f;

    private const float maxScoreAngle = -30f;
    private const float minScoreAngle = 210f;
    private float scoreGauge = 210f;

    private void Start()
    {
        needleTransform = transform.Find("needle");
        score = FindObjectOfType<TextMeshProUGUI>();
        score.text = "Score : " + scoreValue;
    }

    public void modifyScore(float modifier)
    {
        scoreGauge -= modifier;

        if (scoreGauge > 130) scoreMultiplier = minScoreMultiplier;
        if (scoreGauge > 50 && scoreGauge < 130) scoreMultiplier = normalScoreMultiplier;
        if (scoreGauge > -30 && scoreGauge < 50) scoreMultiplier = maxScoreMultiplier;

        if (modifier > 0f) scoreValue += modifier * (10f) * scoreMultiplier;

        if (scoreGauge < maxScoreAngle) scoreGauge = maxScoreAngle;
        if (scoreGauge > minScoreAngle) scoreGauge = minScoreAngle;

        needleTransform.eulerAngles = new Vector3(0, 0, scoreGauge);
        score.text = "Score : " + scoreValue;
    }
}
