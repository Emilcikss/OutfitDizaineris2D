using UnityEngine;

public class SfxAtskanotajs : MonoBehaviour
{
    public static SfxAtskanotajs Instance;

    [SerializeField] private AudioSource sfxAvots;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Atskanot(AudioClip klips, float skanums = 1f)
    {
        if (klips == null || sfxAvots == null) return;
        sfxAvots.PlayOneShot(klips, skanums);
    }
}