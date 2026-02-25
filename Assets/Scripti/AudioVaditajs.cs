using UnityEngine;

public class AudioVaditajs : MonoBehaviour
{
    [Header("Audio avoti")]
    [SerializeField] private AudioSource muzikasAvots;
    [SerializeField] private AudioSource sfxAvots;

    [Header("SFX")]
    [SerializeField] private AudioClip klikskis;
    [SerializeField] private AudioClip uzvilkts;
    [SerializeField] private AudioClip viriesaSkaņa;
    [SerializeField] private AudioClip sievietesSkaņa;

    private void Start()
    {
        // Ja mūzika nav palaista, palaižam
        if (muzikasAvots != null && !muzikasAvots.isPlaying && muzikasAvots.clip != null)
            muzikasAvots.Play();
    }

    public void SpeletKlikski()
    {
        Atskanot(klikskis);
    }

    public void SpeletUzvilkts()
    {
        Atskanot(uzvilkts);
    }

    public void SpeletTelaSkanu(bool irVirietis)
    {
        Atskanot(irVirietis ? viriesaSkaņa : sievietesSkaņa);
    }

    private void Atskanot(AudioClip klips)
    {
        if (sfxAvots != null && klips != null)
            sfxAvots.PlayOneShot(klips);
    }
}