using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject counterPanel;
    public GameObject kitchenPanel;

    public TMP_Text orderText;

    void Awake() => Instance = this;

    public void ShowCounterPanel()
    {
        counterPanel.SetActive(true);
        kitchenPanel.SetActive(false);
    }

    public void ShowKitchenPanel()
    {
        counterPanel.SetActive(false);
        kitchenPanel.SetActive(true);
    }

    public void ShowOrder(string orderText)
    {
        this.orderText.text = orderText;
    }

    public void ShowReaction(string reactionText)
    {
        this.orderText.text = reactionText;
    }
}
