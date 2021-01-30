using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitFalling : MonoBehaviour
{
    public float speed = 10f;
    public Transform player;
    float rand;
    public float minX, minY;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < player.position.y) 
        {
            rand = Random.Range(minX, minY);
            transform.position = new Vector3(rand, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //health decrease;
            Debug.Log("Fruit crash player");
            rand = Random.Range(minX, minY);
            transform.position = new Vector3(rand, transform.position.y, transform.position.z);
        }
    }
}
