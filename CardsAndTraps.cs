using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsandTraps : MonoBehaviour
{/*
    public List<Node> eventTriggerNodes; // nodes where event is triggered
    private bool isEventActive = false; // flag to indicate if event is active

    // Update is called once per frame
    void Update()
    {
        // check if event is active
        if (isEventActive)
        {
            // do something while event is active

            // if event is over, set flag to false
            isEventActive = false;
        }
    }

    // called when a player lands on a node
    public void OnPlayerLandedOnNode(Node node)
    {
        // check if node is a trigger node
        if (eventTriggerNodes.Contains(node))
        {
            // set flag to true to activate event
            isEventActive = true;

            // disable input controls for all other players
            foreach (Player player in players)
            {
                if (player != currentPlayer)
                {
                    player.DisableInputControls();
                }
            }

            // start event
            StartEvent();
        }
    }

    // called when event is over
    public void OnEventFinished()
    {
        // enable input controls for all players
        foreach (Player player in players)
        {
            player.EnableInputControls();
        }
    }

    // method to start the event
    private void StartEvent()
    {
        // do something to start the event
    } /*/
}

