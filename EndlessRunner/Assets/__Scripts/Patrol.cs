using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class handles the patroling behaviour for the enemy ninjas.
*/
public class Patrol : MonoBehaviour
{
    //Animator Variable
    Animator anim;
    //time enemy will wait
    private float waitingTime;
    //start of wait time
    public float beginWaitTime;
    //players transform
    public Transform player;
    //Speed variable
    public float speed;
    //stop distance
    public float stopDistance = -1;
    //move points for enemy
    public Transform[] moveArea;
    //varibale to control points the enemy moves between
    private int randomSpot;

     void Start(){
         //Animator
        anim = this.GetComponent<Animator>();
        //Waiting time
        waitingTime = beginWaitTime;
        //set up the random move points
        randomSpot = Random.Range(0,moveArea.Length);
        //the players game tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }
    void Update(){
        //move towads the random points at a certain speed
        transform.position = Vector3.MoveTowards(transform.position, moveArea[randomSpot].position, speed * Time.deltaTime);
        //if the players postion is less than 2
        if(Vector3.Distance(transform.position, moveArea[randomSpot].position) < 0.2f){
            //if the waiting time is <= 0
            if(waitingTime <=0){
                //move player
                randomSpot = Random.Range(0,moveArea.Length);
                //turn the object
                this.transform.Rotate(0,180, 0);
                //set wating time
                 waitingTime = beginWaitTime;
                 // idle animation false
                 anim.SetBool("isIdle", false);
        
            }else{
                //setting wait time
                waitingTime -=Time.deltaTime;
                //play idle animation
                anim.SetBool("isIdle", true);
            }
        

        }

        
    }
}
