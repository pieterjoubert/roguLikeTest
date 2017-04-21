using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

    public GameObject wall;
    public int WIDTH;
    public int HEIGHT;
    // Use this for initialization
    void Start() {
        int[,] map = new int[WIDTH, HEIGHT];
        for (int z = 0; z < WIDTH; z++)
        {
            for (int x = 0; x < HEIGHT; x++)
            {
                map[z, x] = 1;
            }
        }
        drawMapFromArray(map);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void drawMapFromArray(int [,] map)
    {
        for (int z = 0; z < WIDTH; z++)
        {
            for (int x = 0; x < HEIGHT; x++)
            {
                Instantiate(wall, new Vector3(x * 10, 5, z * 10), Quaternion.identity);
            }
        }
    }
   
}
