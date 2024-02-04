using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.SlayTheSpire
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance {private set; get;}

        private AudioSource BGMAudioSource;

        private void Awake() 
        {
            if(Instance != null)
            {
                Debug.LogError("More Than One AudioManager");
            }

            Instance = this;    
            BGMAudioSource = GetComponent<AudioSource>();    
        }

        private void Start() 
        {
        }

        public void PlayBGM(string _name, bool isLoop = true)
        {
            AudioClip _clip = Resources.Load<AudioClip>("Sounds/BGM/" + _name);

            BGMAudioSource.clip = _clip;
            BGMAudioSource.loop = isLoop;
            BGMAudioSource.Play();
        }

        public void PlaySFX(string _name)
        {
            AudioClip _clip = Resources.Load<AudioClip>("Sounds/Effect/" + _name);

            AudioSource.PlayClipAtPoint(_clip, transform.position);     
        }
    }
}
