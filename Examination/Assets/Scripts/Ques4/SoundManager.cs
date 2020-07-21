using UnityEngine;

namespace Q4
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource[] musics { get; private set; }
        
        void Awake()
        {
            musics = GetComponents<AudioSource>();
        }
    }
}
