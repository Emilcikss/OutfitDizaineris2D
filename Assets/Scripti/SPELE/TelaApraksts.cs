using TMPro;
using UnityEngine;

public class TelaApraksts : MonoBehaviour
{
    [SerializeField] private TMP_Text aprakstsTeksts;

    [TextArea(3, 10)]
    [SerializeField] private string viraApraksts = "Vīriešu tēls: ielas stils, minimālisms un pārliecība.";

    [TextArea(3, 10)]
    [SerializeField] private string sievietesApraksts = "Sieviešu tēls: elegance, moderns dizains un akcenti.";

    public void IestatītVirieti()
    {
        if (aprakstsTeksts != null) aprakstsTeksts.text = viraApraksts;
    }

    public void IestatītSievieti()
    {
        if (aprakstsTeksts != null) aprakstsTeksts.text = sievietesApraksts;
    }
}