using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    [Header("Le texte actuellement affiché")]
    public int currentText;

    [Header("Le tableau contenant tous les textes")]
    public GameObject[] texts;

    private Image BackgroundImage;
    private Transform playerTransform;


    private void Start()
    {
        texts = new GameObject[transform.childCount];
        BackgroundImage = gameObject.GetComponent<Image>();
        playerTransform = GameObject.Find("Player").transform;

        for (int i = 0; i < transform.childCount; i++)
        {
            texts[i] = transform.GetChild(i).gameObject;
        }
    }

    public void DisplayNextText()
    {
        BackgroundImage.enabled = true;
        if (currentText>=1) texts[currentText - 1].SetActive(false);
        texts[currentText].SetActive(true);
        currentText++;
    }

    IEnumerator TutorialTimer()
    {
        yield return null;
    }
}
