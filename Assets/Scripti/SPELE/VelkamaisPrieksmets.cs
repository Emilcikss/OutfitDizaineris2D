using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VelkamaisPrieksmets : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Tips un izskats")]
    public AprikojumaTips tips;
    public Sprite prieksmetaSprite;

    [Header("Drag vizuālais")]
    [SerializeField] private Canvas galvenaisCanvas;

    private GameObject vilksanasObjekts;
    private Image vilksanasAttels;
    private RectTransform vilksanasRect;

    private void Awake()
    {
        // Ja sprite nav ielikts, paņem no Image komponentes
        if (prieksmetaSprite == null)
        {
            var img = GetComponent<Image>();
            if (img != null) prieksmetaSprite = img.sprite;
        }

        if (galvenaisCanvas == null)
        {
            galvenaisCanvas = GetComponentInParent<Canvas>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (prieksmetaSprite == null || galvenaisCanvas == null) return;

        // izveidojam “spoku” ikonu, kuru velkam pa ekrānu
        vilksanasObjekts = new GameObject("VilksanasIkona");
        vilksanasObjekts.transform.SetParent(galvenaisCanvas.transform, false);

        vilksanasAttels = vilksanasObjekts.AddComponent<Image>();
        vilksanasAttels.sprite = prieksmetaSprite;
        vilksanasAttels.raycastTarget = false; // lai netraucē drop

        vilksanasRect = vilksanasObjekts.GetComponent<RectTransform>();
        vilksanasRect.sizeDelta = new Vector2(80, 80); // var mainīt pēc vajadzības

        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (vilksanasRect == null) return;

        // pārvietojam “spoku” uz peles pozīciju
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)galvenaisCanvas.transform,
            eventData.position,
            galvenaisCanvas.worldCamera,
            out Vector2 lokalaPozicija
        );

        vilksanasRect.localPosition = lokalaPozicija;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (vilksanasObjekts != null)
        {
            Destroy(vilksanasObjekts);
        }
    }
}