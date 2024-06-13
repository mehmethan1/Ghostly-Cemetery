using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    private PhotonView view;
    private bool gunFound = false;

    void Start()
    {
        view = GetComponent<PhotonView>();

        // Eğer bu silah, oyuncunun yerel sahibi ise, diğer silahı bul ve ona bak
    }

    private void Update()
    {
        if (view.IsMine)
        {
            FindAndLookAtOtherGun();
        }
    }

    void FindAndLookAtOtherGun()
    {
        // Diğer tüm silahları bul
        Gun[] allGuns = FindObjectsOfType<Gun>();

        foreach (Gun gun in allGuns)
        {
            // Kendi silahımızı zaten bulduk, o yüzden atlamalıyız
            if (gun != this)
            {
                // Diğer silahı bulduk
                gunFound = true;

                // Diğer silaha bak
                Vector3 direction = gun.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                break;
            }
        }
    }
}