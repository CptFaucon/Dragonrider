using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public int scoreValue = 0;
    private TextMeshProUGUI score;

    private void Start()
    {
        score = FindObjectOfType<TextMeshProUGUI>();
        score.text = "Score : " + scoreValue;
    }
    
    public void modifyScoreDisplay(float modifier)
    {

    }
}
