using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private Transform needleTransform;
    private TextMeshProUGUI score;

    private float scoreValue = 0f;

    private const float maxScoreAngle = -30f;
    private const float minScoreAngle = 210f;
    private float scoreGauge = 90f;

    private void Start()
    {
        needleTransform = transform.Find("needle");
        score = FindObjectOfType<TextMeshProUGUI>();
        score.text = "Score : " + scoreValue;
    }

    public void modifyScoreGauge(float modifier)
    {
        scoreGauge -= modifier;

        if (modifier > 0f) scoreValue += modifier*(10f);

        if (scoreGauge < maxScoreAngle) scoreGauge = maxScoreAngle;
        if (scoreGauge > minScoreAngle) scoreGauge = minScoreAngle;

        needleTransform.eulerAngles = new Vector3(0, 0, scoreGauge);
        score.text = "Score : " + scoreValue;
    }
}
