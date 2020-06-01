using UnityEngine;
using UnityEngine.SceneManagement;

namespace PingPongTask.SceneControllers
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}