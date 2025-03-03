using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        if (_audioSource.clip != null)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}