using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

    public GameObject wallPrefab;
    public GameObject heroPrefab;
    public GameObject zombiePrefab;
    private baseObject[,] map;
    public int WIDTH;
    public int HEIGHT;
    public string file;

    // Use this for initialization
    void Start() {




        map = readArrayFromFile(file);
        drawMapFromArray(map);


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            

        }
      
      
    }

    void drawMapFromArray(baseObject [,] map)
    {
        for (int x = 0; x < HEIGHT; x++)
        {
            for (int z = 0; z < HEIGHT; z++)
            {
                string t = map[x, z].Type;
                switch (t)
                {
                    case "1":
                        Instantiate(wallPrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 5, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                        break;
                    case "Z":
                        Instantiate(zombiePrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 5, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                        break;
                    case "H":
                        GameObject h = Instantiate(heroPrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 5, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                        Camera.main.GetComponent<cameraMovement>().followee = h;
                        break;
                    default:
                        break;
                }

            }
        }
        
    }

    private baseObject[,] readArrayFromFile(string f)
    {

        //read file
        string[] lines = System.IO.File.ReadAllLines(f);
    
        //get map size
        WIDTH = lines[0].Length;
        HEIGHT = lines.Length;
        Debug.Log(HEIGHT + " " + WIDTH);

        //create temp map object
        baseObject[,] temp = new baseObject[HEIGHT, WIDTH];

        //reverse array
        string[] tempLines = new string[HEIGHT];
        int j = 0;
        for(int i = HEIGHT -1; i >= 0; i--)
        {
            tempLines[j] = lines[i];
            j++;
        }

        //create objects and populate map
        int x = 0;
        int z = 0;
        foreach(string line in tempLines)
        {
            foreach(char c in line)
            {
                Debug.Log("B" + x + " " + z);
                switch (c)
                {
                    case '0':
                        Floor floor = new Floor();
                        temp[x, z] = floor;
                        break;
                    case '1':
                        Wall wall = new Wall();
                        temp[x, z] = wall;
                        break;
                    case'Z':
                        enemyUnit zombie = new enemyUnit();
                        temp[x, z] = zombie;
                        break;
                    case 'H':
                        heroUnit hero = new heroUnit();
                        temp[x, z] = hero;
                        break;
                    default:
                        break;
                }
                Debug.Log(x + " " + z);
                x++;
            }
            x = 0;
            z++;

        }

        return temp;
    }
   
}
