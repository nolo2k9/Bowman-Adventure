using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    public static GameObject player;

    public static GameObject currentPlatform;

    bool canTurn = false;

    void OnCollisionEnter(Collision other)
    {
        currentPlatform = other.gameObject;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
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
        if (Input.GetKey(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateLevel.dummyTraveller.transform.forward =
                -this.transform.forward;
            GenerateLevel.RunDummy();
        }
        else //left arrow
        if (Input.GetKey(KeyCode.LeftArrow) && canTurn)
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
