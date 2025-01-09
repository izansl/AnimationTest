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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            WalkF();
        }
        else
        {
            StopWalkingF();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            WalkB();
        }
        else
        {
            StopWalkingB();
        }

        if (Input.GetKeyDown(KeyCode.O)) SuAtack();
        if (Input.GetKeyDown(KeyCode.P)) SdAtack();
        if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();
        if (Input.GetKeyDown(KeyCode.DownArrow)) Hide();
        if (Input.GetKeyDown(KeyCode.L)) LuAtack();
        if (Input.GetKeyDown(KeyCode.K)) LdAtack();
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
        animator.SetTrigger("short_atack");
    }

    public void SuAtack()
    {
        animator.SetTrigger("heavy_atack");
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
        animator.SetTrigger("low_quick_atack");
    }

    public void LdAtack()
    {
        animator.SetTrigger("low_heavy_atack");
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
