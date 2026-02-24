using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TelaIzvele : MonoBehaviour
{
    [Header("Dropdown")]
    [SerializeField] private TMP_Dropdown telaDropdown;

    [Header("Tēla attēls")]
    [SerializeField] private Image telaAttels;

    [Header("Sprite")]
    [SerializeField] private Sprite viriesaSprite;
    [SerializeField] private Sprite sievietesSprite;

    [Header("Apraksts")]
    [SerializeField] private TelaApraksts telaApraksts;

    private int pasreizejaisTels = 0;

    void Start()
    {
        AtjaunotTelu(0);
        telaDropdown.onValueChanged.AddListener(AtjaunotTelu);
    }

    public void AtjaunotTelu(int indekss)
    {
        pasreizejaisTels = indekss;

        if (indekss == 0)
        {
            telaAttels.sprite = viriesaSprite;
            telaApraksts.IestatītVirieti();
        }
        else
        {
            telaAttels.sprite = sievietesSprite;
            telaApraksts.IestatītSievieti();
        }
    }

    public bool VaiVirietis()
    {
        return pasreizejaisTels == 0;
    }
}