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

public class PlayerDiedEvent
{
    public int player_id;

    public PlayerDiedEvent(int _player_id)
    {
        player_id = _player_id;
    }
}

public class PlayerAddEvent
{

}
