using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Player[] players = null;
    private bool[] valid_players = null;

    static int current_player = 0;

    //Singleton pattern
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        players = GetComponentsInChildren<Player>();

        valid_players = new bool[players.Length];
        for (int i = 0; i < valid_players.Length; i++) valid_players[i] = true;

        //for (int i = 0; i < players.Length; i++) Debug.Log(players[i].gameObject.name);

        players[current_player].ActivateSelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlayer()
    {
        //Debug.Log("switching");
        players[current_player].DeactivateSelf();
        IncrementPlayer();
        players[current_player].ActivateSelf();
        //Debug.Log(players[current_player].gameObject.name);
    }

    public void PlayerCompletedLevel()
    {
        valid_players[current_player] = false;
        if (!valid_players.Contains(true))
        {
            Debug.Log("you finished the level!");
            //play victory theme
            //Reroute to scene manager level select.
            SceneManager.LoadScene("Level_Select");
        }
        Destroy(players[current_player].gameObject);
        IncrementPlayer();
        players[current_player].ActivateSelf();
    }

    private void IncrementPlayer()
    {
        int counter = 0;

        current_player++;
        current_player %= players.Length;
        while (!valid_players[current_player])
        {
            counter++;
            //getting stalled here
            current_player++;
            current_player %= players.Length;

            if(counter > 100)
            {
                Debug.Log("something is afoot");
                break;
            }
        }
    }

    public static int GetCurrentPlayer()
    {
        return current_player;
    }
}
