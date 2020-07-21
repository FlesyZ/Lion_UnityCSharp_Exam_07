using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class SceneChange : MonoBehaviour
    {
        int scene = 1;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            SceneManager.LoadScene(1);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (scene > 1)
                    SceneManager.LoadScene("第" + --scene + "題");
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                if (scene < 5)
                    SceneManager.LoadScene("第" + ++scene + "題");
            }
        }
    }
}
