using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public float minX, minY, maxX, maxY;

    private void Start()
    {
       SpawnPlayer();    
    }

    private void SpawnPlayer()
    {
        // Oyuncu sayısına göre prefab seçimi
        GameObject playerPrefab = (PhotonNetwork.LocalPlayer.ActorNumber == 1) ? player1Prefab : player2Prefab;

        // Spawnda pozisyon belirlenmesi (örnek olarak rastgele pozisyonlar)
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

        Quaternion spawnRotation = Quaternion.identity;

        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, spawnRotation);
    }
   
}