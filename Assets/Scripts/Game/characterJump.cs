using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterJump : MonoBehaviour
{
    //config params
    Animator animator;
    public bool _Jump = false;
    public bool neverDone = true;
    public bool _IsCharInLastTile = false;

    //Cached reference
    GameObject parentRef;
    //Initially keep jump & everything false
    private void Start()
    {
        _Jump = false;
        neverDone = true;
        animator = GetComponent<Animator>();

        parentRef = this.gameObject.transform.parent.gameObject;
    }
    private void Update()
    {
        //if (neverDone)
        //{
        //    if (parentRef.GetComponent<PathToTravel>().transform.position == parentRef.GetComponent<PathToTravel>().targetPosition)
        //    {
        //        _IsCharInLastTile = true;
        //    }
        //}

        //if (_IsCharInLastTile && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        //{
        //    _Jump = true;
        //}

        //if (_Jump == true)
        //{
        //    animator.SetBool("shouldJump?", true); //Bool for your animation to play if u have a idle with you.
        //}
        //if (animator.GetBool("shouldJump?") == true && _Jump == true)
        //{
        //    transform.Translate(Vector3.forward * Time.deltaTime);
        //}
    }
}