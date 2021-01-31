using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleOjects : MonoBehaviour
{
    public int iceCount = 0;
    public Text iceText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Ice")
        {
            IceCream.instance.currentHealth += 2;
            IceCream.instance.healthBar.fillAmount = IceCream.instance.currentHealth / IceCream.instance.maxHealth;
            Debug.Log("Crash ice");
            iceCount++;
            iceText.text = iceCount.ToString();
        }
    }
}
