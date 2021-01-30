using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleOjects : MonoBehaviour
{
    public int iceCount = 0;
    public Text iceText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ice")
        {
            Debug.Log("Crash ice");
            iceCount++;
            iceText.text = iceCount.ToString();
        }
    }
}
