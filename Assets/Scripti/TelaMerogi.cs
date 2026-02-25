using UnityEngine;
using UnityEngine.UI;

public class TelaMerogi : MonoBehaviour
{
    [Header("Ko skalējam")]
    [SerializeField] private RectTransform telaRect; // TelsImage RectTransform

    [Header("Slīdņi")]
    [SerializeField] private Slider garumaSlidnis;   // Y
    [SerializeField] private Slider platumaSlidnis;  // X

    [Header("Drošības robežas")]
    [SerializeField] private float minMerogs = 0.7f;
    [SerializeField] private float maxMerogs = 1.3f;

    private Vector3 sakumaMerogs;

    private void Awake()
    {
        if (telaRect == null)
            telaRect = GetComponent<RectTransform>();

        sakumaMerogs = telaRect.localScale;
    }

    private void Start()
    {
        // ieliekam slīdņiem robežas + sākuma vērtības
        if (garumaSlidnis != null)
        {
            garumaSlidnis.minValue = minMerogs;
            garumaSlidnis.maxValue = maxMerogs;
            garumaSlidnis.value = sakumaMerogs.y;
            garumaSlidnis.onValueChanged.AddListener(_ => AtjaunotMerogu());
        }

        if (platumaSlidnis != null)
        {
            platumaSlidnis.minValue = minMerogs;
            platumaSlidnis.maxValue = maxMerogs;
            platumaSlidnis.value = sakumaMerogs.x;
            platumaSlidnis.onValueChanged.AddListener(_ => AtjaunotMerogu());
        }

        AtjaunotMerogu();
    }

    public void AtjaunotMerogu()
    {
        if (telaRect == null) return;

        float x = (platumaSlidnis != null) ? platumaSlidnis.value : sakumaMerogs.x;
        float y = (garumaSlidnis != null) ? garumaSlidnis.value : sakumaMerogs.y;

        x = Mathf.Clamp(x, minMerogs, maxMerogs);
        y = Mathf.Clamp(y, minMerogs, maxMerogs);

        telaRect.localScale = new Vector3(x, y, 1f);
    }

    public void Atiestatit()
    {
        if (telaRect == null) return;

        telaRect.localScale = sakumaMerogs;

        if (platumaSlidnis != null) platumaSlidnis.value = sakumaMerogs.x;
        if (garumaSlidnis != null) garumaSlidnis.value = sakumaMerogs.y;
    }
}