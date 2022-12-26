using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public static MoneyUI instance;

    private TextMeshProUGUI text;

    void Start()
    {
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerWalletManager.instance.getMoney().ToString();
    }
}
