using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPEED : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Vertical");
    float moveZ = Input.GetAxis("Horizontal");

    // Menggunakan input dan kecepatan untuk menggerakkan XR Origin
    transform.Translate(new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime);
    }
}
