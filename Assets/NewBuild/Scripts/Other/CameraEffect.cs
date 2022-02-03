
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

    private void Awake()
    {
        Camera = Camera.main;
    }
    private void Start()
    {
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(Camera.transform.DOMove(StarTransform, 3f));
        sequence.Join(Camera.transform.DORotate(StartAngle, 3f));
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
            fieldOfView -= Time.deltaTime*2;
            if (fieldOfView <= 85)
            {
                trate = true;
            }
        }
        if(fieldOfView<100 && trate)
        {
            fieldOfView += Time.deltaTime*2;
            if (fieldOfView >= 100)
            {
                trate = false;
            }
        }
        Camera.fieldOfView = fieldOfView;

    }

    /*public void Final()
    {
        transform.DOMove(FinalTransform, 1f);
    }*/


}
