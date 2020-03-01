using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private Transform needleTransform;
    private TextMeshProUGUI score;
    private TextMeshProUGUI multiplier;

    [Header("Gestion des multiplicateurs de score")]
    public float currentMultiplier;
    public float firstMultiplier;
    public float secondMultiplier;
    public float thirdMultiplier;

    [Header("Vitesse de remplissage de la jauge")]
    public float fillingSpeed;

    private float scoreValue;

    private const float maxScoreAngle = -30f;
    private const float minScoreAngle = 210f;
    private float scoreGauge = 210f;

    private void Start()
    {
        needleTransform = transform.Find("needle");

        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score.text = "Score : " + scoreValue;

        multiplier = GameObject.Find("Multiplier").GetComponent<TextMeshProUGUI>();
        multiplier.text = "x" + currentMultiplier;
    }

    public void modifyScore(float modifier)
    {
        scoreGauge -= modifier * (fillingSpeed);

        if (scoreGauge > 130) currentMultiplier = firstMultiplier;
        if (scoreGauge > 50 && scoreGauge < 130) currentMultiplier = secondMultiplier;
        if (scoreGauge > -30 && scoreGauge < 50) currentMultiplier = thirdMultiplier;

        if (modifier > 0f) scoreValue += modifier * (10f) * currentMultiplier;

        if (scoreGauge < maxScoreAngle) scoreGauge = maxScoreAngle;
        if (scoreGauge > minScoreAngle) scoreGauge = minScoreAngle;

        needleTransform.eulerAngles = new Vector3(0, 0, scoreGauge);

        score.text = "Score : " + scoreValue;
        multiplier.text = "x" + currentMultiplier;
    }
}
