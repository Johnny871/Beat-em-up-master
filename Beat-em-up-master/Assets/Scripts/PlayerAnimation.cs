using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    //Animation animation;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        //animation = this.GetComponent<Animation>();
    }

    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isRun",false);
        }
    }
}
