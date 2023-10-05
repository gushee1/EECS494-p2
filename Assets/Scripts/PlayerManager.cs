using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player[] players = null;

    int current_player = 0;

    // Start is called before the first frame update
    void Start()
    {
        players = GetComponentsInChildren<Player>();

        //for (int i = 0; i < players.Length; i++) Debug.Log(players[i].gameObject.name);

        players[current_player].ActivateSelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlayer()
    {
        Debug.Log("switching");
        players[current_player].DeactivateSelf();
        current_player++;
        current_player %= players.Length;
        players[current_player].ActivateSelf();
        Debug.Log(players[current_player].gameObject.name);
    }
}
