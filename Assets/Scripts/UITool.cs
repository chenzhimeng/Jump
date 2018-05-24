using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITool : MonoBehaviour
{
    public Button btnOk;
    public Button btnLeft;
    public Button btnRight;
    public Button btnCamera;
    public Button btnSwitch;
    public Button btnAddCube;
    public Button btnDelCube;
    public UIVector3 uiCubePos;
    public GameObject goToolPanel;

    private bool IsToolShow
    {
        get { return goToolPanel.activeInHierarchy; }
    }

    private void Awake()
    {
        btnOk.onClick.AddListener(OnClickOk);
        btnLeft.onClick.AddListener(OnClickLeft);
        btnRight.onClick.AddListener(OnClickRight);
        btnCamera.onClick.AddListener(OnClickCamera);
        btnSwitch.onClick.AddListener(OnClickSwitch);
        btnAddCube.onClick.AddListener(OnClickAddCube);
        btnDelCube.onClick.AddListener(OnClickDelCube);
        EventManager.AddEvent(EventId.OnClickObject, OnClickObject);
        EventManager.AddEvent(EventId.OnPositionChanged, OnPositionChanged);
    }

    private void OnDestroy()
    {
        btnOk.onClick.RemoveListener(OnClickOk);
        btnLeft.onClick.RemoveListener(OnClickLeft);
        btnRight.onClick.RemoveListener(OnClickRight);
        btnCamera.onClick.RemoveListener(OnClickCamera);
        btnSwitch.onClick.RemoveListener(OnClickSwitch);
        btnAddCube.onClick.RemoveListener(OnClickAddCube);
        btnDelCube.onClick.RemoveListener(OnClickDelCube);
        EventManager.RemoveEvent(EventId.OnClickObject, OnClickObject);
        EventManager.RemoveEvent(EventId.OnPositionChanged, OnPositionChanged);
    }

    private void Start()
    {
        goToolPanel.SetActive(false);
    }

    private void OnClickOk()
    {
        GameManager.Instance.UnSelectCurCube();
    }

    private void OnClickLeft()
    {
        GameManager.Instance.TurnLeft();
    }

    private void OnClickRight()
    {
        GameManager.Instance.TurnRight();
    }

    private void OnClickCamera()
    {
        GameManager.Instance.ResetCamera();
    }

    private void OnClickSwitch()
    {
        goToolPanel.SetActive(!IsToolShow);
    }

    private void OnClickAddCube()
    {
        Vector3 pos = GameManager.Instance.CreateCube();
        uiCubePos.Init(pos);
    }

    private void OnClickDelCube()
    {
        GameManager.Instance.DelCurCube();
    }

    private void OnClickObject(object[] objs)
    {
        GameManager.Instance.OnClickObject((GameObject)objs[0]);
        uiCubePos.Refresh();
    }

    private void OnPositionChanged(object[] objs)
    {
        GameManager.Instance.UpdateCurCubePos((Vector3)objs[0]);
    }
}