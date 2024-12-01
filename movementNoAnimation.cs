using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementNoAnimation : MonoBehaviour
{
    public Route currentRoute;

    int routePosition;

    public int steps;

    bool isMoving;

    public float turnSpeed = 5.0f;


    public Animator animator;

   public bool isWalking = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
            Debug.Log("Dice Rolled " + steps);
            isWalking = true;
            StartCoroutine(Move());
        }
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

        }

        
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 0.7f * Time.deltaTime));
    }
}


