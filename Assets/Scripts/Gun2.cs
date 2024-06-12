using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun2 : MonoBehaviour
{
    Gun2[] Guns;

    private void Start()
    {
        Guns = FindObjectsOfType<Gun2>();
    }


    void Update()
    {
        Vector2 lookDir = Guns[0].transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (angle > -180 && angle < -90)
        {
            this.transform.localScale = new Vector2(1f, -1f);
        }
        else if (angle > 90 && angle < 180)
        {
            this.transform.localScale = new Vector2(1f, -1f);
        }
        else
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }
    }
}