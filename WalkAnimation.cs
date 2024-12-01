using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkAnimation : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Walking");
        }
    }
}


