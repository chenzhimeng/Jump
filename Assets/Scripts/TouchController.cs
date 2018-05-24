using UnityEngine;

public class TouchController : MonoBehaviour
{
    private GameObject goClick;

    private void Update()
    {
        CheckClick();
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
    }
}
