using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KillPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 7) // 7 is the enemey layer
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
