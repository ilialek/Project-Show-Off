using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    public Transform[] controlPoints;
    private List<float> arcLengths; // Store the cumulative lengths
    private List<float> tValues; // Store corresponding t values

    private const int sampleResolution = 100; // Number of sample points

    void OnDrawGizmos()
    {
        if (controlPoints.Length < 4) return;

        // Draw the spline in the editor
        int resolution = 20; // Number of segments to draw
        Vector3 previousPoint = controlPoints[0].position;

        for (int i = 1; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            Vector3 point = GetBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }

        // Calculate and store arc lengths for uniform speed
        CalculateArcLengths();
    }

    public Vector3 GetBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    public void CalculateArcLengths()
    {
        arcLengths = new List<float>();
        tValues = new List<float>();

        float totalLength = 0f;
        arcLengths.Add(totalLength);
        tValues.Add(0f);

        Vector3 previousPoint = controlPoints[0].position;

        for (int i = 1; i <= sampleResolution; i++)
        {
            float t = i / (float)sampleResolution;
            Vector3 point = GetBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);
            float segmentLength = Vector3.Distance(previousPoint, point);
            totalLength += segmentLength;
            arcLengths.Add(totalLength);
            tValues.Add(t);
            previousPoint = point;
        }
    }

    public float GetNormalizedT(float distance)
    {
        if (arcLengths == null || arcLengths.Count < 2) return 0f;

        distance = Mathf.Clamp(distance, 0, arcLengths[arcLengths.Count - 1]);

        for (int i = 1; i < arcLengths.Count; i++)
        {
            if (arcLengths[i] >= distance)
            {
                float t0 = tValues[i - 1];
                float t1 = tValues[i];
                float length0 = arcLengths[i - 1];
                float length1 = arcLengths[i];

                return Mathf.Lerp(t0, t1, (distance - length0) / (length1 - length0));
            }
        }

        return 1f;
    }
}
