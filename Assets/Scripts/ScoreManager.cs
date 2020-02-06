using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform needleTransform;

    private const float maxScoreAngle = -30;
    private const float minScoreAngle = 210;
    private float scoreDisplay = 90;

    public void modifyScoreDisplay(float modifier)
    {
        scoreDisplay -= modifier;

        if (scoreDisplay < maxScoreAngle) scoreDisplay = maxScoreAngle;
        if (scoreDisplay > minScoreAngle) scoreDisplay = minScoreAngle;

        needleTransform.eulerAngles = new Vector3(0, 0, scoreDisplay);
    }
}
