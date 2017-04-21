using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rogueLikeController : MonoBehaviour {

    public float moveSpeed;
    private bool inCollision = false;
    private GameObject collisionObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += this.transform.forward * Time.deltaTime * moveSpeed;
            if(!inCollision)
                Camera.main.transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= this.transform.right * Time.deltaTime * moveSpeed;
            if (!inCollision)
                Camera.main.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= this.transform.forward * Time.deltaTime * moveSpeed;
            if (!inCollision)
                Camera.main.transform.Translate(new Vector3(0,-moveSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))

        {
            this.transform.position += this.transform.right * Time.deltaTime * moveSpeed;
            if (!inCollision)
                Camera.main.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (inCollision)
            {
                Destroy(collisionObject);
                inCollision = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        inCollision = true;
        if (collision.gameObject.tag == "breakable")
            this.collisionObject = collision.gameObject;
    }

    void OnCollisionExit(Collision collision)
    {
        inCollision = false;
    }
}
