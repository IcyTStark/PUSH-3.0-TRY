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

    public int index;
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
                    #region 1-Surfer CodeBlock
                    case "AD":
                        SpawnSurferAndPlayer(x, z, 1, 2.4f, 90f);
                        break;                        
                    case "AU":                        
                        SpawnSurferAndPlayer(x, z, 1, 2.4f, 270f);
                        break;                        
                    case "AR":                        
                        SpawnSurferAndPlayer(x, z, 1, 2.4f, 0f);
                        break;                        
                    case "AL":                        
                        SpawnSurferAndPlayer(x, z, 1, 2.4f, 180f);
                        break;

                    #endregion

                    #region 2-Surfer CodeBlock
                    case "BD":
                        SpawnSurferAndPlayer(x, z, 2, 2.7f, 90f);
                        break;                        
                    case "BU":                        
                        SpawnSurferAndPlayer(x, z, 2, 2.7f, 270f);
                        break;                        
                    case "BR":                        
                        SpawnSurferAndPlayer(x, z, 2, 2.7f, 0f);
                        break;                        
                    case "BL":                        
                        SpawnSurferAndPlayer(x, z, 2, 2.7f, 180f);
                        break;
                    #endregion

                    #region 3-Surfer CodeBlock
                    case "CD":
                        SpawnSurferAndPlayer(x, z, 3, 3.0f, 90f);
                        break;                        
                    case "CU":                        
                        SpawnSurferAndPlayer(x, z, 3, 3.0f, 270f);
                        break;                        
                    case "CR":                        
                        SpawnSurferAndPlayer(x, z, 3, 3.0f, 0f);
                        break;                        
                    case "CL":                        
                        SpawnSurferAndPlayer(x, z, 3, 3.0f, 180f);
                        break;
                    #endregion

                    #region 4-Surfer CodeBlock
                    case "DD":
                        SpawnSurferAndPlayer(x, z, 4, 3.3f, 90f);
                        break;                        
                    case "DU":                        
                        SpawnSurferAndPlayer(x, z, 4, 3.3f, 270f);
                        break;                        
                    case "DR":                        
                        SpawnSurferAndPlayer(x, z, 4, 3.3f, 0f);
                        break;                        
                    case "DL":                        
                        SpawnSurferAndPlayer(x, z, 4, 3.3f, 180f);
                        break;
                    #endregion

                    #region 5-Surfer CodeBlock
                    case "ED":
                        SpawnSurferAndPlayer(x, z, 5, 3.6f, 90f);
                        break;
                    case "EU":
                        SpawnSurferAndPlayer(x, z, 5, 3.6f, 270f);
                        break;
                    case "ER":
                        SpawnSurferAndPlayer(x, z, 5, 3.6f, 0f);
                        break;
                    case "EL":
                        SpawnSurferAndPlayer(x, z, 5, 3.6f, 180f);
                        break;
                    #endregion

                    #region Rails / SurferSlots
                    case "2":
                        index++;
                        GameObject Rail = Instantiate(rails, new Vector3(x, 1.95f, z), Quaternion.identity);  //Instantiates rails (Surfer Holders / Place for surfers to sit)
                        Rail.GetComponent<SurferSlots>().slotIndex = index; 
                        Rail.GetComponent<SurferSlots>().slotPosition = new Vector3(x, 0, z);
                        break;
                    #endregion

                    #region Destination / EndPoint
                    case "3":
                        index++;
                        GameObject destinationRef = Instantiate(endPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Destination
                        GameObject giftRef = Instantiate(gift, new Vector3(transform.position.x, 15f, transform.position.z), Quaternion.identity); //Instantiates 
                        giftRef.transform.SetParent(destinationRef.transform, true);
                        destinationRef.GetComponent<EndingPoint>().endingPointIndex = index;
                        destinationRef.GetComponent<EndingPoint>().endingPointPosition = new Vector3(x, 0, z);
                        break;
                    #endregion

                    case "0":
                        index++;
                        break;
                }
            }
        }
    }

    //Spawn Surfer (int xlocation, int zlocation, surfersCountStacked, PlayerPositionInY, playerRotationWhileSpawning)
    private void SpawnSurferAndPlayer(int x, int z,int surferCount,float playerSpawnYPosition,float playersRotationAngle)
    {
        index++;
        surferBoardCount = surferCount;
        GameObject startPoint = Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
        startPoint.GetComponent<StartingPoint>().startingPointIndex = index;
        startPoint.GetComponent<StartingPoint>().startingPointPosition = new Vector3(x, 0, z);
        float a = 0;
        for (int i = 0; i < surferBoardCount; i++, a += 0.3f)
        {
            GameObject surfer = Instantiate(surferBoard, new Vector3(x, 2.3f + a, z), Quaternion.identity);
            surfer.GetComponent<Surfer>().surferIndex = index;
            surfer.GetComponent<Surfer>().SurferPosition = new Vector3(x, 0, z);
            if (i > surferBoardCount) break;
        }
        Instantiate(playerSpawner, new Vector3(x, playerSpawnYPosition, z), Quaternion.Euler(new Vector3(0,playersRotationAngle, 0)));
    }

    //Function to read the file and parse through each texts one by one
    string[][] readFile(string fileName)
    {
        TextAsset LoadedtextFile = Resources.Load(fileName) as TextAsset;
        string text = LoadedtextFile.text;
        string[] lines = Regex.Split(text, "\r\n"); //We get our rows data here (lines here are our rows)
        string[] rowItemsCount = Regex.Split(lines[0], ","); //With one of the rows data we take its lenght and define the column size
        int rows = lines.Length - 1;                //We get the row length
        int column = rowItemsCount.Length;               //As we already have our row data we are trying to access the components and fix column length here. Now we have our column lenght too
        string[][] levelBase = new string[rows][];
        for (int i = 0; i < rows; i++)
        {
            string[] stringsOfLine = Regex.Split(lines[i], ",");
            levelBase[i] = stringsOfLine;
        }
        return levelBase;
    }
}