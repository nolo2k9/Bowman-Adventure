using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Animator Variable
    Animator anim;

    //Player gameObject
    public static GameObject player;

    //currentPlatform GameObject
    public static GameObject currentPlatform;

    //Bool dead
    public static bool dead = false;

    //bool can turn
    bool canTurn = false;

    Rigidbody rb;

    // How much health is left
    int health;

    //Texture of image alive icon
    public Texture healthIcon;

    //Texture of life down icon
    public Texture healthLost;

    //Array of raw images
    public RawImage[] healthIcons;

    //Panel for when the player exhausts all livs
    public GameObject gameOver;

    public float jumpVelocity;
    private bool isGrounded;
    private float jumpAmount;
    private int hScore;


    
    //This method restarts the scene
    void RestartScene()
    {
        //using scenemanager to reload the given scene
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    void OnCollisionEnter(Collision other)
    {  
         isGrounded = true;
         jumpAmount = 0;

         if (other.gameObject.tag == "Platform" || 
        other.gameObject.tag=="Thin Platform" || 
        other.gameObject.tag=="T-Junction" || 
        other.gameObject.tag=="Spilt Platform"||
        other.gameObject.tag == "Coin")
        {
             isGrounded = true;
             jumpAmount = 0;
         }
        
         //if collision is fire and you are not dead
        if (other.gameObject.tag == "Fire" || other.gameObject.tag=="Enemy" || other.gameObject.tag=="Wall" && !dead)
        {
            //play dead animation
            anim.SetTrigger("isDead");
            //setting dead to true
            dead = true;

            //take health from player
            health--;

            //Get new number of lives
            PlayerPrefs.SetInt("lives", health);
            if (health > 0)
            {
                //restart the scene
                Invoke("RestartScene", 1);
            }
            else{
                //the last icon 
                healthIcons[0].texture = healthLost;
                //setting the game over scene to show 
                gameOver.SetActive(true);
                 //play dead animation
                anim.SetTrigger("isDead");
                //Setting the previous score to be the players previous score
                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));
                //if PlayerPrefs contains the key Highscore
                if(PlayerPrefs.HasKey("highscore"))
                {   //setting hScore to be the highscore
                    hScore = PlayerPrefs.GetInt("highscore");
                }
                    //if the previous score is higher than the last highscore
                    if(hScore < PlayerPrefs.GetInt("score")){
                        //set the previous score to be the new highscore
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                    }
                    else {
                        
                        //set the previous score to be the new highscore
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                    }
                      
                
            }
        }
        
        else {
            currentPlatform = other.gameObject;
        }

       
            
    }   

    void Start()
    {
        //Animator
        anim = this.GetComponent<Animator>();

        //Rigidbody
        rb = this.GetComponent<Rigidbody>();
        player = this.gameObject;

        //calling the RunDummy method from GenerateLevel
        GenerateLevel.RunDummy();

        //setting dead back to false
        dead = false;

        //current number of lives
        health = PlayerPrefs.GetInt("lives");


        //Looping through the health icons array
        //if i > than the current health
        //replace the old health image with the lives lost
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i >= health)
            {
                healthIcons[i].texture = healthLost;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (
            other is BoxCollider &&
            GenerateLevel.lastPlatform.tag != "T-Junction"
        ) GenerateLevel.RunDummy();

        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider) canTurn = false;
    }

    void StopAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    public void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("isAttacking", true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController.dead) return;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded ==true)
        {
            jumpAmount -= Time.deltaTime;
            isGrounded = false;
            anim.SetBool("isJumping", true);
            rb.AddForce(0, jumpVelocity, 0);
            if(jumpAmount > 1.0f){
                jumpAmount = 0;
                rb.AddForce(0, -500,0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);
            
            
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("isAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("isAttacking", false);
        } //right arrow
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateLevel.dummyTraveller.transform.forward =
                -this.transform.forward;
            GenerateLevel.RunDummy();
        } //left arrow
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateLevel.dummyTraveller.transform.forward =
                -this.transform.forward;
            GenerateLevel.RunDummy();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-5f * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(5f * Time.deltaTime, 0, 0);
        }
    }
}


