using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    float resetSpeed;
    public float dashSpeed = 13;
    public float dashTime = 0.1f;
    public float minX, maxX, minY, maxY;


    PhotonView view;
    LineRenderer rend;
    Animator anim;
    GunPoint[] GunPoints;
    Health healthScript;

    void Start()
    {
        resetSpeed = speed;
        view = GetComponent<PhotonView>();
        rend = FindObjectOfType<LineRenderer>();
        GunPoints = FindObjectsOfType<GunPoint>();
        anim = GetComponent<Animator>();
        healthScript = FindObjectOfType<Health>();
    }

    private void Update()
    {

        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;

            Wrap();

            if(moveInput == Vector2.zero)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }

            if(Input.GetKeyDown(KeyCode.Space) && moveInput != Vector2.zero)
            {
                StartCoroutine(Dash());
            }

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
    IEnumerator Dash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        speed = resetSpeed;
    }

    void Wrap()
    {
        if(transform.position.x < minX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(-maxX, transform.position.y);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (view.IsMine)
        {
            if (collision.tag == "Enemy")
            {
                Debug.Log("can azalıyor");
                healthScript.TakeDamage();
            }
        }
    }
}
