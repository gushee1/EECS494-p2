using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishedEvent
{
    public int num_player_finished;

    public PlayerFinishedEvent(int _num_player_finished) 
    {
        num_player_finished = _num_player_finished;
    }
}
