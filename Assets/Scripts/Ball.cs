using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform padTransform;
    [SerializeField] private int health;
    [SerializeField] private Sprite[] sprites;

    private bool _isStarted;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        
        // Почему нельзя выключить РБ?
        // gameObject.GetComponent<Ball>().enabled = false;
        // gameObject.GetComponent<Rigidbody2D>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isStarted)
        {
            Vector3 padPosition = padTransform.position;
            padPosition.y = transform.position.y;

            transform.position = padPosition;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallStart();
        }
    }

    private void BallStart()
    {
        _rb.simulated = true;
        _rb.AddForce(Vector2.up * speed);
        _isStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            if (health <= sprites.Length && health > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[health - 1]; 
            }
        }
    }
}
