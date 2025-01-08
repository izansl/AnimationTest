using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject Player;
    public float WalkSpeed = 2f; 

    private Animator animator;

    void Start()
    {
        animator = Player.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            WalkF();
        }
        else
        {
            StopWalkingF();
        }

        if (Input.GetKey(KeyCode.A))
        {
            WalkB();
        }
        else
        {
            StopWalkingB();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) SuAtack();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SdAtack();
        if (Input.GetKeyDown(KeyCode.W)) Jump();
        if (Input.GetKeyDown(KeyCode.S)) Hide();
        if (Input.GetKeyDown(KeyCode.Alpha3)) LuAtack();
        if (Input.GetKeyDown(KeyCode.Alpha4)) LdAtack();
    }

    public void Win()
    {
        animator.SetBool("Win", true);
    }

    public void Lose()
    {
        animator.SetBool("Lose", true);
    }

    public void SdAtack()
    {
        animator.SetTrigger("SdAtack");
    }

    public void SuAtack()
    {
        animator.SetTrigger("SuAtack");
    }

    public void WalkF()
    {
        animator.SetBool("WalkF", true);
        Player.transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
    }

    public void StopWalkingF()
    {
        animator.SetBool("WalkF", false);
    }

    public void WalkB()
    {
        animator.SetBool("WalkB", true);
        Player.transform.Translate(-Vector3.forward * WalkSpeed * Time.deltaTime);
    }

    public void StopWalkingB()
    {
        animator.SetBool("WalkB", false);
    }

    public void LuAtack()
    {
        animator.SetTrigger("LuAtack");
    }

    public void LdAtack()
    {
        animator.SetTrigger("LdAtack");
    }

    public void Hide()
    {
        animator.SetTrigger("Hide");
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
}
