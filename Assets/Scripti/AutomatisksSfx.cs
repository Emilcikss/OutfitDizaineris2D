using UnityEngine;
using UnityEngine.EventSystems;

public class AutomatisksSfx : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    [Header("SFX")]
    [SerializeField] private AudioClip klikskis;
    [SerializeField] private AudioClip dropSkanja;

    [SerializeField] private float skanums = 1f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (klikskis != null)
            SfxAtskanotajs.Instance.Atskanot(klikskis, skanums);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (dropSkanja != null)
            SfxAtskanotajs.Instance.Atskanot(dropSkanja, skanums);
    }

    // Vari arī izsaukt manuāli no cita skripta
    public void AtskanotManuali()
    {
        if (klikskis != null)
            SfxAtskanotajs.Instance.Atskanot(klikskis, skanums);
    }
}