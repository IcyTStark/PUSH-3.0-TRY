using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

//Level Generator
public class LevelGenerator : MonoBehaviour
{
    //config parameters // 1 - StartingPoint, 2 - Rails, 3 - Destination
    [Space]
    [Header("1-Surfers_StartingPoint")]
    [SerializeField] GameObject AW;
    [SerializeField] GameObject AS;
    [SerializeField] GameObject AE;
    [SerializeField] GameObject AN;
    [Space]
    [Header("2-Surfers_StartingPoint")]
    [SerializeField] GameObject BW;
    [SerializeField] GameObject BS;
    [SerializeField] GameObject BE;
    [SerializeField] GameObject BN;
    [Space]
    [Header("3-Surfers_StartingPoint")]
    [SerializeField] GameObject CW;
    [SerializeField] GameObject CS;
    [SerializeField] GameObject CE;
    [SerializeField] GameObject CN;
    [Space]
    [Header("4-Surfers_StartingPoint")]
    [SerializeField] GameObject DW;
    [SerializeField] GameObject DS;
    [SerializeField] GameObject DE;
    [SerializeField] GameObject DN;
    [Space]
    [Header("5-Surfers_StartingPoint")]
    [SerializeField] GameObject EW;
    [SerializeField] GameObject ES;
    [SerializeField] GameObject EE;
    [SerializeField] GameObject EN;

    [Space]
    [Header("Rails & Destination")]
    [SerializeField] GameObject Rails;
    [SerializeField] GameObject Destination;

    [Space]
    [Header ("Level Details:")]
    [SerializeField] string LevelName;

    void Start()
    {
        LevelName = SceneManager.GetActiveScene().name.ToString();
        TextAsset LevelLoader = Resources.Load(LevelName)as TextAsset; //Using Resources to Load Level Files 
        string text = LevelLoader.text;
        string[] line = Regex.Split(text,"\n");     //Splits Line by Line
        int row = line.Length;                      //Store as row and pass on to levelbase
        string[][] levelbase = new string[row][];

        //Takes the row data(line & splits the strings in it one by one by using the string delimiter ',')
        for (int i = 0; i < row; i++)              
        {
            string[] stringLine = Regex.Split(line[i], ","); 
            levelbase[i] = stringLine;
        }
        //Spawn GameObjects Depending upon the number inside the excel sheet
        for (int x = 0; x < levelbase.Length; x++)
        {
            for (int z = 0; z < levelbase[0].Length; z++)
            {
                switch (levelbase[x][z].Trim())
                {
                    case "AN":
                        Instantiate(AN, new Vector3(x, -13f, z), AN.transform.rotation);
                        break;                                   
                    case "AS":                                   
                        Instantiate(AS, new Vector3(x, -13f, z), AS.transform.rotation);
                        break;                                   
                    case "AW":                                   
                        Instantiate(AW, new Vector3(x, -13f, z), AW.transform.rotation);
                        break;                                  
                    case "AE":                                  
                        Instantiate(AE, new Vector3(x, -13f, z), AE.transform.rotation);
                        break;                                  
                    case "BN":                                  
                        Instantiate(BN, new Vector3(x, -13f, z), BN.transform.rotation);
                        break;                                  
                    case "BS":                                  
                        Instantiate(BS, new Vector3(x, -13f, z), BS.transform.rotation);
                        break;                                   
                    case "BW":                                   
                        Instantiate(BW, new Vector3(x, -13f, z), BW.transform.rotation);
                        break;                                  
                    case "BE":                                  
                        Instantiate(BE, new Vector3(x, -13f, z), BE.transform.rotation);
                        break;                                  
                    case "CN":                                   
                        Instantiate(CN, new Vector3(x, -13f, z), CN.transform.rotation);
                        break;                                   
                    case "CS":                                   
                        Instantiate(CS, new Vector3(x, -13f, z), CS.transform.rotation);
                        break;                                   
                    case "CW":                                   
                        Instantiate(CW, new Vector3(x, -13f, z), CW.transform.rotation);
                        break;                                   
                    case "CE":                                   
                        Instantiate(CE, new Vector3(x, -13f, z), CE.transform.rotation);
                        break;                                   
                    case "DN":                                  
                        Instantiate(DN, new Vector3(x, -13f, z), DN.transform.rotation);
                        break;                                 
                    case "DS":                                  
                        Instantiate(DS, new Vector3(x, -13f, z), DS.transform.rotation);
                        break;                                  
                    case "DW":                                  
                        Instantiate(DW, new Vector3(x, -13f, z), DW.transform.rotation);
                        break;                                   
                    case "DE":                                  
                        Instantiate(DE, new Vector3(x, -13f, z), DE.transform.rotation);
                        break;                                   
                    case "EN":                                   
                        Instantiate(EN, new Vector3(x, -13f, z), EN.transform.rotation);
                        break;                                   
                    case "ES":                                   
                        Instantiate(ES, new Vector3(x, -13f, z), ES.transform.rotation);
                        break;                                   
                    case "EW":                                   
                        Instantiate(EW, new Vector3(x, -13f, z), EW.transform.rotation);
                        break;                                  
                    case "EE":                                   
                        Instantiate(EE, new Vector3(x, -13f, z), EE.transform.rotation);
                        break;
                    case "2":
                        Instantiate(Rails, new Vector3(x, 1.95f, z), Quaternion.identity);
                        break;
                    case "3":
                        Instantiate(Destination, new Vector3(x, -13.15f, z), Quaternion.identity);
                        break;
                }
            }
        }
    }
}