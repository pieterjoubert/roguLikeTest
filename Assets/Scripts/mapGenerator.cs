using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

    public GameObject wallPrefab;
    public GameObject floorPrefab;
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
        int z = findHero()[0];
        int x = findHero()[1];
       

/*            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (map[z + 1, x].GetType().Name == "Wall")
                {

                }
                else if (map[z + 1, x].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("N", z, x);
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (map[z - 1, x].GetType().Name == "Wall")
                {

                }
                else if (map[z - 1, x].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("S", z, x);
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (map[z, x + 1].GetType().Name == "Wall")
                {

                }
                else if (map[z, x + 1].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("E", z, x);
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (map[z, x - 1].GetType().Name == "Wall")
                {

                }
                else if (map[z, x - 1].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("W", z, x);
                }

            }*/

            if ( Input.GetMouseButtonDown (0)){ 
                Debug.Log("Clicking...");
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,200.0f)) {
                Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.white);
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
            }
       

       
    }

    void drawMapFromArray(baseObject [,] map)
    {
        for (int z = 0; z < HEIGHT; z++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                baseObject unit = map[z, x];
                if (unit.NeedsUpdating)
                {
                    Destroy(unit.DisplayObject);
                    string t = unit.Type;
                    switch (t)
                    {
                        case "0":
                            unit.DisplayObject = Instantiate(floorPrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 0, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                            break;
                        case "1":
                            unit.DisplayObject = Instantiate(wallPrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 6, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                            break;
                        case "Z":
                            unit.DisplayObject = Instantiate(zombiePrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 6, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                            break;
                        case "H":
                            unit.DisplayObject = Instantiate(heroPrefab, new Vector3((x * 10) - ((WIDTH / 2) * 10), 6, (z * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                            Camera.main.GetComponent<cameraMovement>().followee = unit.DisplayObject;
                            break;
                        default:
                            break;
                    }
                    unit.NeedsUpdating = false;
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
                //Debug.Log("B" + x + " " + z);
                switch (c)
                {
                    case '0':
                        Floor floor = new Floor();
                        temp[z, x] = floor;
                        break;
                    case '1':
                        Wall wall = new Wall();
                        temp[z, x] = wall;
                        break;
                    case'Z':
                        enemyUnit zombie = new enemyUnit();
                        temp[z, x] = zombie;
                        break;
                    case 'H':
                        heroUnit hero = new heroUnit();
                        temp[z, x] = hero;
                        break;
                    default:
                        break;
                }
               
                x++;
            }
            Debug.Log(x);
            x = 0;
            z++;

        }
        Debug.Log(z + " " + x + " " + HEIGHT + " " + WIDTH);
        return temp;
    }

    private int[] findHero()
    {
        baseObject h;
        int[] tempPos = new int[2];
        for (int z = 0; z < HEIGHT; z++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (map[z,x].Type == "H")
                {
                    tempPos[0] = z;
                    tempPos[1] = x;
                    return tempPos;
                 }
            }
        }
        return tempPos;

    }

    private void moveHero(string dir,int x, int z)
    {
        
        Floor f = new Floor();
        Unit h = (Unit) map[x, z];
        map[x, z] = f;
        switch (dir)
        {
            case "N":
                x++; //move up
                break;
            case "S":
                x--; //move up
                break;
            case "E":
               z++; //move up
                break;
            case "W":
                z--; //move up
                break;
            default:
                break;
        }
        h.Destination = new Vector3(x * 10, 0, z * 10);
        map[x, z] = h;
        map[x, z].NeedsUpdating = true;
        map[x, z].IsMoving = true;
    }

   
   
}
