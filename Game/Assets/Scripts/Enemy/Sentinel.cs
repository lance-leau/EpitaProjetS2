using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    public float moveSpeed = 10;
    
    public Vector3 moveDir = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += moveDir * moveSpeed / 100;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 6) // layer 6 is enemy path
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
            moveDir *= -1;
        }
    }
}
