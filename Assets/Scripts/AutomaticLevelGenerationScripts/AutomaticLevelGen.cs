using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

/*       *************IMPORTANT*************
This script reads a text file line by line , word by word & assigns the below data accordingly.
This script is also responsible for storing the PlayerSpawn, Destination & Gift, SurferBoard Count and all of its related data.
Few things to remember on the script.

'A' - 1 Cube
'B' - 2 Cube
'C' - 3 Cube
'D' - 4 Cube
'E' - 5 Cube
*/
public class AutomaticLevelGen : MonoBehaviour
{
    //Grabbing assets of all required
    [Header("Level Base")]
    public GameObject spawnPoint; // SpawnPoint / Starting Point
    public GameObject endPoint; // Holds the destination GameObject
    public GameObject gift;    // Holds the gift GameObject
    public GameObject rails; //Place where surfer sits
    public GameObject playerSpawner;  // Holds the character
    public GameObject surferBoard; // SurferBoard and its count
    
    int surferBoardCount; //Count of the Surfer Board

    string LevelName;

    void Start()
    {
        LevelName = SceneManager.GetActiveScene().name.ToString();
        string[][] LevelLoader = readFile(LevelName);

        // Instantiates GameObjects according to given Data 
        for (int x = 0; x < LevelLoader.Length; x++)
        {
            for (int z = 0; z < LevelLoader[x].Length; z++)
            {
                switch (LevelLoader[x][z])
                {
                    case "AD":
                        surferBoardCount = 1;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 90f, 0))) ;
                        break;
                    case "AU":
                        surferBoardCount = 1;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 270f, 0)));
                        break;
                    case "AR":
                        surferBoardCount = 1;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 0f, 0)));
                        break;
                    case "AL":
                        surferBoardCount = 1;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 180f, 0)));
                        break;
                    case "BD":
                        surferBoardCount = 2;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x,z);
                        Instantiate(playerSpawner, new Vector3(x, 2.7f, z), Quaternion.Euler(new Vector3(0, 90f, 0)));
                        break;
                    case "BU":
                        surferBoardCount = 2;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.7f, z), Quaternion.Euler(new Vector3(0, 270f, 0)));
                        break;
                    case "BR":
                        surferBoardCount = 2;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.7f, z), Quaternion.identity);
                        break;
                    case "BL":
                        surferBoardCount = 2;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.7f, z), Quaternion.Euler(new Vector3(0, 180f, 0)));
                        break;
                    case "CD":
                        surferBoardCount = 3;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3f, z), Quaternion.Euler(new Vector3(0, 90f, 0)));
                        break;
                    case "CU":
                        surferBoardCount = 3;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3f, z), Quaternion.Euler(new Vector3(0, 270f, 0)));
                        break;
                    case "CR":
                        surferBoardCount = 3;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3f, z), Quaternion.identity);
                        break;
                    case "CL":
                        surferBoardCount = 3;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3f, z), Quaternion.Euler(new Vector3(0, 180f, 0)));
                        break;
                    case "DD":
                        surferBoardCount = 4;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3.4f, z), Quaternion.Euler(new Vector3(0, 90f, 0)));
                        break;
                    case "DU":
                        surferBoardCount = 4;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3.4f, z), Quaternion.Euler(new Vector3(0, 270f, 0)));
                        break;
                    case "DR":
                        surferBoardCount = 4;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3.4f, z), Quaternion.identity);
                        break;
                    case "DL":
                        surferBoardCount = 4;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 3.4f, z), Quaternion.Euler(new Vector3(0, 180f, 0)));
                        break;
                    case "ED":
                        surferBoardCount = 5;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 90f, 0)));
                        break;
                    case "EU":
                        surferBoardCount = 5;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 270f, 0)));
                        break;
                    case "ER":
                        surferBoardCount = 5;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.identity);
                        break;
                    case "EL":
                        surferBoardCount = 5;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        StackCubes(x, z);
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.Euler(new Vector3(0, 180f, 0)));
                        break;
                    case "2":
                        Instantiate(rails, new Vector3(x, 1.95f, z), Quaternion.identity);  //Instantiates rails (Surfer Holders / Place for surfers to sit)
                        break;
                    case "3":
                        GameObject destinationRef = Instantiate(endPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Destination
                        GameObject giftRef = Instantiate(gift, new Vector3(transform.position.x, 15f, transform.position.z), Quaternion.identity); //Instantiates 
                        giftRef.transform.SetParent(destinationRef.transform, true);
                        break;
                }
            }
        }
    }

    private void StackCubes(int x, int z)
    {
        float a = 0;
        for (int i = 0; i < surferBoardCount; i++, a += 0.3f)
        {
            Instantiate(surferBoard, new Vector3(x, 2.3f + a, z), Quaternion.identity);
            if (i > surferBoardCount) break;
        }
    }

    //Function to read the file and parse through each texts one by one
    string[][] readFile(string fileName)
    {
        TextAsset LoadedtextFile = Resources.Load(fileName) as TextAsset;
        string text = LoadedtextFile.text;
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length - 1;
        string[][] levelBase = new string[rows][];
        for (int i = 0; i < rows; i++)
        {
            string[] stringsOfLine = Regex.Split(lines[i], ",");
            levelBase[i] = stringsOfLine;
        }
        return levelBase;
    }
}