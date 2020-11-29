using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //Animator Variable
    Animator anim;
    public float speed;
    private float waitingTime;
    public float beginWaitTime;
    


    public Transform[] moveArea;
    private int randomSpot;

    void Start(){
         //Animator
        anim = this.GetComponent<Animator>();
        waitingTime = beginWaitTime;
        randomSpot = Random.Range(0,moveArea.Length);
    }

    void Update(){

        transform.position = Vector3.MoveTowards(transform.position, moveArea[randomSpot].position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveArea[randomSpot].position) < 0.2f){

            if(waitingTime <=0){
                 randomSpot = Random.Range(0,moveArea.Length);
                this.transform.Rotate(0,180, 0);
                 waitingTime = beginWaitTime;
                 anim.SetBool("isIdle", false);
              
                 

            }else{
                waitingTime -=Time.deltaTime;
                anim.SetBool("isIdle", true);
            }

        }
    }
}
