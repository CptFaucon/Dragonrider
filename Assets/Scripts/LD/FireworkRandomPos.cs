using UnityEngine;

public class FireworkRandomPos : MonoBehaviour
{
    public float horizontalRange;
    public float verticalRange;
    public float depth;

    private void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-horizontalRange, horizontalRange), depth, Random.Range(-verticalRange, verticalRange));
    }
}
