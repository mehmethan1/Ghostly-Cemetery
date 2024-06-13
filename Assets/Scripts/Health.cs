using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int health = 10;
    public TMP_Text healthDisplay;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    public void TakeDamageRPC()
    {
        health--;
        healthDisplay.text = health.ToString();
    }

}
