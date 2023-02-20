using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;
    
    Rigidbody2D rb;

    public float forceAmount = 60f;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * forceAmount);
        }

        rb.velocity *= .999f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "pink")
        {
            spriteRenderer.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
            //spriteRenderer.color = new Color(234, 127, 128, 1);
        }

        if (col.gameObject.tag == "yellow")
        {
            spriteRenderer.color = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.time, 1));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "again")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level0");
        }
    }
}
