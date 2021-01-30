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
        if (Input.GetMouseButtonDown(0))
        {
            currentHealth -= 5;
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        if (pos <= 100)
        {
            degree = 100;
            GetDamage(20);
        }

        if (pos > 100 && pos <= 300)
        {
            degree = 70;
            GetDamage(15);
        }

        if (pos > 300 && pos <= 500)
        {
            degree = 40;
            GetDamage(10);
        }

        if (pos > 500 && pos <= 700)
        {
            degree = 10;
            GetDamage(5);
        }

        if (pos > 700 && pos <= 1000)
        {
            degree = -20;
            currentHealth += 20;
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
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.2f);
        //SceneManager.LoadScene("GameOver");
    }
}
