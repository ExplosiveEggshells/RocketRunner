using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player MainPlayer { get; private set; }

    private void Awake()
    {
        InitializeSingleton();
        FindPlayer();
    }

    private void FindPlayer()
    {
        MainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (MainPlayer == null)
        {
            Debug.LogWarning("GameManager failed to find player.");
        }
    }

    private void InitializeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}
