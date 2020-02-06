using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform needleTransform;

    private const float maxScoreAngle = -30;
    private const float minScoreAngle = 210;
    private float score = 90;

    private void Update()
    {
        needleTransform.eulerAngles = new Vector3(0, 0, score);

        if (Input.GetKeyDown(KeyCode.UpArrow)) score -= 10;
        if (Input.GetKeyDown(KeyCode.DownArrow)) score += 10;

        if (score < maxScoreAngle) score = maxScoreAngle;
        if (score > minScoreAngle) score = minScoreAngle;
    }
}
