using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int health { get; private set; }
    public Camshake camshake { get; private set; }
    public float timeInState { get; private set; }

    [SerializeField] private BossFightActivateArea bossFightActivateArea;


    #region States
    public IBossState currentState;

    public Stage1State stage1State = new Stage1State();
    public Stage2State stage2State = new Stage2State();
    public IdleState idleState = new IdleState();
    public IntroState introState = new IntroState();
    public RoarState roarState = new RoarState();

    #endregion



    private void OnEnable()
    {
        currentState = idleState;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeInState = 0f;
        health = GetComponent<Life>().GetHealth();
        camshake = FindObjectOfType<PlayerSingleton>().transform.Find("Camshake").GetComponent<Camshake>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
    }

    //Boss fight activation check
    public bool FightIsActivated()
    {
        return bossFightActivateArea.fightActivated;
    }

    //Time in state
    public float CountTimeInState()
    {
        timeInState += Time.deltaTime;
        //Debug.Log(timeInState);

        return timeInState;
    }

    public void ResetTimeInState()
    {
        timeInState = 0f;
    }
}