using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiemovesss : MonoBehaviour
{
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animation zombieAnimation;

    void Start()
    {
        goal = Camera.main.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        zombieAnimation = GetComponent<Animation>();

        // Start the walking animation
        zombieAnimation.Play("walk");

        // Set the walking animation to loop
        AnimationClip walkAnimation = zombieAnimation.GetClip("walk");
        walkAnimation.wrapMode = WrapMode.Loop;

        StartCoroutine(StartFollowingCamera());
    }

    IEnumerator StartFollowingCamera()
    {
        // Delay for 10 seconds
        yield return new WaitForSeconds(10f);

        // Set the destination of the agent to the current position of the camera
        agent.destination = goal.position;
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
    GetComponent<Animation>().Play ("back_fall");
    //destroy this zombie in six seconds.
    Destroy (gameObject, 6);
    //instantiate a new zombie
    GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

    //set the coordinates for a new vector 3
    float randomX = UnityEngine.Random.Range (-12f,12f);
    float constantY = .01f;
    float randomZ = UnityEngine.Random.Range (-13f,13f);
    //set the zombies position equal to these new coordinates
    zombie.transform.position = new Vector3 (randomX, constantY, randomZ);

    //if the zombie gets positioned less than or equal to 3 scene units away from the camera we won't be able to shoot it
    //so keep repositioning the zombie until it is greater than 3 scene units away. 
    while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 3) {
      
      randomX = UnityEngine.Random.Range (-12f,12f);
      randomZ = UnityEngine.Random.Range (-13f,13f);

      zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
    }

  }
   
}
