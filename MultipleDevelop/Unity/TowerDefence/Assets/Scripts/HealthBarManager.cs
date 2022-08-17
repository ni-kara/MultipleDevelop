using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager instance;
 
    [SerializeField] private Slider sliderHealth;
    
    private int currentHealth;
    private Coroutine coroutine;

    private const int maxHealth = 100;
    private const int autoRecoveryValue = 5;
    private const int damageValue = 10;
    private const float autoRecoveryTime = 10f;

    private void Awake() =>
        instance = this;

    void Start()
    {
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
        currentHealth = maxHealth;

        UpdateHealthBar();

        coroutine = StartCoroutine(AutoRecovery());
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageValue;
            if (currentHealth < 0)
                currentHealth = 0;
        }
        else
            currentHealth = 0;

        if (currentHealth <= 0)
            GameManager.instance.EndGame();
        UpdateHealthBar();
    }
    private IEnumerator AutoRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoRecoveryTime);

            if (currentHealth <= 0 || currentHealth >= maxHealth)
                continue;

            if (GameManager.instance.IsGameEnded())
                StopCoroutine(coroutine);

            currentHealth += autoRecoveryValue;
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        sliderHealth.value = currentHealth;
        sliderHealth.handleRect.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentHealth.ToString();
    }
    
}
