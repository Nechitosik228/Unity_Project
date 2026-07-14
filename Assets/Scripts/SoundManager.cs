using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource sound1;


    private void OnEnable()
    {
        MyInputManager.OnSpacePressed += PlayAudio;
    }

    private void OnDisable()
    {
        MyInputManager.OnSpacePressed -= PlayAudio;
    }
    private void PlayAudio()
    {
        if (!sound.isPlaying)
        {
            sound.Play();
            return;
        }
        // sound.Stop();
        // sound.PlayOneShot(sound.clip);
        if (sound.isPlaying)
        {
            sound.Stop();
            return;
        }

    }
}
