using UnityEngine;
using System.Collections;

public class TESTEnemy : MonoBehaviour
{
    GameObject enemy;
    Transform target;

    private bool stopped;

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

    private void Start()
    {
        enemy = GameObject.Find("enemyBody");
        target = transform.Find("target");
    }

    private void Update()
    {
        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < minSpeed && stopped == false) currentSpeed = minSpeed;

        if (Vector3.Distance(enemy.transform.position, target.position) > brakeDistance && stopped == false) currentSpeed += accelerationAndDecelerationSpeed * Time.deltaTime;
        if (Vector3.Distance(enemy.transform.position, target.position) < brakeDistance && stopped == false) currentSpeed -= accelerationAndDecelerationSpeed * Time.deltaTime;

        if (enemy.transform.localPosition == target.localPosition)
        {
            target.localPosition = new Vector3(Random.Range(-HorizontalRange, HorizontalRange), Random.Range(-VerticalRange, VerticalRange), 0);
            StartCoroutine(Turning());
        }

        else enemy.transform.localPosition = Vector3.MoveTowards(enemy.transform.localPosition, target.localPosition, currentSpeed * Time.deltaTime);
    }

    IEnumerator Turning()
    {
        stopped = true;
        currentSpeed = 0;
        yield return new WaitForSeconds(stopDuration);
        stopped = false;
    }
}
