using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip PuckCollision;
    public AudioClip GoalSound;
    AudioSource AudioSource;
    public AudioClip UISelectSound;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    public void PlayPuckCollision()
    {
        AudioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoalSound()
    {
        AudioSource.PlayOneShot(GoalSound);
    }

    public void PlayUINoise()
    {
        AudioSource.PlayOneShot(UISelectSound);
    }
}
