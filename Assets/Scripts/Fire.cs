using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator animator;
    public bool activeFire = false;
    bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // FireClick();
        if(Input.GetButtonDown("Fire1") && canAttack){
            StartCoroutine(ActiveAbility());
        }
    }

    // void FireClick(){
    //     if(Input.GetButtonDown("Fire1")){
    //         activeFire = true;
    //     }   
    //     if (Input.GetButtonUp("Fire1")){
    //         activeFire = false;
    //     }
    // }
    void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "BlockedWall"){
            Debug.Log("teste");
        }
        if(other.gameObject.tag == "BlockedWall" && activeFire){
            Debug.Log("teste2");
            Destroy(other.gameObject);
        }
    }

    IEnumerator ActiveAbility()
    {
        canAttack = false;
        activeFire = true;
        animator.SetTrigger("ability");
        yield return new WaitForSeconds(2);
        activeFire = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }
}
