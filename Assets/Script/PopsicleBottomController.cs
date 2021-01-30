using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsicleBottomController : MonoBehaviour
{
    [SerializeField]
    private PopsicleController parentController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        parentController.OnTriggerEnter2DChild(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        parentController.OnTriggerExit2DChild(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        parentController.OnTriggerStay2DChild(other);
    }
}
