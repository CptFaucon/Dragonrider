using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    private Color rayColor = Color.white;
    public List<Transform> pathTransforms = new List<Transform> ();
    Transform[] theArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform> ();
        pathTransforms.Clear();

        foreach (Transform pathTransform in theArray)
        {
            if (pathTransform != this.transform)
            {
                pathTransforms.Add(pathTransform);
            }
        }

        for (int i = 0; i < pathTransforms.Count; i++)
        {
            Vector3 position = pathTransforms[i].position;
            if(i > 0)
            {
                Vector3 previous = pathTransforms[i - 1].position;
                Gizmos.DrawLine (previous, position);
            }
        }
    }
}
