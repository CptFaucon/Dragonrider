using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image i;
    
    void Start()
    {
        i = GetComponent<Image>();
        i.enabled = true;
    }
}
