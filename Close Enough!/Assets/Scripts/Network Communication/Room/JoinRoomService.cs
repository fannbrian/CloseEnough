﻿using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
    public class JoinRoomService : MonoBehaviour
    {
        public static JoinRoomService singleton;
        public Text roomCodeText;

        public JoinRoomService()
        {
            singleton = this;
        }

        public void JoinRoom()
        {
            if (!PhotonNetwork.JoinRoom(roomCodeText.text)) {
                print("Join room failed.");
            }
        }
    }
}