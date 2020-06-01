using UnityEngine;
using Photon.Pun;

namespace PingPongTask.Network
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        public void ConnectToPhoton()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to the " + PhotonNetwork.CloudRegion + " server");
        }
    }
}