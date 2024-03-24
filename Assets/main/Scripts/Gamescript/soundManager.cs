using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioClip[] soundEffect;
    private static AudioSource audioSource;
    public static AudioClip[] audioClips;

    private void Start()
    {
        audioClips = soundEffect;
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(int sound)
    {
        if (audioClips.Length > sound && audioClips[sound] != null)
        {
            audioSource.PlayOneShot(audioClips[sound]);
        }
        else
        {
            Debug.LogError("Audio clip not found or null.");
        }
    }
}
