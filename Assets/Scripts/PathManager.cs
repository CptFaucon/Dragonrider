using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<Transform> pathTransforms = new List<Transform>();
    Transform[] pathArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        pathArray = GetComponentsInChildren<Transform>();
        pathTransforms.Clear();

        foreach (Transform pathTransform in pathArray)
        {
            if (pathTransform != this.transform)
            {
                pathTransforms.Add(pathTransform);
            }
        }

        for (int i = 0; i < pathTransforms.Count; i++)
        {
            Vector3 position = pathTransforms[i].position;

            if (i > 0)
            {
                Vector3 previous = pathTransforms[i - 1].position;
                Gizmos.DrawLine(previous, position);
            }
        }
    }
}