using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableComponent : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action<PointerEventData, bool> OnEndDragHandler;
    public bool FollowCursor { get; set; } = true;
    public Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;

    private RectTransform rectTransform;
    private Canvas canvas;

    MineBlock mineblock;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        mineblock = FindObjectOfType<MineBlock>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }

        OnBeginDragHandler?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        mineblock.isAbleToAction = false;


        if (!CanDrag)
        {
            return;
        }

        OnDragHandler?.Invoke(eventData);

        if (FollowCursor)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mineblock.isAbleToAction = true;


        if (!CanDrag)
        {
            return;
        }

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        DropArea dropArea = null;

        foreach (var result in results)
        {
            dropArea = result.gameObject.GetComponent<DropArea>();

            if (dropArea != null)
            {
                break;
            }
        }

        if (dropArea != null && dropArea.transform.childCount < 1)
        {
            if (dropArea.Accepts(this))
            {
                dropArea.Drop(this);
                OnEndDragHandler?.Invoke(eventData, true);
                transform.parent = dropArea.transform;
                return;
            }
        }

        rectTransform.anchoredPosition = StartPosition;
        OnEndDragHandler?.Invoke(eventData, false);
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        StartPosition = rectTransform.anchoredPosition;
    }
}