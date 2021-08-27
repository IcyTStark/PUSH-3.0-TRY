using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AutoSurfer : MonoBehaviour
{
   private bool FindClosestTargetPoints(out TargetPoint targetPoint)
   {
       targetPoint = FindObjectsOfType<TargetPoint>().Where(t => !t.isFilled).OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).FirstOrDefault();
       Debug.Log(targetPoint);
       return targetPoint;
   }

    // Move speed in Unity unit / second
    public float speed = 0.5f;

    private void Start()
    {
        StartMove();
    }
    public void StartMove()
    {
        // First check if you can get a closest point
        if (!FindClosestTargetPoints(out var targetPoint))
        {
            Debug.LogWarning("Couldn't find a free target!", this);
            return;
        }

        // Got a closest point -> mark it occupied
        targetPoint.isFilled = true;

        // And start moving towards it
        StartCoroutine(MoveTo(targetPoint.transform.position));
    }

    // Example Coroutine
    // This will move with a linear speed towards the given target
    // Adjust according to your needs
    private IEnumerator MoveTo(Vector3 target)
    {
        // Move smooth until the position matches with a precision of 0.00001
        while (transform.position != target)
        {
            // Each frame move the object one step towards the target
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // "Pause" the Coroutine here, Redner this frame
        // and continue from here in the next frame
        yield return null;
        }

        // Just to be sure to end with clean values (due to the mentioned precision of 0.00001) set the target hard when done
        transform.position = target;
    }


}
