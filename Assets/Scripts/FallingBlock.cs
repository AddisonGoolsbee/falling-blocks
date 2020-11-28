using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float minSize = 0.6f, maxSize = 2;
    private float screenHeight;
    public Vector2 speedMinMax;
    private float speed;

    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.getDifficulty());
        screenHeight = Camera.main.orthographicSize;
        transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), 1);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.Self);

        if (transform.position.y <= -screenHeight)
        {
            Destroy(gameObject);
        }
    }
}
