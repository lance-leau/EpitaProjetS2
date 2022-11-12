using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargeted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.gameObject.GetComponent<FollowPlayer>().players.Add(this.gameObject);
    }
}
