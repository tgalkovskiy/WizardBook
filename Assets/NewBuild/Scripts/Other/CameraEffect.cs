using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]private Vector3 StarTransform = default;
    [SerializeField] private Vector3 FinalTransform = default;
    [SerializeField] private Vector3 StartAngle= default;
    [SerializeField] private GameObject Canvas = default;
    [SerializeField] private SaveTutorial _tutorial;
    [SerializeField] private GameObject First_figth = default; 
    private Camera Camera;
    private bool trate = false;
    bool comleted; 
    private void Start()
    {
        Camera = Camera.main;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOMove(StarTransform, 3f));
        sequence.Join(this.transform.DORotate(StartAngle, 3f));
        sequence.OnComplete(() =>
        {
            Canvas.SetActive(true);
            _tutorial.LoadData();
            if (!_tutorial.first_fitgth)
            {
                First_figth.SetActive(true);
                _tutorial.first_fitgth = true;
                _tutorial.SaveData();
                Time.timeScale = 0;
            }
            
        });
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

    public void Final()
    {
        transform.DOMove(FinalTransform, 1f);
    }


}
