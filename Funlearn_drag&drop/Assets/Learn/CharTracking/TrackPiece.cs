using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrackPiece : MonoBehaviour, IPointerEnterHandler{

    Image image;
    Color defaultColor;
    public Color HoverColor;

    bool isTracked;
    public bool IsTracked
    {
        get
        {
            return isTracked;
        }
        set
        {
            isTracked = value;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    public void ResetTrackPiece()
    {
        image.color = defaultColor;
        isTracked = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isTracked && Input.GetMouseButton(0))
        {
            transform.parent.GetComponent<Tracker>().OnItemHovered(this);
            image.color = HoverColor;
            isTracked = true;
        }
    }
}
