using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;
    public int maxSpeed = 15;

    private float currSpeed = 0;
    private Vector3 moveDir = new Vector3(1, 0, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (moveDir * currSpeed / 100);
        
        if (transform.position.x < target.position.x)
            currSpeed = Mathf.Lerp(currSpeed, maxSpeed, Time.deltaTime);
         
        else
            currSpeed = Mathf.Lerp(currSpeed, -maxSpeed, Time.deltaTime);

        if (currSpeed > 0) transform.rotation = Quaternion.Euler(0, 90, 0);
        else transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
