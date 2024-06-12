using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    PhotonView view;
    static Gun player1Gun;
    static Gun player2Gun;

    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            if (player1Gun == null)
            {
                player1Gun = this;
            }
            else
            {
                player2Gun = this;
            }
        }
    }

    void Update()
    {
            if (view.IsMine)
            {
                LookAtOtherGun();
            }
        
    }

    void LookAtOtherGun()
    {
        Debug.Log("silahlar bakışıyor");
        // Diğer oyuncunun silahını bul
        Gun otherGun = (this == player1Gun) ? player2Gun : player1Gun;

        if (otherGun != null)
        {
            Vector3 direction = otherGun.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}