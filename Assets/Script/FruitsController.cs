using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void OnTriggerEnter2DChild(Collider2D other)
    {
        
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("play fruit/pizza hit sfx");
            GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().FruitHit();
        }
    }
    
    public void OnTriggerExit2DChild(Collider2D other)
    {
    }
    
    public void OnTriggerStay2DChild(Collider2D other)
    {
        
    }
}
