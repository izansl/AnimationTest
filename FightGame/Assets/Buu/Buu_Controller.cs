using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buu_Controller : MonoBehaviour
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
        animator.SetBool("win", true);
    }

    public void Lose()
    {
        animator.SetBool("loose", true);
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
        animator.SetBool("walk_front", true);
        Player.transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
    }

    public void StopWalkingF()
    {
        animator.SetBool("walk_front", false);
    }

    public void WalkB()
    {
        animator.SetBool("walk_back", true);
        Player.transform.Translate(-Vector3.forward * WalkSpeed * Time.deltaTime);
    }

    public void StopWalkingB()
    {
        animator.SetBool("walk_back", false);
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
        animator.SetTrigger("block");
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }
}
