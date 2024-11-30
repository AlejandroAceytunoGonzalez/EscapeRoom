using System.Collections.Generic;
using UnityEngine;
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> musicTracks;
    public bool active = true;
    private int currentTrackIndex = 0;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
        }
        if (active && musicTracks.Count > 0)
        {
            PlayCurrentTrack();
        }
    }

    private void Update()
    {
        if (active)
        {
            if (!audioSource.isPlaying && musicTracks.Count > 0)
            {
                PlayCurrentTrack();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    private void PlayCurrentTrack()
    {
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();
    }
    public void SelectTrack(int index)
    {
        if (index >= 0 && index < musicTracks.Count)
        {
            if (currentTrackIndex != index)
            {
                currentTrackIndex = index;
                if (active)
                {
                    PlayCurrentTrack();
                }
            }
        }
    }
}