using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    public Spline spline; // Reference to the Spline component
    public float speed = 2f; // Speed in units per second
    private float distanceTravelled = 0f; // Distance travelled along the spline

    void Start()
    {
        if (spline != null)
        {
            spline.CalculateArcLengths(); // Pre-calculate arc lengths at the start
        }
    }

    void Update()
    {
        // Ensure the spline and control points are valid
        if (spline == null || spline.controlPoints.Length < 4) return;

        // Increment the distance travelled
        distanceTravelled += speed * Time.deltaTime;

        // Get the parameter t for the current distance
        float t = spline.GetNormalizedT(distanceTravelled);

        // Get the current position on the spline
        Vector3 position = spline.GetBezierPoint(t, spline.controlPoints[0].position, spline.controlPoints[1].position, spline.controlPoints[2].position, spline.controlPoints[3].position);

        // Set the position of the object
        transform.position = position;

        // Get a slightly ahead position on the spline to calculate the forward direction
        float lookAhead = distanceTravelled + 0.1f;
        float tAhead = spline.GetNormalizedT(lookAhead);

        Vector3 nextPosition = spline.GetBezierPoint(tAhead, spline.controlPoints[0].position, spline.controlPoints[1].position, spline.controlPoints[2].position, spline.controlPoints[3].position);

        // Calculate the direction to look at
        Vector3 direction = (nextPosition - position).normalized;

        // Rotate the object to face the direction of movement, then rotate by 180 degrees on Y-axis
        if (direction != Vector3.zero) // Avoid zero direction vector
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion y180Rotation = Quaternion.Euler(0, 0, 180);
            transform.rotation = lookRotation * y180Rotation;
        }
    }
}