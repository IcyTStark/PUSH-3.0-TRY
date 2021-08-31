using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

/*       *************IMPORTANT*************
This script reads a text file line by line , word by word & assigns the below data accordingly.
This script is also responsible for storing the PlayerSpawn, Destination & Gift, SurferBoard Count and all of its related data.
Few things to remember on the script.

'A' - 1 Surfer
'B' - 2 Surfer
'C' - 3 Surfer
'D' - 4 Surfer
'E' - 5 Surfer
*/
public class AutomaticLevelGen : MonoBehaviour
{
    //Grabbing assets of all required
    [Header("Level Base")]
    public GameObject spawnPoint; // SpawnPoint / Starting Point
    public GameObject destination; // Holds the destination GameObject
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
                    case "A":
                        surferBoardCount = 1;   
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        float a = 0;
                        for (int i = 0; i < surferBoardCount; i++, a += 0.3f)
                        {
                            Instantiate(surferBoard, new Vector3(x, 2.3f + a, z), Quaternion.identity);
                            if (i > surferBoardCount) break;
                        }
                        Instantiate(playerSpawner, new Vector3(x, 2.4f,z),Quaternion.identity);
                        break;
                    case "B":
                        surferBoardCount = 2;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        float b = 0;
                        for (int i = 0; i < surferBoardCount; i++, b += 0.3f)
                        {
                            Instantiate(surferBoard, new Vector3(x, 2.3f + b, z), Quaternion.identity);
                            if (i > surferBoardCount) break;
                        }
                        Instantiate(playerSpawner, new Vector3(x, 2.7f, z), Quaternion.identity);
                        break;
                    case "C":
                        surferBoardCount = 3;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        float c = 0;
                        for (int i = 0; i < surferBoardCount; i++, c += 0.3f)
                        {
                            Instantiate(surferBoard, new Vector3(x, 3f + c, z), Quaternion.identity);
                            if (i > surferBoardCount) break;
                        }
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.identity);
                        break;
                    case "D":
                        surferBoardCount = 4;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        float d = 0;
                        for (int i = 0; i < surferBoardCount; i++, d += 0.3f)
                        {
                            Instantiate(surferBoard, new Vector3(x, 2.3f + d, z), Quaternion.identity);
                            if (i > surferBoardCount) break;
                        }
                        Instantiate(playerSpawner, new Vector3(x, 3.4f, z), Quaternion.identity);
                        break;
                    case "E":
                        surferBoardCount = 5;
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        float e = 0;
                        for (int i = 0; i < surferBoardCount; i++, e += 0.3f)
                        {
                            Instantiate(surferBoard, new Vector3(x, 3.7f + e, z), Quaternion.identity);
                            if (i > surferBoardCount) break;
                        }
                        Instantiate(playerSpawner, new Vector3(x, 2.4f, z), Quaternion.identity);
                        break;
                    case "2":
                        Instantiate(rails, new Vector3(x, 1.95f, z), Quaternion.identity);  //Instantiates rails (Surfer Holders / Place for surfers to sit)
                        break;
                    case "3":
                        GameObject destinationRef = Instantiate(destination, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Destination
                        GameObject giftRef = Instantiate(gift, new Vector3(transform.position.x, 15f, transform.position.z), Quaternion.identity); //Instantiates 
                        giftRef.transform.SetParent(destinationRef.transform, true);
                        break;
                }
            }
        }
    }

    //Function to read the file and parse through each texts one by one
    string[][] readFile(string fileName)
    {
        TextAsset textFile = Resources.Load(fileName) as TextAsset;
        string text = textFile.text;
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;
        //Debug.Log(rows);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] stringsOfLine = Regex.Split(lines[i], ",");
            Debug.Log(stringsOfLine[i].Length);
            //levelBase[i] = stringsOfLine;
        }
        string[][] levelBase = new string[rows][];
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    string[] stringsOfLine = Regex.Split(lines[i], ",");
        //    levelBase[i] = stringsOfLine;
        //}
        return levelBase;
    }
}