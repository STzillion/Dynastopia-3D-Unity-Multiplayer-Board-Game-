using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnssystem : MonoBehaviour
{
    public Route currentRoute;

    int routePosition;

    public int steps;

    bool isMoving;

    public float turnSpeed = 5.0f;

    bool isWalking = false;

    bool isMyTurn = false;

    void Start()
    {
        // Set the first player's turn
        isMyTurn = true;
    }

    void Update()
    {
        if (isMyTurn && Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
            Debug.Log("Dice Rolled " + steps);
            isWalking = true;
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        for (int i = 0; i < steps; i++)
        {
            Vector3 nextPos = currentRoute.childNodeList[(routePosition + 1) % currentRoute.childNodeList.Count].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            routePosition = (routePosition + 1) % currentRoute.childNodeList.Count;
        }

        isMoving = false;
        isWalking = false;
        isMyTurn = false;

        // Get the next player's turn
        GameObject[] players = GameObject.FindGameObjectsWithTag("stone");
        int currentIndex = System.Array.IndexOf(players, gameObject);
        int nextIndex = (currentIndex + 1) % players.Length;
        players[nextIndex].GetComponent<turnssystem>().isMyTurn = true;
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 0.7f * Time.deltaTime));
    }
}
