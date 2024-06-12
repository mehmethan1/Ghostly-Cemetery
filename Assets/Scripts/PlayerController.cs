using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    PhotonView view;
    LineRenderer rend;

    GunPoint[] GunPoints;

    void Start()
    {
        view = GetComponent<PhotonView>();
        rend = FindObjectOfType<LineRenderer>();
        GunPoints = FindObjectsOfType<GunPoint>();
    }

    private void Update()
    {

        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;

            Vector2 GunPointOne = GunPoints[0].transform.position;
            rend.SetPosition(0, GunPointOne);
        }
        else
        {
            Vector2 GunPointOne = GunPoints[0].transform.position;
            Vector2 GunPointTwo = GunPoints[1].transform.position;
            rend.SetPosition(0, GunPointOne);
            rend.SetPosition(1, GunPointTwo);
        }
    }

}
