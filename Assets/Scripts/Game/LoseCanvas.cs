using System.Collections;
using UnityEngine;

//Activating the Lose Canvas when player falls on water
public class LoseCanvas : MonoBehaviour
{
    //Config Parameters
    public GameObject LoseMenuUI;
    public GameObject LoseParticle;

    //Cached Reference
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        //Storing All Gameobject variable at Run-Time
        GameObject storeLoseCanvas = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        LoseMenuUI = storeLoseCanvas;
        LoseParticle = Resources.Load("Droplet") as GameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 storeLocation = other.gameObject.transform.position;
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine(LoseParticlePlayAndLoseScreen(storeLocation));
        }
    }
    IEnumerator LoseParticlePlayAndLoseScreen(Vector3 particleSpawnPosition)
    {
        GameObject particleSpawned = Instantiate(LoseParticle, particleSpawnPosition,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(particleSpawned);
        LoseMenuUI.SetActive(true);
    }
}