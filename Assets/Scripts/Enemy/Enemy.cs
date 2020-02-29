using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    GameObject enemy;
    Transform target;

    private bool stopped;
    private bool stayDurationEnded;
    private bool lastPath;

    private List<Vector3> spawnPoints = new List<Vector3>();
    private Vector3 spawnPos;

    [Header("Paramètres de vitesse")]
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float accelerationAndDecelerationSpeed;

    [Header("Paramètres de freinage")]
    public float brakeDistance;
    public float stopDuration;

    [Header("Portées horizontales et verticales")]
    public float HorizontalRange;
    public float VerticalRange;

    [Header("Position des points de spawn")]
    public float upSpawn;
    public float downSpawn;
    public float rightSpawn;
    public float leftSpawn;

    [Header("Durée durant laquelle l'ennemi reste à l'écran")]
    public float stayDuration;

    private void Start()
    {
        enemy = GameObject.Find("enemyBody");
        target = transform.Find("enemyTarget");

        target.localPosition = new Vector3(Random.Range(-HorizontalRange, HorizontalRange), Random.Range(-VerticalRange, VerticalRange), 0);

        spawnPoints.Add(new Vector3(0,upSpawn,0));
        spawnPoints.Add(new Vector3(0,downSpawn,0));
        spawnPoints.Add(new Vector3(rightSpawn,0,0));
        spawnPoints.Add(new Vector3(leftSpawn,0,0));

        spawnPos = spawnPoints[Random.Range(0, spawnPoints.Count)];
        enemy.transform.position = spawnPos;

        StartCoroutine(StayDuration());
    }

    private void Update()
    {
        enemy.transform.localPosition = Vector3.MoveTowards(enemy.transform.localPosition, target.localPosition, currentSpeed * Time.deltaTime);

        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < minSpeed && stopped == false) currentSpeed = minSpeed;

        if (Vector3.Distance(enemy.transform.position, target.position) > brakeDistance && stopped == false) currentSpeed += accelerationAndDecelerationSpeed * Time.deltaTime;
        if (Vector3.Distance(enemy.transform.position, target.position) < brakeDistance && stopped == false) currentSpeed -= accelerationAndDecelerationSpeed * Time.deltaTime;

        if (enemy.transform.localPosition == target.localPosition && stayDurationEnded == false && lastPath == false)
        {
            target.localPosition = new Vector3(Random.Range(-HorizontalRange, HorizontalRange), Random.Range(-VerticalRange, VerticalRange), 0);
            StartCoroutine(Turning());
        }

        if (enemy.transform.localPosition == target.localPosition && stayDurationEnded == true && lastPath == false)
        {
            target.localPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];
            lastPath = true;
        }

        if (enemy.transform.localPosition == target.localPosition && stayDurationEnded == true && lastPath == true)
        {
            //Appeler fonction Thomas pour pulling (sortie)
            gameObject.SetActive(false);
        }
    }

    IEnumerator Turning()
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
