using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

/*       *************IMPORTANT*************
This script reads a text file line by line , word by word & assigns the below data accordingly.
This script is also responsible for storing the PlayerSpawn, Destination & Gift, SurferBoard Count and all of its related data.
Few things to remember on the script.

'1' - Place where the starting tile/block , player , surfers spawn.
'2' - SurferBoard Holders
'3' - Destination & Gift Spawn
*/

public class AutomaticLevelGenerator : MonoBehaviour
{
    //Grabbing assets of all required
    [Header("Level Base")]
    public GameObject spawnPoint; // SpawnPoint / Starting Point
    public GameObject destination; // Holds the destination GameObject
    public GameObject gift;    // Holds the gift GameObject
    public GameObject rails; //Place where surfer sits
    //public GameObject playerSpawner;  // Holds the character
    //public GameObject surferBoard; // SurferBoard and its count
    //public int surferBoardCount; //Count of the Surfer Board

    [Serializable]
    public class SurferData
    {
        [Space]
        [Header("Level Items")]
        public GameObject playerSpawner;  // Holds the character
        public GameObject surferBoard; // SurferBoard and its count
        public int surferBoardCount; //Count of the Surfer Board
    }

    public List<SurferData> surferData;

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
                switch (LevelLoader[x][z].Trim())
                {
                    case "1":
                        Instantiate(spawnPoint, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Starting Point
                        //Instantiates the number of surfer required based on the count we give out at surferData in inspector.
                        // * *************HARDCODING ZERO BELOW IS WRONG. JUST DOING IT TO SEE IF ITS WORKING *******
                        break;                                   
                    case "2":                                    
                        Instantiate(rails, new Vector3(x, 1.95f, z), Quaternion.identity);  //Instantiates rails (Surfer Holders / Place for surfers to sit)
                        break;                                   
                    case "3":                                    
                        GameObject destinationRef = Instantiate(destination, new Vector3(x, -13f, z), Quaternion.identity); //Instantiates Destination
                        GameObject giftRef =  Instantiate(gift, new Vector3(x, 2f, z), Quaternion.identity); //Instantiates 
                        //giftRef.transform.SetParent(destinationRef.transform, false);
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
        string[] lines = Regex.Split(text, "\n");
        int rows = lines.Length;

        string[][] levelBase = new string[rows][];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] stringsOfLine = Regex.Split(lines[i], ",");
            levelBase[i] = stringsOfLine;
        }
        return levelBase;
    }
}


//void Residue()
//{
//    //Instantiates the number of surfer required based on the count we give out at surferData in inspector.
//    // ************** HARDCODING ZERO BELOW IS WRONG. JUST DOING IT TO SEE IF ITS WORKING *******
//    //float j = 0;
//    //for (int i = 0; i < surferData[0].surferBoardCount; i++ , j+= 0.3f)
//    //{
//    //    Instantiate(surferData[0].surferBoard, new Vector3(x, 2.3f + j, z), Quaternion.identity);
//    //    if (i > surferData[0].surferBoardCount) break;
//    //}
//}