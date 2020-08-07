using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    // camera is null for screenspace overlay camera
    private Text tooltipText;
    private RectTransform backgroundRectTransform;

    [SerializeField] string thisToolip;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        tooltipText = transform.Find("tooltipText").GetComponent<Text>();

        ShowTooltip(thisToolip);
    }

    private void Start()
    {
        transform.gameObject.SetActive(false);
    }

    private void OnMouseOver()
    {

    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        // TODO fix static formatting, change rect position ancors most likely
        Vector2 newLocalPoint = new Vector2(localPoint.x, localPoint.y + 40f);
        transform.localPosition = newLocalPoint;
    }

    private void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2f, tooltipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowTooltip(tooltipString);
    }

    public void HideTooltip_Static()
    {
        instance.HideTooltip();
    }
}
