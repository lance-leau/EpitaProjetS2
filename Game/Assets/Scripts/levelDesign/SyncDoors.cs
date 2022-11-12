using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SyncDoors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform door in this.transform)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                GameObject obj = PhotonNetwork.Instantiate(door.name, door.position, Quaternion.identity);
                obj.transform.localScale = door.transform.localScale;
                obj.transform.rotation = door.transform.rotation;
                // obj.transform.parent = this.transform.parent;
            }

            Destroy(door.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
