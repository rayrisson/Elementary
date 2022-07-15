using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Animator animator;
    private bool recoil;
    private bool coroutineIsActive;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        recoil = false;
        coroutineIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!coroutineIsActive){
            StartCoroutine(ActiveAbility());
        }
    }


    IEnumerator ActiveAbility()
    {
        if(Input.GetButtonDown("Fire1") && recoil == false){
            coroutineIsActive = true;
            animator.SetBool("ability", true);
            player.isImune = true;
            yield return new WaitForSeconds (4); 
            player.isImune = false;
            animator.SetBool("ability", false);
            recoil = true;
        }else if(recoil == true){
            coroutineIsActive = true;
            yield return new WaitForSeconds (3);
            recoil = false;
        }

        coroutineIsActive = false;
    }
}
