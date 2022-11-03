using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IngameMenu : MonoBehaviour
{

    public abstract void UsingMenu();

    public void DestroyIngameGameObjects()
    {
        Destroy(PlayerSingleton.instance.gameObject);
        PlayerSingleton.instance = null;

        Destroy(ManagerSingleton.instance.gameObject);
        ManagerSingleton.instance = null;
    }
}
