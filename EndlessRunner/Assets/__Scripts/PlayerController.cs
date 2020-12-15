using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
This class handles all of the controls and behaviour for the player.
*/
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

    public static AudioSource[] sfx;

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

    //how high player can jump
    public float jumpVelocity;

    //check if player is gounded
    private bool isGrounded;

    //jumping amount
    private float jumpAmount;

    //highscore variable
    private int hScore;

    //This method restarts the scene
    void RestartScene()
    {
        //using scenemanager to reload the given scene
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    void OnCollisionEnter(Collision other)
    {
        //seting isGrounded to true
        isGrounded = true;

        //jumpAmount set to 0
        jumpAmount = 0;

        //if collision is fire and you are not dead
        if (
            other.gameObject.tag == "Fire" ||
            other.gameObject.tag == "Enemy" ||
            other.gameObject.tag == "Wall" && !dead
        )
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
            else
            {
                //the last icon

                healthIcons[0].texture = healthLost;

                //setting the game over scene to show

                gameOver.SetActive(true);

                //play game over sound

                sfx[2].Play();

                //play dead animation
                anim.SetTrigger("isDead");

                //Setting the previous score to be the players previous score
                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));

                //if PlayerPrefs contains the key Highscore
                if (PlayerPrefs.HasKey("highscore"))
                {
                    //setting hScore to be the highscore
                    hScore = PlayerPrefs.GetInt("highscore");
                }

                //if the previous score is higher than the last highscore
                if (hScore < PlayerPrefs.GetInt("score"))
                {
                    //set the previous score to be the new highscore
                    PlayerPrefs
                        .SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
                else
                {
                    //set the previous score to be the new highscore
                    PlayerPrefs
                        .SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
            }
        }
        //setting current platform
        else
        {
            currentPlatform = other.gameObject;
        }
    }

    void Start()
    {
        //Find objects with audiosource
        sfx =
            GameObject
                .FindWithTag("Data")
                .GetComponentsInChildren<AudioSource>();

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
        //run the generateLevel runDummy
        if (
            other is BoxCollider &&
            GenerateLevel.lastPlatform.tag != "T-Junction"
        ) GenerateLevel.RunDummy();
        //if player eneters spehere on t-juntion enable can turn
        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }
    //after leaving speherecollider set can turn back to false
    void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider) canTurn = false;
    }


    // Update is called once per frame
    void Update()
    {
        //if player dies return
        if (PlayerController.dead) return;
        //if space bar is pressed and is grounded is true
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            //assigning jumpAmount 
            jumpAmount -= Time.deltaTime;
            //isGrounded false
            isGrounded = false;
            //play jumping animation
            anim.SetBool("isJumping", true);
            //move the player up 
            rb.AddForce(0, jumpVelocity, 0);
            //if player jumping for this amount of time
            if (jumpAmount > 1.0f)
            {
                //set jump amount to 0
                jumpAmount = 0;
                //take player down
                rb.AddForce(0, -500, 0);
            }
        }
        //set is jumping to false
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);
        }
        //if right arrow is pressed canTurn is true
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            //turn player 90 degress
            this.transform.Rotate(Vector3.up * 90);
            //set dummy to rotate wiht player
            GenerateLevel.dummyTraveller.transform.forward =
                -this.transform.forward;
            
            GenerateLevel.RunDummy();

        }
        //if left arrow is pressed canTurn is true
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
             //turn player 90 degress
            this.transform.Rotate(Vector3.up * -90);
            //set dummy to rotate wiht player
            GenerateLevel.dummyTraveller.transform.forward =
                -this.transform.forward;
            GenerateLevel.RunDummy();
        }
        //if A is pressed
        else if (Input.GetKey(KeyCode.A))
        {
            //move player to the left
            this.transform.Translate(-5f * Time.deltaTime, 0, 0);
        }
        //if D is pressed
        else if (Input.GetKey(KeyCode.D))
        {
             //move player to the right
            this.transform.Translate(5f * Time.deltaTime, 0, 0);
        }
    }
}
