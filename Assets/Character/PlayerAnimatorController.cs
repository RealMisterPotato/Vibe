using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Idle(){

        animator.SetBool("idle", true);
        animator.SetBool("walk", false);
        animator.SetBool("run", false);
    }
    public void Walk(){

        animator.SetBool("idle", false);
        animator.SetBool("walk", true);
        animator.SetBool("run", false);
    }
    public void Run(){

        animator.SetBool("idle", false);
        animator.SetBool("walk", false);
        animator.SetBool("run", true);
    }
}
