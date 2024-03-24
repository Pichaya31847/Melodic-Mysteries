using UnityEngine;

public class PlaySoundWhenClick : MonoBehaviour
{
    public static PlaySoundWhenClick instance;
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(int i)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClips[i]);
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    private void Awake()
    {
        instance = this;
    }
}
