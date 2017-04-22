using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    private string dir;
    public float speed;
    private bool inCollision = false;

	// Use this for initialization
	void Start () {
        //set start direction
        float d = Random.value;
        if(d <= 0.25)
        {
            dir = "N";
        }
        else if (d > 0.25 && d <= 0.5)
        {
            dir = "E";
        }
        else if (d > 0.5 && d <= 0.75)
        {
            dir = "S";
        }
        else if (d > 0.75)
        {
            dir = "W";
        }
    }
	
	// Update is called once per frame
	void Update () {
       
            switch (dir)
            {
                case "N":
                    this.transform.position = new Vector3(this.transform.position.x + (speed * Time.deltaTime), 5, this.transform.position.z);
                    break;
                case "E":
                    this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z + (speed * Time.deltaTime));
                    break;
                case "S":
                    this.transform.position = new Vector3(this.transform.position.x - (speed * Time.deltaTime), 5, this.transform.position.z);
                    break;
                case "W":
                    this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z - (speed * Time.deltaTime));
                    break;
                default:
                    break;
            }
        
       
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        
        switch (dir)
        {
            case "N":
                dir = "S";
                this.transform.position = new Vector3(this.transform.position.x - (speed * Time.deltaTime), 5, this.transform.position.z);
                break;
            case "E":
                dir = "W";
                this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z - (speed * Time.deltaTime));
                break;
            case "S":
                dir = "N";
                this.transform.position = new Vector3(this.transform.position.x + (speed * Time.deltaTime), 5, this.transform.position.z);
                break;
            case "W":
                dir = "E";
                this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z + (speed * Time.deltaTime));
                break;
            default:
                break;
        }
       
    }

   


}
