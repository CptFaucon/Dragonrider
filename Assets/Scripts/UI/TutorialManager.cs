using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    [Header("les liens vers les prefabs")]
    public GameObject enemy;
    public GameObject obstacle;
    public GameObject cible;

    [Header("Le texte actuellement affiché")]
    public int currentText;

    [Header("Durée en sec des pauses entre les textes")]
    public float[] delays;

    [Header("Le tableau contenant tous les textes")]
    public GameObject[] texts;

    private Image BackgroundImage;
    private Transform player;

    private bool firstSituationComplete;
    private bool secondSituationComplete;
    private bool thirdSituationComplete;
    private bool fourthSituationComplete;

    private void Start()
    {
        texts = new GameObject[transform.childCount];
        BackgroundImage = gameObject.GetComponent<Image>();

        player = GameObject.Find("Player").transform;

        for (int i = 0; i < transform.childCount; i++) texts[i] = transform.GetChild(i).gameObject;

        StartCoroutine(TutorialTimer());
    }

    IEnumerator TutorialTimer()
    {
        yield return new WaitForSeconds(delays[0]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[1]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[2]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[3]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[4]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[5]);

        while (firstSituationComplete == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D)) firstSituationComplete = true;
            yield return null;
        }

        DisplayNextText();
        yield return new WaitForSeconds(delays[6]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[7]);
        Instantiate(enemy, player.position, Quaternion.identity);
        DisplayNextText();

        while(secondSituationComplete == false)
        {
            yield return null;
        }
        
        yield return new WaitForSeconds(delays[8]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[9]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[10]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[11]);
        Instantiate(obstacle, player.position - new Vector3(0, 0, -20), Quaternion.identity);

        while (thirdSituationComplete == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(delays[12]);
        if (texts[13].gameObject.activeSelf == true) texts[13].SetActive(false);
        if (texts[14].gameObject.activeSelf == true) texts[14].SetActive(false);
        if (texts[15].gameObject.activeSelf == true) texts[15].SetActive(false);
        DisplayNextText();
        yield return new WaitForSeconds(delays[13]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[14]);
        Instantiate(cible, player.position - new Vector3(0, 0, -20), Quaternion.Euler(90, 0, 0));

        while (fourthSituationComplete == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(delays[15]);
        DisplayNextText();
    }

    public void DisplayNextText()
    {
        if(BackgroundImage.enabled != true) BackgroundImage.enabled = true;
        if (currentText > 0) texts[currentText - 1].SetActive(false);
        texts[currentText].SetActive(true);
        currentText++;
    }

    public void EnemyKilled()
    {
        secondSituationComplete = true;
        if(texts[7].gameObject.activeSelf == true) texts[7].SetActive(false);
        if (texts[8].gameObject.activeSelf == true) texts[8].SetActive(false);
        texts[9].SetActive(true);
        currentText = 10;
    }

    public void EnemyNotKilled()
    {
        if (texts[7].gameObject.activeSelf == true) texts[7].SetActive(false);
        texts[8].SetActive(true);
        Instantiate(enemy, player.position, Quaternion.identity);
    }

    public void ObstacleTouched()
    {
        thirdSituationComplete = true;
        if (texts[12].gameObject.activeSelf == true) texts[12].SetActive(false);
        texts[13].SetActive(true);
        currentText = 16;
    }

    public void ObstacleDodged()
    {
        thirdSituationComplete = true;
        if (texts[12].gameObject.activeSelf == true) texts[12].SetActive(false);
        texts[14].SetActive(true);
        currentText = 16;
    }

    public void ObstacleAvoided()
    {
        thirdSituationComplete = true;
        if (texts[12].gameObject.activeSelf == true) texts[12].SetActive(false);
        texts[15].SetActive(true);
        currentText = 16;
    }
     
    public void TargetNotHit()
    {

    }

    public void TargetHit()
    {

    }
}
