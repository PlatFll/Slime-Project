using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TragectoryLine : MonoBehaviour
{
    public LineRenderer lr;
    public float maxLength = 10f;

    public void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        if (Vector3.Distance(startPoint, endPoint) > maxLength)
        {
            endPoint = startPoint + (endPoint - startPoint).normalized * maxLength;
        }
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }
}

























/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TragectoryLine : MonoBehaviour
{
    public LineRenderer lr;

    public void Awake()
    {
        lr = GetComponent<LineRenderer>();
        //lr.positionCount = 0;
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;

    }
}*/
