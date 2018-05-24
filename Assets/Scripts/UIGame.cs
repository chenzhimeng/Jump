using UnityEngine;

public class UIGame : MonoBehaviour
{
    private void Awake()
    {
        EventManager.AddEvent(EventId.OnDragSceneStart, OnDragSceneStart);
        EventManager.AddEvent(EventId.OnDragScene, OnDragScene);
        EventManager.AddEvent(EventId.OnDragSceneEnd, OnDragSceneEnd);
    }

    private void OnDestroy()
    {
        EventManager.RemoveEvent(EventId.OnDragSceneStart, OnDragSceneStart);
        EventManager.RemoveEvent(EventId.OnDragScene, OnDragScene);
        EventManager.RemoveEvent(EventId.OnDragSceneEnd, OnDragSceneEnd);
    }

    private void OnDragSceneStart(object[] objs)
    {
        GameManager.Instance.OnDragSceneStart();
    }

    private void OnDragScene(object[] objs)
    {
        GameManager.Instance.OnDragScene((float)objs[0]);
    }

    private void OnDragSceneEnd(object[] objs)
    {
        GameManager.Instance.OnDragSceneEnd((float)objs[0]);
    }
}