using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitFalling : MonoBehaviour
{
    public float speed = 10f;
    float rand;
    public float minX, maxX;

    public Camera main;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < main.transform.position.y - 5)
        {
            rand = Random.Range(minX, maxX);
            transform.position = new Vector3(rand, main.transform.position.y + 6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            IceCream.instance.GetDamage(3);
            rand = Random.Range(minX, maxX);
            transform.position = new Vector3(rand, main.transform.position.y + 6, 0);
        }
        gameObject.transform.parent.GetComponent<FruitsController>().OnTriggerEnter2DChild(other);
    }
}
