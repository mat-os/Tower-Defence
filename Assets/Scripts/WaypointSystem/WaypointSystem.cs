using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public static Vector3[] points;
    void Awake()
    {
        points =  new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            points[i] = transform.GetChild(i).position;
        }
    }
}
