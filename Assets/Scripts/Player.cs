using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;
    private float halfPlayerWidth, screenWidth, halfScreen;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        halfPlayerWidth = transform.localScale.x / 2;
        halfScreen = screenWidth + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

        
    }

    void playerMovement()
    {
        Vector2 movement = Vector2.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.Translate(movement);
        if (transform.position.x > halfScreen)
        {
            transform.Translate(new Vector2(-halfScreen * 2, 0));
        }
        else if (transform.position.x < -halfScreen)
        {
            transform.Translate(new Vector2(halfScreen * 2, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
}
