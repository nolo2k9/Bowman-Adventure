using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    public static GameObject player;

    public static GameObject currentPlatform;

    public static bool dead = false;

    bool canTurn = false;
    Rigidbody rb;


    void OnCollisionEnter(Collision other)
    {   if(other.gameObject.tag == "Fire"){
        anim.SetTrigger("isDead");
        dead = true;
    }   else
            currentPlatform = other.gameObject;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        player = this.gameObject;
        GenerateLevel.RunDummy();
       
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

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.dead) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 200);
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
        }
        else //right arrow
        if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateLevel.dummyTraveller.transform.forward =
                -this.transform.forward;
            GenerateLevel.RunDummy();
        }
        else //left arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
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
