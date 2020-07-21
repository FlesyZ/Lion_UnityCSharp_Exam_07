using UnityEngine;
using UnityEngine.UI;

namespace Q4
{
    public class GameManager : MonoBehaviour
    {
        SoundManager sound;

        public Image success;
        public Text text;
        
        public void Finish()
        {
            sound.musics[0].Stop();
            sound.musics[1].Play();
            success.canvasRenderer.SetAlpha(1f);
            text.text = "到了!!!!!!!!!";
        }

        void Awake()
        {
            sound = GetComponent<SoundManager>();

            success.canvasRenderer.SetAlpha(0f);
        }
    }
}
