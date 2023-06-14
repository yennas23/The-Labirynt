using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        goal = Camera.main.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        GetComponent<Animation>().Play("walk");
    }

    void OnTriggerEnter(Collider col)
    {
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(col.gameObject);
        agent.destination = gameObject.transform.position;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("idle2");//back_fall
        Destroy(gameObject, 6);

        GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

        float randomX = UnityEngine.Random.Range(-12f, 12f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-13f, 13f);

        zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3)
        {
            randomX = UnityEngine.Random.Range(-12f, 12f);
            randomZ = UnityEngine.Random.Range(-13f, 13f);

            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }
    }
}