using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private Transform needleTransform;
    private TextMeshProUGUI score;
    private TextMeshProUGUI multiplier;
    private EnvironmentManager env;

    [Header("Gestion des multiplicateurs de score")]
    public float currentMultiplier;
    public float firstMultiplier;
    public float secondMultiplier;
    public float thirdMultiplier;

    [Header("Vitesse de remplissage de la jauge")]
    public float fillingSpeed;

    [Header("Valeurs des scores bonus")]
    [SerializeField]
    private int lowBonus = 1;
    [SerializeField]
    private int mediumBonus = 2;
    [SerializeField]
    private int highBonus = 4;
    [Space]
    [SerializeField]
    private float easySituationTotalScorePoints = 100;
    [SerializeField]
    private float mediumSituationTotalScorePoints = 300;
    [SerializeField]
    private float hardSituationTotalScorePoints = 900;
    public int[] bonus {
        get {
            return new int[] { lowBonus, mediumBonus, highBonus };
        }
    }
    public float[] total {
        get {
            return new float[] { easySituationTotalScorePoints, mediumSituationTotalScorePoints, hardSituationTotalScorePoints };
        }
    }

    [Header("Fin de run")]
    [SerializeField]
    private string newScoreText = "Score :";
    [SerializeField]
    private TextMeshProUGUI newScore;
    [SerializeField]
    private GameObject highScore;

    private float scoreValue;

    private const float maxScoreAngle = -30f;
    private const float minScoreAngle = 210f;
    private float scoreGauge = 210f;

    private void Awake()
    {
        env = FindObjectOfType<EnvironmentManager>();

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

        if (modifier > 0f)
        {
            scoreValue += modifier * (10f) * currentMultiplier;
            if (env)
            {
                env.Success();
            }
        }

        if (scoreGauge < maxScoreAngle) scoreGauge = maxScoreAngle;
        if (scoreGauge > minScoreAngle) scoreGauge = minScoreAngle;

        needleTransform.eulerAngles = new Vector3(0, 0, scoreGauge);

        score.text = "Score : " + scoreValue;
        multiplier.text = "x" + currentMultiplier;
    }

    public void AtRunEnd()
    {
        if (PlayerPrefs.GetFloat("high_Score") < scoreValue)
        {
            PlayerPrefs.SetFloat("high_Score", scoreValue);
            if (highScore)
            {
                highScore.SetActive(true);
            }
        }
        if (newScore)
        {
            newScore.text = newScoreText + " " + scoreValue.ToString();
            newScore.gameObject.SetActive(true);
        }
    }
}
