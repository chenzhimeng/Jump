using UnityEngine;

public class TouchController : MonoBehaviour
{
    private int screenWidth;
    private float oldAngle = 0;//上一次的角度
    private bool isDrag = false;//正在拖动
    private Vector3 point;
    private GameObject goClick;
    

    private void Start()
    {
        screenWidth = Screen.width;
    }

    private void Update()
    {
        CheckClick();
        CheckDrag();
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            goClick = Utils.GetClickObject();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (goClick == null) return;
            GameObject go = Utils.GetClickObject();
            if (go == goClick) EventManager.RunEvent(EventId.OnClickObject, new object[] { go });
        }
    }

    private void CheckDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            point = Input.mousePosition;
            EventManager.RunEvent(EventId.OnDragSceneStart);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 point2 = Input.mousePosition;
            if (point2.Equals(point)) return;
            float length = point2.x - point.x;
            float width = screenWidth / 4.0f;
            float angle1 = (int)(length / width) * 90;
            float angle2 = (length % width) / width * 90;
            float angle = angle1 + angle2;
            EventManager.RunEvent(EventId.OnDragScene, new object[] { angle - oldAngle });
            isDrag = true;
            oldAngle = angle;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isDrag) EventManager.RunEvent(EventId.OnDragSceneEnd, new object[] { oldAngle });
            isDrag = false;
            oldAngle = 0;
        }
    }
}
