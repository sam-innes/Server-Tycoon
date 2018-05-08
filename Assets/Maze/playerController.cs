using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public float speed = 4f;
    public GameObject player;
    Rigidbody2D rb2d;
    public Text promptTxt;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.velocity = targetVelocity * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("workstation"))
        {
            promptTxt.text = "Press 'e' to log on";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("workstation"))
        {
            promptTxt.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("workstation") && Input.GetKeyDown("e")){
            player.SetActive(false);
            Debug.Log("Logged on");
        }
    }
}
