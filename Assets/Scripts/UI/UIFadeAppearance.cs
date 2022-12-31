using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFadeAppearance : MonoBehaviour
{
    TextMeshProUGUI text;

    Transform player;
    [SerializeField] float appearRange, disappearRange;

    float distance;

    float a, b = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerSingleton>().transform;

        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        a = (255 - b) / appearRange;
        b = (255 * disappearRange) / (disappearRange - appearRange);

        float transparency = (a * distance) + b;

        if (distance > appearRange)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, transparency / 255);
        }
        else
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 255f);
        }
    }
}
