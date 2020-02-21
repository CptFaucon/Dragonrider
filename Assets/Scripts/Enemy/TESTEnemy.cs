using UnityEngine;
using System.Collections;

public class TESTEnemy : MonoBehaviour
{
    GameObject enemy;
    Transform target;

    public bool stopped;

    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float brakeDistance;
    public float accelerationAndDeceleration;
    public float brakeDuration;
    public float HorizontalRange;
    public float VerticalRange;

    private void Start()
    {
        enemy = GameObject.Find("enemyBody");
        target = transform.Find("target");
    }

    private void Update()
    {
        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < minSpeed && stopped == false) speed = minSpeed;


        if (Vector3.Distance(enemy.transform.position, target.position) > brakeDistance && stopped == false) speed += accelerationAndDeceleration * Time.deltaTime;
        if (Vector3.Distance(enemy.transform.position, target.position) < brakeDistance && stopped == false) speed -= accelerationAndDeceleration * Time.deltaTime;

        if (enemy.transform.localPosition == target.localPosition)
        {
            target.localPosition = new Vector3(Random.Range(-HorizontalRange, HorizontalRange), Random.Range(-VerticalRange, VerticalRange), 0);
            StartCoroutine(Turning());
        }

        else
        {
            enemy.transform.localPosition = Vector3.MoveTowards(enemy.transform.localPosition, target.localPosition, speed * Time.deltaTime);
        }
    }

    IEnumerator Turning()
    {
        stopped = true;
        speed = 0;
        yield return new WaitForSeconds(brakeDuration);
        stopped = false;
    }
}
