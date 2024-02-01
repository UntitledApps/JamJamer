using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), duration: 60, RotateMode.FastBeyond360).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
