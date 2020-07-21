using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Global
{
    public class SceneChange : MonoBehaviour
    {
        public Text[] tooltips = new Text[2];

        int scene = 1;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            SceneChanger(scene);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (scene > 1)
                    SceneChanger(--scene);
                else
                    SceneChanger(scene = 5);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                if (scene < 5)
                    SceneChanger(++scene);
                else
                    SceneChanger(scene = 1);
            }
        }

        void SceneChanger(int scene)
        {
            switch (scene)
            {
                case 1:
                    tooltips[0].text = "[Ｏ] 跳到最後一題";
                    tooltips[1].text = "\n[Ｐ] 跳到下一題";
                    break;
                case 5:
                    tooltips[0].text = "[Ｏ] 跳回上一題";
                    tooltips[1].text = "\n[Ｐ] 跳回第一題";
                    break;
                default:
                    tooltips[0].text = "[Ｏ] 跳回上一題";
                    tooltips[1].text = "\n[Ｐ] 跳到下一題";
                    break;
            }
            SceneManager.LoadScene("第" + scene + "題");
        }
    }
}
