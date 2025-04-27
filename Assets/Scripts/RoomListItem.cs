using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomNameText;
    [SerializeField] private TMP_Text playerCountText;
    private string roomName;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        roomName = roomInfo.Name;
        roomNameText.text = roomInfo.Name;
        playerCountText.text = $"{roomInfo.PlayerCount}/{roomInfo.MaxPlayers}";
    }

    public void OnJoinRoomButtonClicked()
    {
        NetworkManager.Instance.JoinRoom(roomName);
    }
} 