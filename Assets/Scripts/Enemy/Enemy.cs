using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    EnemyDisabler enemy;
    Transform target;

    private bool stopped;
    private bool stayDurationEnded;
    private bool lastPath;
    private bool isActivated = false;

    private List<Vector3> spawnPoints;
    private Vector3 spawnPos;

    private ScoreManager sm;

    [Header("Position des points de spawn")]
    public float upSpawn;
    public float downSpawn;
    public float rightSpawn;
    public float leftSpawn;

    [Header("Limites horizontales et verticales des déplacements")]
    public float HorizontalRange;
    public float VerticalRange;

    [Header("Points lors de la destruction")]
    public float scoreMalus;
    public float scoreBonus;

    [Header("Durée pendant laquelle l'ennemi reste à l'écran")]
    public float stayDuration;

    [Header("Paramètres de vitesse")]
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float accelerationAndDecelerationSpeed;

    [Header("Paramètres de l'arrêt")]
    public float brakeDistance;
    public float stopDuration;

    private void OnTriggerEnter(Collider other)
    {
        transform.SetParent(other.transform);
        transform.localPosition = new Vector3(0, 0, 2);
        LaunchScript();
    }

    private void LaunchScript()
    {
        if (enemy == null)
        {
            target = transform.GetChild(0);
            enemy = transform.GetChild(1).GetComponent<EnemyDisabler>();
            enemy.parent = this;
        }
        
        enemy.gameObject.SetActive(true);
        target.gameObject.SetActive(true);
        

        if (sm == null)
        {
            sm = FindObjectOfType<ScoreManager>();
        }

        target.localPosition = new Vector3(Random.Range(-HorizontalRange, HorizontalRange), Random.Range(-VerticalRange, VerticalRange), 0);

        spawnPoints = new List<Vector3>();

        spawnPoints.Add(new Vector3(0,upSpawn,0));
        spawnPoints.Add(new Vector3(0,downSpawn,0));
        spawnPoints.Add(new Vector3(rightSpawn,0,0));
        spawnPoints.Add(new Vector3(leftSpawn,0,0));

        spawnPos = spawnPoints[Random.Range(0, spawnPoints.Count)];
        enemy.transform.localPosition = spawnPos;

        StartCoroutine(StayDuration());

        isActivated = true;
    }

    private void Update()
    {
        if (isActivated)
        {
            enemy.transform.localPosition = Vector3.MoveTowards(enemy.transform.localPosition, target.localPosition, currentSpeed * Time.deltaTime);

            if (Vector3.Distance(enemy.transform.position, target.position) > brakeDistance && stopped == false) currentSpeed += accelerationAndDecelerationSpeed * Time.deltaTime;
            if (Vector3.Distance(enemy.transform.position, target.position) < brakeDistance && stopped == false) currentSpeed -= accelerationAndDecelerationSpeed * Time.deltaTime;

            if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
            if (currentSpeed < minSpeed && stopped == false) currentSpeed = minSpeed;

            if (enemy.transform.localPosition == target.localPosition && stayDurationEnded == false && lastPath == false)
            {
                target.localPosition = new Vector3(Random.Range(-HorizontalRange, HorizontalRange), Random.Range(-VerticalRange, VerticalRange), 0);
                StartCoroutine(Stopping());
            }

            if (enemy.transform.localPosition == target.localPosition && stayDurationEnded == true && lastPath == false)
            {
                target.localPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];
                lastPath = true;
            }

            if (enemy.transform.localPosition == target.localPosition && stayDurationEnded == true && lastPath == true)
            {
                EndLife();
            }
        }
    }

    public void EndLife()
    {
        float score = lastPath
            ? scoreMalus
            : scoreBonus;
        
        Debug.Log(lastPath
            ? "Enemy has escaped"
            : "Enemy defeated, good job !"
            );

        lastPath = false;
        isActivated = false;

        sm.modifyScore(score);
        enemy.gameObject.SetActive(false);
        target.gameObject.SetActive(false);
        transform.SetParent(null);
        gameObject.SetActive(false);
    }

    IEnumerator Stopping()
    {
        stopped = true;
        currentSpeed = 0;
        yield return new WaitForSeconds(stopDuration);
        stopped = false;
    }

    IEnumerator StayDuration()
    {
        yield return new WaitForSeconds(stayDuration);
        stayDurationEnded = true;
    }
}
