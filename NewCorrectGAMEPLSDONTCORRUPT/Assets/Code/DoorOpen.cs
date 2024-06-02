using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator animator;
    public Movement playermove;
    GameObject Player;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Open", 0);
        if (playermove.openindicator == 1f)
        {
            animator.SetFloat("Open", 1);
        }
    }
}
