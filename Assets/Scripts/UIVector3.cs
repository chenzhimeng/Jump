using UnityEngine;

public class UIVector3 : MonoBehaviour
{
    public UIPoint x;
    public UIPoint y;
    public UIPoint z;

    private Vector3 pos;

    private void Awake()
    {
        EventManager.AddEvent(EventId.OnPointChanged, OnPointChanged);
    }

    private void OnDestroy()
    {
        EventManager.RemoveEvent(EventId.OnPointChanged, OnPointChanged);
    }

    public void Init(Vector3 p)
    {
        pos = new Vector3((int)p.x, (int)p.y, (int)p.z);
        x.Init((int)p.x, ePoint.x);
        y.Init((int)p.y, ePoint.y);
        z.Init((int)p.z, ePoint.z);
    }

    public void Refresh()
    {
        Init(GameManager.Instance.CurCube.transform.position);
    }

    private void OnPointChanged(object[] objs)
    {
        int p = (int)objs[0];
        switch ((ePoint)objs[1])
        {
            case ePoint.x: pos.x = p; break;
            case ePoint.y: pos.y = p; break;
            case ePoint.z: pos.z = p; break;
        }
        EventManager.RunEvent(EventId.OnPositionChanged, new object[] { pos });
    }
}