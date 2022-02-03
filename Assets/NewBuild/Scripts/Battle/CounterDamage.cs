
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CounterDamage : MonoBehaviour
{
    public static void TextRises(CharacterEnum character, RectTransform transform, Text risePrefab, string text, Color color, int textSize = 100)
    {
        var view = Instantiate(risePrefab, transform);
        view.text = text;
        view.color = color;
        view.fontSize = textSize;
        var duration = 1.8f;
        switch (character)
        {
            case CharacterEnum.Player:
                view.transform.DOMove(view.transform.position +new Vector3(250, 800, 0), duration).SetEase(Ease.OutCirc); break;
            case CharacterEnum.Enemy:
                view.transform.DOMove(view.transform.position +new Vector3(-250, 800, 0), duration).SetEase(Ease.OutCirc); break;
        }
        Destroy(view.gameObject, 2f);
    }
}
