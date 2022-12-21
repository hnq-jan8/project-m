using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarState : Stage1State
{
    //Roar for 3s -> ChasePlayerState

    float delay = 0.1f;
    bool roarAudioPlayed = false;
    public override IBossState DoState(BossBehavior boss)
    {
        float time = boss.CountTimeInState();
        if(time <= 3)
        {
            delay -= Time.deltaTime;

            if (delay <= 0)  //Done delay
            {
                //Debug.Log("ROARRR");
                if(roarAudioPlayed == false)
                {
                    if(AudioManager.instance != null)
                    {
                        AudioManager.instance.PlaySFX(4);
                    }
                    roarAudioPlayed = true;
                }
                boss.camshake.PlayCamShake();
                delay = 0.1f;
            }
            return boss.roarState;
        }
        else
        {
            boss.ResetTimeInState();
            boss.SetFightInProgress();
            return boss.chasePlayerState;
        }
    }
}
