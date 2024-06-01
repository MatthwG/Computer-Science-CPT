using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShootAnimation : MonoBehaviour
{
    Animator animator;
    public Movement movement;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (movement.fireindicator > 0){
            animator.SetFloat("FireShoot", 1);
        }
        if (movement.fireindicator <= 0){
            animator.SetFloat("FireShoot", 0);
        }
    }
}
