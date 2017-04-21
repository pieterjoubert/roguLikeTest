using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButton(1))
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            Debug.Log(h + " " + v);

            if(h < 0)
            {
                transform.Translate(new Vector3(horizontalSpeed * Time.deltaTime, 0, 0));
            }
            else if(h > 0)
            {
                transform.Translate(new Vector3(-horizontalSpeed * Time.deltaTime, 0, 0));
            }
            else if (v < 0)
            {
                transform.Translate(new Vector3(0, horizontalSpeed * Time.deltaTime, 0));
            }
            else if (v > 0)
            {
                transform.Translate(new Vector3(0, -horizontalSpeed * Time.deltaTime, 0));
            }


          
        }*/

    }
}
