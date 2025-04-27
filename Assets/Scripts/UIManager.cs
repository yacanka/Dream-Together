using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class UIManager : MonoBehaviour
{
    [Header("Screens")]
    public GameObject welcomeScreen;
    public GameObject lobbyScreen;

    [Header("Welcome Screen")]
    public Button createRoomButton;
    public Button joinRoomButton;
    public TMP_InputField playerNameInput;

    [Header("Lobby Screen")]
    public TMP_InputField roomNameInput;
    public Button confirmCreateRoomButton;
    public Button confirmJoinRoomButton;
    public Button backButton;
    public Transform roomListContent;
    public GameObject roomListItemPrefab;

    private void Start()
    {
        // Initially show welcome screen and hide lobby
        ShowWelcomeScreen();

        // Add button listeners
        createRoomButton.onClick.AddListener(() => {
            ShowLobbyScreen();
            confirmJoinRoomButton.gameObject.SetActive(false);
            confirmCreateRoomButton.gameObject.SetActive(true);
        });

        joinRoomButton.onClick.AddListener(() => {
            ShowLobbyScreen();
            confirmCreateRoomButton.gameObject.SetActive(false);
            confirmJoinRoomButton.gameObject.SetActive(true);
        });

        confirmCreateRoomButton.onClick.AddListener(() => {
            if (!string.IsNullOrEmpty(roomNameInput.text))
            {
                NetworkManager.Instance.CreateRoom(roomNameInput.text);
            }
        });

        confirmJoinRoomButton.onClick.AddListener(() => {
            if (!string.IsNullOrEmpty(roomNameInput.text))
            {
                NetworkManager.Instance.JoinRoom(roomNameInput.text);
            }
        });

        backButton.onClick.AddListener(ShowWelcomeScreen);

        // Set player name if provided
        if (!string.IsNullOrEmpty(playerNameInput.text))
        {
            PhotonNetwork.NickName = playerNameInput.text;
        }
    }

    private void ShowWelcomeScreen()
    {
        welcomeScreen.SetActive(true);
        lobbyScreen.SetActive(false);
    }

    private void ShowLobbyScreen()
    {
        welcomeScreen.SetActive(false);
        lobbyScreen.SetActive(true);
    }
} 