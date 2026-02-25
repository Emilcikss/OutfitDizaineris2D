using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AprikojumaSlots : MonoBehaviour, IDropHandler
{
    [Header("Slota tips")]
    public AprikojumaTips tips;

    [Header("Kur attēlot uzvilkto")]
    [SerializeField] private Image slotaAttels;

    private void Awake()
    {
        if (slotaAttels == null)
        {
            slotaAttels = GetComponent<Image>();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        VelkamaisPrieksmets vilktais = eventData.pointerDrag.GetComponent<VelkamaisPrieksmets>();
        if (vilktais == null) return;

        // pārbaude: tips sakrīt?
        if (vilktais.tips != tips) return;

        // uzvelkam: nomainām sprite slotā
        if (slotaAttels != null)
        {
            slotaAttels.sprite = vilktais.prieksmetaSprite;
            slotaAttels.color = Color.white; // ja bija caurspīdīgs
        }
    }
}