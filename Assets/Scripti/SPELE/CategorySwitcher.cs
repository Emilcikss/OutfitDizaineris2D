using UnityEngine;
using UnityEngine.UI;

public class KategorijuParsledzejs : MonoBehaviour
{
    [Header("Toggle")]
    [SerializeField] private Toggle cepuresToggle;
    [SerializeField] private Toggle augsaToggle;
    [SerializeField] private Toggle biksesToggle;
    [SerializeField] private Toggle apaviToggle;
    [SerializeField] private Toggle aksesuariToggle;

    [Header("Saturs")]
    [SerializeField] private GameObject cepuresSaturs;
    [SerializeField] private GameObject augsaSaturs;
    [SerializeField] private GameObject biksesSaturs;
    [SerializeField] private GameObject apaviSaturs;
    [SerializeField] private GameObject aksesuariSaturs;

    void Start()
    {
        // IMPORTANT: reaģējam tikai uz "true"
        cepuresToggle.onValueChanged.AddListener(isOn => { if (isOn) Paradit(cepuresSaturs); });
        augsaToggle.onValueChanged.AddListener(isOn => { if (isOn) Paradit(augsaSaturs); });
        biksesToggle.onValueChanged.AddListener(isOn => { if (isOn) Paradit(biksesSaturs); });
        apaviToggle.onValueChanged.AddListener(isOn => { if (isOn) Paradit(apaviSaturs); });
        aksesuariToggle.onValueChanged.AddListener(isOn => { if (isOn) Paradit(aksesuariSaturs); });

        // noklusējums
        cepuresToggle.SetIsOnWithoutNotify(true);
        Paradit(cepuresSaturs);
    }

    private void PasleptVisu()
    {
        cepuresSaturs.SetActive(false);
        augsaSaturs.SetActive(false);
        biksesSaturs.SetActive(false);
        apaviSaturs.SetActive(false);
        aksesuariSaturs.SetActive(false);
    }

    private void Paradit(GameObject koRadit)
    {
        PasleptVisu();
        koRadit.SetActive(true);
    }
}