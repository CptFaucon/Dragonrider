using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform needleTransform;

    private const float maxScoreAngle = -30;
    private const float minScoreAngle = 210;
    private float scoreDisplay = 90;

    public void modifyScoreDisplay(float modifier)
    {
        needleTransform.eulerAngles = new Vector3(0, 0, scoreDisplay);

        if (scoreDisplay < maxScoreAngle) scoreDisplay = maxScoreAngle;
        if (scoreDisplay > minScoreAngle) scoreDisplay = minScoreAngle;

        scoreDisplay -= modifier;
    }
}
