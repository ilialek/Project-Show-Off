using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private Transform[] positionsToBeSet;

    [SerializeField]
    private Spline spline;

    [SerializeField]
    private float speed = 2f; // Speed in units per second
    private float distanceTravelled = 0f; // Distance travelled along the spline

    private Queue<Vector3> positionsQueue = new Queue<Vector3>();

    private Animator animator;

    public MonsterState currentState;

    private AnimationClip scareOffClip;
    private AnimationClip crawlingClip;

    public int beenHighlighted = 0;

    void Start()
    {
        for (int i = 0; i < positionsToBeSet.Length; i++) 
        {
            positionsQueue.Enqueue(positionsToBeSet[i].position);
        }

        if (spline != null)
        {
            spline.CalculateArcLengths(); // Pre-calculate arc lengths at the start
        }

        animator = GetComponent<Animator>();

        scareOffClip = animator.runtimeAnimatorController.animationClips
           .FirstOrDefault(clip => clip.name == "Scare off");
        crawlingClip = animator.runtimeAnimatorController.animationClips
           .FirstOrDefault(clip => clip.name == "Crawling");

        currentState = MonsterState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case MonsterState.Idle:
                // Handle idle state
                break;

            case MonsterState.Highlighted:

                OnHighlighted();

                break;

            case MonsterState.FollowingPath:
                // Handle following spline path and playing crawling animation
                // Assuming you have a script for path following and animation handling
                // Make sure to set animator parameters for crawling
                break;

            case MonsterState.MovingToPosition:
                // Handle moving to a certain position
                // Set destination and handle movement
                break;

            case MonsterState.Crawling:

                OnCrawling();

                break;

            case MonsterState.End:

                OnEnd();

                break;
        }
    }

    IEnumerator WaitForAnimationClipToEnd(float clipDuration, MonsterState newState)
    {
        yield return new WaitForSeconds(clipDuration);

        animator.SetBool("Highlighted", false);

        //transform.position = positionsQueue.Dequeue();
        currentState = newState;
    }
    void OnHighlighted()
    {
        animator.SetBool("Highlighted", true);

        StartCoroutine(WaitForAnimationClipToEnd(scareOffClip.length, MonsterState.Crawling));
        
    }

    void OnCrawling()
    {
        animator.SetBool("Crawling", true);

        FollowThePath();
    }

    void OnEnd()
    {
        transform.position = positionsToBeSet[1].position;
        transform.rotation = positionsToBeSet[1].rotation;

        animator.SetBool("Idle", true);

        //currentState = MonsterState.Idle;
    }

    void FollowThePath()
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

        // Check distance to the last control point
        Vector3 lastControlPointPosition = spline.controlPoints[spline.controlPoints.Length - 1].position;
        float distanceToLastPoint = Vector3.Distance(transform.position, lastControlPointPosition);

        // Adjust this distance threshold as needed
        float endReachedDistance = 0.1f; // Distance threshold to consider end reached

        // Check if end of path is reached+
        if (distanceToLastPoint <= endReachedDistance)
        {
            Debug.Log("End of path reached!");

            animator.SetBool("Crawling", false);

            currentState = MonsterState.End;

            // Perform actions when end is reached, such as changing state or triggering an event
            // For example:
            // Play idle animation, stop movement, etc.

            // Reset distance travelled if looping back to start or stopping movement
            // distanceTravelled = 0f; // Uncomment if looping back to start

            return; // Exit the method or perform other end-of-path logic
        }

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
    public void SetState(MonsterState newState)
    {
        currentState = newState;
    }

    public void FinalHighlight()
    {
        StartCoroutine(PlayAnimation(scareOffClip.length));
    }

    IEnumerator PlayAnimation(float clipDuration)
    {
        yield return new WaitForSeconds(clipDuration);

        animator.SetBool("Highlighted", false);

        gameObject.SetActive(false);
    }

}
