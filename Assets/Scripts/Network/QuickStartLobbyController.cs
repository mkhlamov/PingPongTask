using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject connectButton;
    [SerializeField] private GameObject quickStartButton;
    [SerializeField] private GameObject quickCancelButton;

    [SerializeField] private int roomSize = 2;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
        connectButton.SetActive(false);
    }
    
    private void Start()
    {
        if (!PhotonNetwork.IsConnectedAndReady) return;
        quickStartButton.SetActive(true);
        connectButton.SetActive(false);
    }

    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    
    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        var randomRoomNumber = Random.Range(0, 10000);
        var roomOptions = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte) roomSize};
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
}
