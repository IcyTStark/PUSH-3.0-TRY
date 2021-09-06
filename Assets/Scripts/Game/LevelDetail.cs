using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDetail : MonoBehaviour
{
    public int index;
    public Vector3 position;
    public GameObject gb;
    public bool surferPlaced;

    string LevelName;

    string[] rowData;

    void Start()
    {
        LevelName = SceneManager.GetActiveScene().name.ToString();
        string[][] LevelLoader = readFile(LevelName);
    }

    string[][] readFile(string fileName)
    {
        TextAsset LoadedtextFile = Resources.Load(fileName) as TextAsset;
        string text = LoadedtextFile.text;
        string[] lines = Regex.Split(text, "\r\n");
        //rowData.Add(lines);
        int rows = lines.Length - 1;
        for (int i = 0; i < lines.Length; i++)
        {
            rowData[i] = lines[i].ToString();
            Debug.Log(rowData[0]);
        }

        string[][] levelBase = new string[rows][];
        for (int i = 0; i < rows; i++)
        {
            string[] stringsOfLine = Regex.Split(lines[i], ",");
            levelBase[i] = stringsOfLine;
        }
        return levelBase;
    }
}
