using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PingPongTask.SceneControllers
{
    public class SceneLoaderNetwork : MonoBehaviourPunCallbacks
    {
        [SerializeField] private string _mainSceneName;

        public void LoadMainMenu()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene(_mainSceneName);
        }
    }
}