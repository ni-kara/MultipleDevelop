using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField] private TextMeshProUGUI killedEnemiesText;

    private int killedEnemiesValue;
    
    private void Awake() =>
        instance = this;
    
    public void KillEnemy()
    {
        killedEnemiesValue++;
        ShowKilledEnemiesText();
    }
    
    private void ShowKilledEnemiesText() =>
        killedEnemiesText.text = $"Killed enemies: {killedEnemiesValue}";
}
