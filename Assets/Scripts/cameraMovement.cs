using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject followee;
    public float height;
    public float speed;
    
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += Vector3.forward * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position -= Vector3.forward * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += Vector3.right * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position -= Vector3.right * Time.deltaTime * speed;
            }
    }
}
