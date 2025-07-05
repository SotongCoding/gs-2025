using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [SerializeField] private List<AudioClip> _musicClips;
        [SerializeField] private List<AudioClip> _sfxClips;
        [SerializeField] private AudioClip _pickSeedSfx;

        private void Start()
        {
            PlayMusic(1);
        }
        public void PlayMusic(int index)
        {
            _musicSource.clip = _musicClips[index];
            _musicSource.loop = true;
            _musicSource.Play();
        }

        public void PlaySFX(int index)
        {
            _sfxSource.PlayOneShot(_sfxClips[index]);
        }

        public void StopMusic()
        {
            _musicSource.Stop();
        }

        public void PlayPickSeedSfx(bool toggle)
        {
            if (toggle)
            {
                _sfxSource.PlayOneShot(_pickSeedSfx);
            }
        }
    }
}
