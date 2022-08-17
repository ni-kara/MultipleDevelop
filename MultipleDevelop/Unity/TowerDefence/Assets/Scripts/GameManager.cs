using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject baseObj;
    [SerializeField] private Button tryAgainButton;

    private bool isGameEnded;

    private void Awake() =>
        instance = this;

    void Start()=>    
        tryAgainButton.onClick.AddListener(()=> SceneManager.LoadScene(0));    

    public void EndGame()
    {
        isGameEnded = true;
        tryAgainButton.gameObject.SetActive(true);
    }

    public bool IsGameEnded() => isGameEnded;
    public Vector2 GetBasePosition() =>
        baseObj.transform.position;
}
