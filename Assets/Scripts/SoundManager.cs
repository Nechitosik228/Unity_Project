using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource footstep_sound;
    [SerializeField] private AudioSource sound1;


    private void OnEnable()
    {
        MyInputManager.OnAttackPressed += PlayAudio;
        MyInputManager.OnMovePressed += CheckForMovement;
    }

    private void OnDisable()
    {
        MyInputManager.OnAttackPressed -= PlayAudio;
        MyInputManager.OnMovePressed -= CheckForMovement;
    }
    private void PlayAudio(bool isPressed)
    {
        if (!sound1.isPlaying)
        {
            sound1.Play();
            return;
        }
        // sound.Stop();
        // sound.PlayOneShot(sound.clip);
        if (sound1.isPlaying)
        {
            sound1.Stop();
            return;
        }

    }

    private void PlayFootStepAudio(bool isPlaying)
    {
        if (!footstep_sound.isPlaying && isPlaying)
        {
            footstep_sound.Play();
            return;
        }
        // sound.Stop();
        // sound.PlayOneShot(sound.clip);
        if (footstep_sound.isPlaying && !isPlaying)
        {
            footstep_sound.Stop();
            return;
        }

    }

    private void CheckForMovement(Vector2 input)
    {
        bool toPlay = input.sqrMagnitude >= 0.2f;
        PlayFootStepAudio(toPlay);
    }
}
