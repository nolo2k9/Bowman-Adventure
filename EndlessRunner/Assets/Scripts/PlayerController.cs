using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;

    void OnCollisionEnter(Collision other) {

        currentPlatform = other.gameObject;
        
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        player = this.gameObject;
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
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up * 90);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up * -90);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-5 * Time.deltaTime, 0, 0); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(5 * Time.deltaTime, 0, 0); 
        }
    }
}
