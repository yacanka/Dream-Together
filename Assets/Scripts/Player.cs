using UnityEngine;
using Photon.Pun;
using TMPro;

public class Player : MonoBehaviourPunCallbacks
{
    public TMP_Text playerNameText;
    private PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            // Initialize local player
            SetPlayerName();
        }
    }

    void SetPlayerName()
    {
        if (playerNameText != null)
        {
            playerNameText.text = PhotonNetwork.NickName;
        }
    }
} 