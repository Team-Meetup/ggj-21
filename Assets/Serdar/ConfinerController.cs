using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConfinerController : MonoBehaviour
{
    [FormerlySerializedAs("_popsicle")] [SerializeField]
    private GameObject popsicle;

    private bool _isAligned;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = popsicle.transform.position;
        _isAligned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(popsicle.GetComponent<PopsicleController>().isJumping);

        if (transform.position.y > popsicle.transform.position.y || Mathf.Equals(transform.position.y, popsicle.transform.position.y))
            _isAligned = true;
        else
            _isAligned = false;

        if(popsicle.GetComponent<PopsicleController>().isJumping && !_isAligned)
        {
            transform.position = new Vector2(transform.position.x, popsicle.transform.position.y);
        }
        
        
    }
}
