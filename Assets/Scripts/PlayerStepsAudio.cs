using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerStepsAudio : MonoBehaviour
{
    [SerializeField] private float pitchRandomness = .05f;
    [SerializeField] private AudioClip stepClip;
    private float basePitch;
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    private void PlayAudioClipWithPitch(AudioClip audioClip)
    {
        if (stepClip != null)
        {
            float randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
            audioSource.pitch = basePitch + randomPitch;
            PlayAudioClip(audioClip);
        }
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayStepSound()
    {
        PlayAudioClipWithPitch(stepClip);
    }
}
