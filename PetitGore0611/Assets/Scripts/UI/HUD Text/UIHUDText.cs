using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHUDText : MonoBehaviour
{
    [SerializeField] private float moveDistance = 100;  //RectTransform 기준 이동거리
    [SerializeField] private float moveTime = 1.5f;     //이동시간

    private RectTransform rectTransform;
    private TextMeshProUGUI textHUD;

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textHUD = GetComponent<TextMeshProUGUI>();
    }

    public void Play(string text, Color color, Bounds bounds, float gap = 0.1f)
    {
        textHUD.text = text;
        textHUD.color = color;

        StartCoroutine(OnHUDText(bounds, gap));
    }

    private IEnumerator OnHUDText(Bounds bounds, float gap)
    {
        //WorldToScreenPoint() 메소드를 이용해 매개변수에 있는 우러드 좌표를 바탕으로 화면 상의 좌표를 구현
        Vector2 start = Camera.main.WorldToScreenPoint(new Vector3(bounds.center.x, bounds.max.y - gap, bounds.center.z));
        Vector2 end = start + Vector2.up * moveDistance;

        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            //Text UI의 위치 제어
            rectTransform.position = Vector2.Lerp(start, end, percent);
            //Text UI의 알파값 제어
            Color color = textHUD.color;

            color.a = Mathf.Lerp(1, 0, percent);
            textHUD.color = color;

            yield return null;
        }
        Destroy(gameObject);
    }
}
