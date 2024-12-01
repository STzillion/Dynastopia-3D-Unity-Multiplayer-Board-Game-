using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesMovement : MonoBehaviour
{
    public Route currentRoute;

    int routePosition;
    public int steps;
    bool isMoving;
    public float turnSpeed = 5.0f;
    bool movingForward = true;

    public bool isWalking = false;

    void Update()
    {
        if (!isMoving) // Only start moving if not already moving
        {
            isWalking = true;
            routePosition = FindClosestNodeIndex();
            StartCoroutine(Move());
        }
    }

    public int FindClosestNodeIndex()
    {
        int closestIndex = 0;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < currentRoute.childNodeList.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, currentRoute.childNodeList[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    public IEnumerator Move()
    {
        if (isMoving) yield break;
        isMoving = true;

        while (true)
        {
            // Calculate the next index
            int nextIndex = movingForward ? routePosition + 1 : routePosition - 1;

            // Check if we've reached the end of the route
            if (nextIndex >= currentRoute.childNodeList.Count)
            {
                // If at the end, teleport to the start
                nextIndex = 0;
                transform.position = currentRoute.childNodeList[nextIndex].position;
            }
            else if (nextIndex < 0)
            {
                // If at the start, teleport to the end
                nextIndex = currentRoute.childNodeList.Count - 1;
                transform.position = currentRoute.childNodeList[nextIndex].position;
            }

            Vector3 nextPos = currentRoute.childNodeList[nextIndex].position;

            // Move to the next node
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0f);
            routePosition = nextIndex;

            // Rotate NPC at specific nodes if needed
            if (routePosition == 0)
            {
                yield return RotateNPC(0);
            }
            else if (routePosition == currentRoute.childNodeList.Count - 1)
            {
                yield return RotateNPC(180);
            }
        }
    }

    IEnumerator RotateNPC(float targetAngle)
    {
        yield return 0;
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 3.5f * Time.deltaTime));
    }
}

