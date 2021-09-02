using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//For touch Controls
public class TouchScript : MonoBehaviour
{
    public bool canClick = true;
    void Update()
    {
        if (canClick == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                canClick = false;
                Invoke(nameof(CanClickAgain), 1f); //Time Between Each clicks

                if(EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                RaycastHit hitSpot;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //See where the player clicks
                
                if (Physics.Raycast(ray, out hitSpot))
                {
                    if (hitSpot.collider.gameObject.tag == "Surfers") //If its a gameOBject names surfer move it to its targetPosition
                    {
                        //hitSpot.transform.gameObject.GetComponent<FindYourWay>().move = true;
                        //var storeLenght = hitSpot.transform.gameObject.transform.childCount - 1f;
                        //for (int i = 0; i <= storeLenght; i++)
                        //{
                        //    if (hitSpot.transform.gameObject.transform.GetChild(i).GetComponent<PathToTravel>() != null)
                        //    {
                        //        hitSpot.transform.gameObject.transform.GetChild(i).GetComponent<PathToTravel>().move = true;
                        //    }
                        //}
                        //Destroy(hitSpot.collider);
                    }
                }


            }
        }

    }
    public void CanClickAgain() //Makes bool CanClickAgian to true
    {
        canClick = true;
    }
}