using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOMoveY(1815, 10f).SetEase(Ease.Linear).SetLoops(-1);
        rectTransform.DORotate(new Vector3(15, 0, 0), duration: 10, RotateMode.Fast).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
