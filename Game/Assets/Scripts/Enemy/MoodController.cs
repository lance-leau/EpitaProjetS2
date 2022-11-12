using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodController : MonoBehaviour
{
    [Header("enemy veiw")]
    public Vector3 direction1;
    public float distance1;
    public Vector3 direction2;
    public float distance2;

    public bool seePlayer;

    private float orientation; // 1 for to the right, -1 for to the left

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        orientation = - transform.rotation.y / 0.707f;

        seePlayer = Physics.Raycast(transform.position, direction1 * orientation, distance1, 8)
                 || Physics.Raycast(transform.position, direction2 * orientation, distance2, 8);

        Debug.DrawRay(transform.position, direction1 * orientation, Color.red, Time.deltaTime);
        Debug.DrawRay(transform.position, direction2 * orientation, Color.red, Time.deltaTime);
    }
}
