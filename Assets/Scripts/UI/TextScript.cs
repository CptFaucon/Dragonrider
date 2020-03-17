using UnityEngine;

public class TextScript : MonoBehaviour
{
    private TutorialManager tm;
    
    void Start()
    {
        tm = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(tm.currentText != 5 && tm.currentText != 9 && tm.currentText != 10 && tm.currentText != 15 && tm.currentText != 16 && tm.currentText != 20 && tm.currentText != 21)
        {
            tm.DisplayNextText();
        }
    }
}
