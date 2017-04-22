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
        int x = findHero()[0];
        int z = findHero()[1];
       

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (map[x + 1, z].GetType().Name == "Wall")
                {

                }
                else if (map[x + 1, z].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("N", x, z);
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (map[x - 1, z].GetType().Name == "Wall")
                {

                }
                else if (map[x - 1, z].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("S", x, z);
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (map[x, z + 1].GetType().Name == "Wall")
                {

                }
                else if (map[x, z + 1].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("E", x, z);
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (map[x, z - 1].GetType().Name == "Wall")
                {

                }
                else if (map[x, z - 1].GetType().Name == "enemyUnit")
                {
                    Debug.Log("Combat!");
                }
                else
                {
                    moveHero("W", x, z);
                }

            }
            drawMapFromArray(map);
       

       
    }

    void drawMapFromArray(baseObject [,] map)
    {
        for (int x = 0; x < HEIGHT; x++)
        {
            for (int z = 0; z < WIDTH; z++)
            {
                baseObject unit = map[x, z];
                if (unit.NeedsUpdating)
                {
                    Destroy(unit.DisplayObject);
                    string t = unit.Type;
                    switch (t)
                    {
                        case "1":
                            unit.DisplayObject = Instantiate(wallPrefab, new Vector3((z * 10) - ((WIDTH / 2) * 10), 5, (x * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                            break;
                        case "Z":
                            unit.DisplayObject = Instantiate(zombiePrefab, new Vector3((z * 10) - ((WIDTH / 2) * 10), 5, (x * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
                            break;
                        case "H":
                            unit.DisplayObject = Instantiate(heroPrefab, new Vector3((z * 10) - ((WIDTH / 2) * 10), 5, (x * 10) - ((HEIGHT / 2) * 10)), Quaternion.identity);
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
               
                z++;
            }
            Debug.Log(z);
            z = 0;
            x++;

        }
        Debug.Log(x + " " + z + " " + HEIGHT + " " + WIDTH);
        return temp;
    }

    private int[] findHero()
    {
        baseObject h;
        int[] tempPos = new int[2];
        for (int x = 0; x < HEIGHT; x++)
        {
            for (int z = 0; z < HEIGHT; z++)
            {
                if (map[x,z].Type == "H")
                {
                    tempPos[0] = x;
                    tempPos[1] = z;
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
