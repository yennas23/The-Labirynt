using UnityEngine;
using System.Collections;


public class zombieMoves : MonoBehaviour
{
private Transform goal;
private UnityEngine.AI.NavMeshAgent agent;
private Animation zombieAnimation;


void Start()
{
goal = Camera.main.transform;
agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
zombieAnimation = GetComponent<Animation>();
agent.destination = goal.position;


// Start the walking animation
zombieAnimation.Play("walk");


// Set the walking animation to loop
AnimationClip walkAnimation = zombieAnimation.GetClip("walk");
walkAnimation.wrapMode = WrapMode.Loop;
}


void Update()
{
agent.destination = Camera.main.transform.position;
}


void OnTriggerEnter (Collider col)
{
//first disable the zombie's collider so multiple collisions cannot occur
GetComponent<CapsuleCollider>().enabled = false;
//destroy the bullet
Destroy(col.gameObject);
//stop the zombie from moving forward by setting its destination to it's current position
agent.destination = gameObject.transform.position;
//stop the walking animation and play the falling back animation
GetComponent<Animation>().Stop ();
GetComponent<Animation>().Play ("death1");
//destroy this zombie in six seconds.
Destroy (gameObject, 6);
//instantiate a new zombie

}


}



