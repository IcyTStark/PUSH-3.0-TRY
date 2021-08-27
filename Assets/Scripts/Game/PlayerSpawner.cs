using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns player based on the character list updates everytime you buy a character from shop
public class PlayerSpawner : MonoBehaviour
{   
    [Space]
    [Header("Character Spawn Data")]
    public List<GameObject> character = new List<GameObject>(); //Character List
    public GameObject characterSpawnLocation;   //Where he should spawn
    public GameObject parent;   //Child of which surfer
    public float extraDistance; //Distance between characters leg and surfer head 

    //Cached Reference
    public GameObject GameManagerRef;

    void Start()
    {
        GameManagerRef = GameObject.Find("GameManager");
        character = GameManagerRef.GetComponent<GameManager>().character;
        
        this.gameObject.transform.rotation = parent.transform.rotation;     //Get parent GameObjects rotation
        Quaternion storeRotation = this.gameObject.transform.rotation;      //Assign its rotation to parent(i.e., surfers location) 
        
        //Instantiate characters based on characterlist length
        GameObject storeCharacter = Instantiate(character[Random.Range(0,character.Count)], characterSpawnLocation.transform.position + new Vector3(0f,extraDistance,0f), storeRotation);
        storeCharacter.transform.parent = parent.transform; //After instatiated attach it as a child to surfer
    }
}