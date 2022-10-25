using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class RenderOrder : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    SortingGroup sortingGroup;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sortingGroup = GetComponent<SortingGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sortingGroup)
        {
            sortingGroup.sortingOrder = (int)(-10 * transform.position.z);
        }
        else
        {
            spriteRenderer.sortingOrder = (int)(-10 * transform.position.z);
        }
    }
}
