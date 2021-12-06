using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public int scoreInstance;

    public enum Rewards {AlienCoin};

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            scoreInstance = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayerController.onDeath += OnDeathHandler;
    }

    private void OnDeathHandler()
    {
        SceneManager.LoadScene("OnDeathScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        instance.scoreInstance +=1;
    }
    public int GetScore()
    {
        return instance.scoreInstance;
    }
}
