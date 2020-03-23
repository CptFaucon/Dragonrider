using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [Header("les liens vers les prefabs")]
    public GameObject enemy;
    public GameObject obstacle;
    public GameObject cible;

    [Header("Durée en sec des pauses entre les textes")]
    public float[] delays;

    [Header("Le tableau contenant tous les textes")]
    public GameObject[] texts;

    private Image BackgroundImage;
    private Transform player;
    private TutorialSounds ts;

    private int currentText;

    private bool firstSituationComplete;
    private bool secondSituationComplete;
    private bool thirdSituationComplete;
    private bool fourthSituationComplete;

    private void Start()
    {
        texts = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) texts[i] = transform.GetChild(i).gameObject;

        BackgroundImage = gameObject.GetComponent<Image>();
        player = GameObject.Find("Player").transform;
        ts = FindObjectOfType<TutorialSounds>();

        StartCoroutine(TutorialTimer());
    }

    //La coroutine est bloquée à quatre moments (déplacements, rencontre avec un ennemi, esquive d'un obstacle, destruction d'une cible).
    //Tant que le joueur n'a pas franchi ces étapes avec succès, le tutoriel n'avance pas.
    IEnumerator TutorialTimer()
    {
        yield return new WaitForSeconds(delays[0]);
        DisplayNextText();
        ts.sounds[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[1]);
        DisplayNextText();
        ts.sounds[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[2]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[3]);
        DisplayNextText();
        ts.sounds[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[4]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[5]);

        //Première situation
        while (firstSituationComplete == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D)) firstSituationComplete = true;
            yield return null;
        }

        DisplayNextText();
        ts.sounds[3].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[6]);
        DisplayNextText();
        ts.sounds[4].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[7]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[8]);
        Instantiate(enemy, player.position, Quaternion.identity);

        //Deuxième situation
        while(secondSituationComplete == false)
        {
            yield return null;
        }
        
        yield return new WaitForSeconds(delays[9]);
        DisplayNextText();
        ts.sounds[7].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[10]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[11]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[12]);
        Instantiate(obstacle, player.position - new Vector3(0, 0, -20), Quaternion.identity);

        //Troisième situation
        while (thirdSituationComplete == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(delays[13]);
        if (texts[13].gameObject.activeSelf == true) texts[13].SetActive(false);
        if (texts[14].gameObject.activeSelf == true) texts[14].SetActive(false);
        if (texts[15].gameObject.activeSelf == true) texts[15].SetActive(false);
        DisplayNextText();
        ts.sounds[11].gameObject.SetActive(true);
        yield return new WaitForSeconds(delays[14]);
        DisplayNextText();
        yield return new WaitForSeconds(delays[15]);
        Instantiate(cible, player.position - new Vector3(0, 0, -20), Quaternion.Euler(90, 0, 0));

        //Quatrième situation
        while (fourthSituationComplete == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(delays[16]);
        DisplayNextText();
        ts.sounds[14].SetActive(true);
        yield return new WaitForSeconds(delays[17]);
        SceneChange();
    }

    #region Display Next Text
    public void DisplayNextText()
    {
        if(BackgroundImage.enabled != true) BackgroundImage.enabled = true;
        if (currentText > 0) texts[currentText - 1].SetActive(false);
        texts[currentText].SetActive(true);
        currentText++;
    }
    #endregion

    #region Second Situation
    public void EnemyKilled()
    {
        secondSituationComplete = true;
        if(texts[7].gameObject.activeSelf == true) texts[7].SetActive(false);
        if (texts[8].gameObject.activeSelf == true) texts[8].SetActive(false);
        texts[9].SetActive(true);
        ts.sounds[6].gameObject.SetActive(true);
        currentText = 10;
    }

    public void EnemyNotKilled()
    {
        if (texts[7].gameObject.activeSelf == true) texts[7].SetActive(false);
        if (texts[8].gameObject.activeSelf != true) texts[8].SetActive(true);
        if (ts.sounds[5].gameObject.activeSelf != true) ts.sounds[5].gameObject.SetActive(true);
        Instantiate(enemy, player.position, Quaternion.identity);
    }
    #endregion

    #region Third Situation
    public void ObstacleTouched()
    {
        if (texts[12].gameObject.activeSelf == true) texts[12].SetActive(false);
        if (texts[13].gameObject.activeSelf != true) texts[13].SetActive(true);
        if (ts.sounds[8].gameObject.activeSelf != true) ts.sounds[8].gameObject.SetActive(true);
        Instantiate(obstacle, player.position - new Vector3(0, 0, -20), Quaternion.identity);
    }

    public void ObstacleDodged()
    {
        thirdSituationComplete = true;
        if (texts[12].gameObject.activeSelf == true) texts[12].SetActive(false);
        if (texts[13].gameObject.activeSelf == true) texts[13].SetActive(false);
        texts[14].SetActive(true);
        ts.sounds[9].gameObject.SetActive(true);
        currentText = 16;
    }

    public void ObstacleAvoided()
    {
        thirdSituationComplete = true;
        if (texts[12].gameObject.activeSelf == true) texts[12].SetActive(false);
        if (texts[13].gameObject.activeSelf == true) texts[13].SetActive(false);
        texts[15].SetActive(true);
        ts.sounds[10].gameObject.SetActive(true);
        currentText = 16;
    }
    #endregion

    #region Fourth Situation
    public void TargetNotHit()
    {
        if (texts[17].gameObject.activeSelf == true) texts[17].SetActive(false);
        if (texts[18].gameObject.activeSelf != true) texts[18].SetActive(true);
        Instantiate(cible, player.position - new Vector3(0, 0, -20), Quaternion.Euler(90, 0, 0));
        ts.sounds[12].SetActive(true);
    }

    public void TargetHit()
    {
        fourthSituationComplete = true;
        if (texts[17].gameObject.activeSelf == true) texts[17].SetActive(false);
        if (texts[18].gameObject.activeSelf == true) texts[18].SetActive(false);
        texts[19].SetActive(true);
        ts.sounds[13].SetActive(true);
        currentText = 20;
    }
    #endregion

    #region Scene Change
    public void SceneChange()
    {
        SceneManager.LoadScene(2);
    }
    #endregion
}
