using System;
using Photon;
namespace CloseEnough
{
    /// <summary>
    /// Networked room creation handler
    /// 
    /// <para>
    /// @Author: Alex Berthon, Brian Fann
    /// @Updated: 5/4/18
    /// </para>
    /// </summary>
    public class CreateRoomService : PunBehaviour
    {
        public static CreateRoomService singleton;
        public ConnectFailListener connectFailListener;

        public CreateRoomService()
        {
            singleton = this;
        }

        const int ASCII_OFFSET = 65;
        const int ALPHABET_COUNT = 26;

        string GenerateRoomCode() 
        {
            var rand = new Random();
            var code = new int[] {
                rand.Next(ALPHABET_COUNT),
                rand.Next(ALPHABET_COUNT),
                rand.Next(ALPHABET_COUNT),
                rand.Next(ALPHABET_COUNT),
            };
            var roomCode = "";

            foreach(var num in code) {
                roomCode += (char)(num + ASCII_OFFSET);
            }

            return roomCode;
        }

        public void CreateRoom()
        {
            var settings = new RoomOptions()
            {
                MaxPlayers = 10,
                IsVisible = false
            };

            if (PhotonNetwork.CreateRoom(GenerateRoomCode(), settings, new TypedLobby()))
            {
                print("create room successfully sent.");
            }
            else
            {
                print("create room failed to send.");
                connectFailListener.OnCreateFail();
            }
        }

        public override void OnPhotonCreateRoomFailed(object[] codeAndMsg)
        {
            print("Create room failed: " + codeAndMsg[1]);
        }

        public override void OnCreatedRoom()
        {
            print("Room created successfully. TESTING randomized roomname = " + PhotonNetwork.room.Name);
        }
    }
}