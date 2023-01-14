using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private Transform hpIcon;
    [SerializeField] private List<GameObject> HP;
    private Life playerLife;
    // Start is called before the first frame update
    void Start()
    {
        playerLife = FindObjectOfType<PlayerSingleton>().gameObject.GetComponent<PlayerLife>();
        Debug.Log(playerLife.GetMaxHealth());
        InitHP();
    }

    public void UpdateHP()
    {
        //4 hp -> 5th hp disabled
        //3 hp -> 4th hp disabled
        //2 hp -> 3th hp disabled
        //n hp -> nth hp disabled
        int currentHealth = playerLife.GetHealth();
        for(int i = HP.Count - 1; i >= currentHealth; i--)
        {
            Debug.Log(i);
            HP[i].SetActive(false);
        }
    }

    public void InitHP()
    {
        //Debug.Log(playerLife.GetHealth());
        int currentHealth = playerLife.GetMaxHealth();
        for(int i = 0; i < currentHealth; i++)
        { 
            GameObject hpObject = Instantiate(hpIcon, content).gameObject;
            HP.Add(hpObject);
        }
        hpIcon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerLife.GetHealth());
    }
}
