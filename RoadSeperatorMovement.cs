using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSeperatorMovement : MonoBehaviour
{

    public Route currentRoute;
    int routePosition;
    public int steps;
    bool isMoving;
    public float turnSpeed = 5.0f;
   // public GameObject[] NPCs;
    public Animator NPCAnimator;

    public float MovementSpeed = 0.5f;
   
    public bool IsDanger;



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
            Vector3 nextPos = currentRoute.childNodeList[(routePosition + 1) % currentRoute.childNodeList.Count].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0f);
            routePosition = (routePosition + 1) % currentRoute.childNodeList.Count;


            if (routePosition == 0)
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

            else if (routePosition == 12)
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
            else if (routePosition == 19)
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
            else if (routePosition == 29)
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

   


    public void NPCRunning()
    {
        StartCoroutine(NPCstartsRunning());
    }

    public void NPCWalking()
    {
        StartCoroutine(NPCStartsWalking());
    }

    public void NPCFreezesVoid()
    {
        StartCoroutine(NPCFreezes());
    }

    public void NPCUnFreezesVoid()
    {
        StartCoroutine(NPCUnFreezes());
    }

    public IEnumerator NPCFreezes()
    {
        yield return new WaitForSeconds(0f);
        NPCAnimator.speed = 0f;
    }

    public IEnumerator NPCUnFreezes()
    {
        yield return new WaitForSeconds(0f);
        NPCAnimator.speed = 1f;
    }

    public IEnumerator NPCstartsRunning()
    {
        yield return new WaitForSeconds(0f);

        IsDanger = true;

        NPCAnimator.SetBool("IsGunShots", true);
        NPCAnimator.CrossFade("FastRun", 0.05f);

    }


    public IEnumerator NPCStartsWalking()
    {
        yield return new WaitForSeconds(0f);

       
        
            NPCAnimator.SetBool("IsGunShots", false);
            NPCAnimator.CrossFade("FastRun", 0.01f);
        
        
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, MovementSpeed * Time.deltaTime));
    }

   
}
