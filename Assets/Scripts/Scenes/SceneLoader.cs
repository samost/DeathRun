using UnityEngine;
using UnityEngine.SceneManagement;


namespace DefaultNamespace.Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private bool isPreLoader;
        
        private void Start()
        {
            if (isPreLoader)
            {
                int lastSceneNumber = GetLastSceneNumber();
                if (lastSceneNumber == 0)
                {
                    LoadScene(1);    
                }
                else
                {
                    LoadScene(lastSceneNumber);    
                }
                
            }
            else
            {
                SetLastSceneNumber();
            }
        }

        public void LoadScene(int sceneNumber)
        {
            SceneManager.LoadSceneAsync(sceneNumber);
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void ReLoadScene()
        {
            int lastSceneNumber = GetLastSceneNumber();
            SceneManager.LoadSceneAsync(lastSceneNumber);
        }

        private void SetLastSceneNumber()
        {
            int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("last scene", currentSceneNumber);
        }

        private int GetLastSceneNumber()
        {
            return PlayerPrefs.GetInt("last scene");
        }
    }
}