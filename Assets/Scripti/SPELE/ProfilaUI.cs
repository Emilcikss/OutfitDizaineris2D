using System;
using TMPro;
using UnityEngine;

public class ProfilaUI : MonoBehaviour
{
    [Header("Ievades lauki")]
    [SerializeField] private TMP_InputField vardsIevade;
    [SerializeField] private TMP_InputField dzimsanasGadsIevade;
    [SerializeField] private TelaIzvele telaIzvele;
    
    [Header("Izvade")]
    [SerializeField] private TMP_Text rezultatsTeksts;

    [Header("Iestatījumi")]
    [SerializeField] private bool izmantotDzimumaGalotni = true; // piem: "vecs/veca"

    public void ApstradatDatus()
    {
        string vards = (vardsIevade != null) ? vardsIevade.text.Trim() : "";
        string gadsTeksts = (dzimsanasGadsIevade != null) ? dzimsanasGadsIevade.text.Trim() : "";

        if (string.IsNullOrWhiteSpace(vards))
        {
            rezultatsTeksts.text = "Lūdzu, ievadi vārdu!";
            return;
        }

        if (!int.TryParse(gadsTeksts, out int dzimsanasGads))
        {
            rezultatsTeksts.text = "Lūdzu, ievadi dzimšanas gadu ar cipariem!";
            return;
        }

        int pasreizejaisGads = DateTime.Now.Year;

        if (dzimsanasGads < 1900 || dzimsanasGads > pasreizejaisGads)
        {
            rezultatsTeksts.text = "Dzimšanas gads nav korekts!";
            return;
        }

        int vecums = pasreizejaisGads - dzimsanasGads;

        bool irVirietis = telaIzvele != null ? telaIzvele.VaiVirietis() : true;
        string galotne = irVirietis ? " vecs!" : " veca!";
        rezultatsTeksts.text = $"{vards} ir {vecums} gadus{galotne}";
    }
}