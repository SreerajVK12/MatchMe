using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyParent : MonoBehaviour
{
    public RectTransform parent;
    private RectTransform myTransform;

    private void Awake()
    {
        myTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.sizeDelta = new Vector2(parent.rect.width, parent.rect.height);
    }
}
