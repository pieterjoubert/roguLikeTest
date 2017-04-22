using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject followee;
    public float height;
    
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(followee.transform.position.x, height, followee.transform.position.z);
    }
}
