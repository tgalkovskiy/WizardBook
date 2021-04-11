using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]private Vector3 StarTransform;
    [SerializeField] private Vector3 StartAngle;
    [SerializeField] private GameObject Canvas;
    private Camera Camera;
    private bool trate = false;
    bool comleted; 
    private void Start()
    {
        Camera = Camera.main;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOMove(StarTransform, 3f));
        sequence.Join(this.transform.DORotate(StartAngle, 3f));
        sequence.OnComplete(() => {Canvas.SetActive(true);});
    }
    private void LateUpdate()
    {
        Trate(Camera.fieldOfView);
    }

    private void Trate(float fieldOfView)
    {
        if(fieldOfView>85 && !trate)
        {
            fieldOfView -= Time.deltaTime;
            if (fieldOfView <= 85)
            {
                trate = true;
            }
        }
        if(fieldOfView<120 && trate)
        {
            fieldOfView += Time.deltaTime;
            if (fieldOfView >= 100)
            {
                trate = false;
            }
        }
        Camera.fieldOfView = fieldOfView;

    }



}
