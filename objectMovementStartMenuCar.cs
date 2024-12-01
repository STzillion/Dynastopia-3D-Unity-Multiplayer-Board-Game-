using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovementStartMenuNPC : MonoBehaviour
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
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (true)
        {
            int nextIndex = movingForward ? routePosition + 1 : routePosition - 1;

            if (nextIndex >= currentRoute.childNodeList.Count || nextIndex < 0)
            {
                movingForward = !movingForward; // Reverse the movement direction
                isMoving = false; // Stop movement when both ends of the route are reached
                yield break;
            }

            Vector3 nextPos = currentRoute.childNodeList[nextIndex].position;

            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0f);
            routePosition = nextIndex;

            if (routePosition == 0)
            {
                Quaternion startRotation = transform.rotation;
                Quaternion endRotation = Quaternion.Euler(0, 0, 0);
                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime * turnSpeed;
                    transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
                    yield return null;
                }


            }
            else if(routePosition == 14)
            {
                Quaternion startRotation = transform.rotation;
                Quaternion endRotation = Quaternion.Euler(0, 180, 0);
                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime * turnSpeed;
                    transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
                    yield return null;
                }
            }
        }
    }



    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
