using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private bool canDash = true;
    public float dashingPower = 24f; 
    private float dashingTime = 0.2f;
    private Rigidbody2D rb;
    private Animator animator;
    private TrailRenderer tr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canDash){
            StartCoroutine(ActiveAbility());
        }
    }
    IEnumerator ActiveAbility()
    {
        canDash = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        animator.SetBool("ability", true);
        if(transform.eulerAngles.y == 0f){
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        if(transform.eulerAngles.y == 180f){
            rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        animator.SetBool("ability", false);
        rb.gravityScale = 30;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        yield return new WaitForSeconds(2);
        canDash = true;
    }
}
