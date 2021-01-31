using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCream : MonoBehaviour
{
    public Image healthBar;

    public Transform player;

    public int degree;
    public float pos;

    public float maxHealth = 100;
    public float currentHealth;

    public static IceCream instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = player.position.y;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (pos <= 100)
        {
            degree = 100;
            GetDamage(0.01f);
        }

        if (pos > 100 && pos <= 300)
        {
            degree = 70;
            GetDamage(0.1f);
        }

        if (pos > 300 && pos <= 500)
        {
            degree = 40;
            GetDamage(0.05f);
        }

        if (pos > 500 && pos <= 700)
        {
            degree = 10;
            GetDamage(0.03f);
        }

        if (pos > 700 && pos <= 1000)
        {
            degree = -20;
            currentHealth += 5;
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    public void GetDamage(float amount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= amount;
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthBar.fillAmount = currentHealth;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("GameOver");
        Time.timeScale = 0;
        //SceneManager.LoadScene("GameOver");
    }
}
