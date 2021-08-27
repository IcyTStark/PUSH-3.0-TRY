using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Check if the player has reach destination to check for win condition and does what the player reaching it has to do accordingly
public class DestinationReached : MonoBehaviour
{
    //config Parameters
    public bool destinationReached = false;
    public bool makeIsPlayerInLastTileTrue;
    GameObject giftRef;
    AudioSource giftAudio;
    private void Start()
    {
        destinationReached = false;     //Setting destination reached as default to false
        giftRef = this.gameObject.transform.GetChild(1).gameObject;
        giftAudio = giftRef.GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")    //Check to see the other collider touching has a tag "Player"
        {
            destinationReached = true;  //Make destinationreached to true which helps out in wincondition

            GameObject storePlayer = other.gameObject;
            characterJump storePlayerScript = storePlayer.GetComponent<characterJump>();   //Store character's Jump script

            //Play the gift child to it animation(Opening gift)
            giftRef.GetComponent<Animator>().SetTrigger("OpenGift!");
            Invoke("InvokeGiftBlast", 0.75f);

            ////Set jump to false as character has to stop jumping when reached here
            storePlayer.GetComponent<Animator>().SetBool("shouldJump?", false);
            storePlayerScript.neverDone = false;
            storePlayerScript._IsCharInLastTile = false;
            storePlayerScript._Jump = false;

            ////Make the player dance to celebration
            storePlayer.GetComponent<Animator>().SetBool("shouldDance?", true);
        }
    }

    void InvokeGiftBlast()
    {
        giftAudio.PlayOneShot(giftAudio.clip);
    }

}
