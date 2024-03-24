using UnityEngine;
using UnityEngine.UI;

public class ButtonMusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;
    public Button button;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button.onClick.AddListener(PlayMusic);
    }

    private void PlayMusic()
    {
        audioSource.Stop();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = musicClip;

        audioSource.Play();
    }
    private void OnDisable()
    {
        gameManagerCT5.instance.PlayMusic();
        audioSource.Stop();
    }
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        gameManagerCT5.instance.PauseMusic();
        audioSource.Stop();
    }
}
