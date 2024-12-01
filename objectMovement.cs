using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovement : MonoBehaviour
{

    public Route currentRoute;

   public int routePosition;

    public int steps;

    public int roundBoard = 0;

    bool isMoving;

    public float turnSpeed = 5.0f;

    public Vector3 nextPos;
    public Vector3 prevPos;

    public float MovementSpeed = 3f;


    

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
              nextPos = currentRoute.childNodeList[(routePosition + 1) % currentRoute.childNodeList.Count].position;
             prevPos = currentRoute.childNodeList[(routePosition+1) % currentRoute.childNodeList.Count].position;

            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0f);
            routePosition = (routePosition + 1) % currentRoute.childNodeList.Count;


            if (routePosition == 10)
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

            else if (routePosition == 18)
            {
                Quaternion startRotation = transform.rotation;
                Quaternion endRotation = Quaternion.Euler(0, 270, 0);
                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime * turnSpeed;
                    transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
                    yield return null;
                }
            }
            else if (routePosition == 28)
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
            else if (routePosition == 34)
            {
                Quaternion startRotation = transform.rotation;
                Quaternion endRotation = Quaternion.Euler(0, 90, 0);
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
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, MovementSpeed * Time.deltaTime));
    }
}
