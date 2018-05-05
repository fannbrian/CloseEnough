using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Data structure to determine what action the player is trying to perform.
/// <para>
/// @Author: Brian Fann
/// @Updated: 5/4/18
/// </para>
/// </summary>
public class RoomAction : MonoBehaviour {
    public static RoomAction singleton;
    public bool isCreating;
    public string roomCode;

    public RoomAction()
    {
        singleton = this;
    }

    public void SetCreateRoom()
    {
        isCreating = true;
    }

    public void SetJoinRoom(Text roomCodeField) {
        isCreating = false;
        roomCode = roomCodeField.text;
    }
}
