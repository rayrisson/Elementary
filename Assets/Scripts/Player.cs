using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isTransform;
    private bool isJumping;

    public bool isImune = false;
    public float speed;
    public float jumpForce;

    private GameMaster gm;
    private Rigidbody2D rigidBody;
    private Animator animator;
    public RuntimeAnimatorController[] allControllers;

    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpoint;
        isJumping = false;
        isTransform = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        ChooseTransform();
    }

    void ChooseTransform(){
        if(Input.GetKeyDown(KeyCode.E)){
            isTransform = true;
        }   
        if (Input.GetKeyUp(KeyCode.E)){
            isTransform = false;
        }
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position +=  movement * Time.deltaTime * speed;

        if(Input.GetAxis("Horizontal") > 0f){
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if(Input.GetAxis("Horizontal") < 0f){
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if(Input.GetAxis("Horizontal") == 0f){
            animator.SetBool("walk", false);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && !isJumping){
            rigidBody.AddRelativeForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.layer == 8 && isTransform){
            TransformPlayer(other.gameObject.tag);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Key"){
            Debug.Log("Chave coletada");

            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Door");
            foreach(GameObject t in gameObject){
                GameObject.Destroy(t);
            }

            GameObject chave = GameObject.FindWithTag("Key");
            GameObject.Destroy(chave);
        }

        
    }

    void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Spikes" || other.gameObject.tag == "Brick"){
            isJumping = false;
            animator.SetBool("jump", false);
        }

        if(other.gameObject.tag == "Spikes" && !isImune){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground"){
            isJumping = false;
            animator.SetBool("jump", false);
        }

        if(other.gameObject.tag == "Death"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Spikes"){
            isJumping = true;
            animator.SetBool("jump", true);
        }
        if(other.gameObject.tag == "Ground"){
            isJumping = true;
            animator.SetBool("jump", true);
        }
        if(other.gameObject.tag == "Brick"){
            isJumping = true;
            animator.SetBool("jump", true);
        }
    }

    void TransformPlayer(string tag){
        DestroyActualTransformation();

        if(tag == "FireToken"){
                animator.runtimeAnimatorController = allControllers[0];
                gameObject.AddComponent<Fire>();
        }

        if(tag == "GroundToken"){
                animator.runtimeAnimatorController = allControllers[1];
                gameObject.AddComponent<Ground>();
        }

        if(tag == "WaterToken"){
                animator.runtimeAnimatorController = allControllers[2];
                gameObject.AddComponent<Water>();
        }

        if(tag == "AirToken"){
                animator.runtimeAnimatorController = allControllers[3];
                gameObject.AddComponent<Wind>();
        } 
    } 
                

    void DestroyActualTransformation(){
        Destroy(GetComponent<Water>());
        Destroy(GetComponent<Wind>());
        Destroy(GetComponent<Ground>());
        Destroy(GetComponent<Fire>());
    }
}
