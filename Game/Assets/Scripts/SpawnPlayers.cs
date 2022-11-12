using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject Enemy01;

    //Values where to spawn
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] Transform enemySpawnPos;
    
    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPos.position, Quaternion.identity);

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Enemy01.name, enemySpawnPos.position, Quaternion.Euler(0, 90, 0));
        }
    }
}
