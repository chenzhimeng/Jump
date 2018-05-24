using UnityEngine;
using UnityEngine.UI;

public enum ePoint
{
    x,
    y,
    z
}

public class UIPoint : MonoBehaviour
{
    public Button btnCut;
    public Button btnAdd;
    public InputField iptValue;

    private int point;
    private ePoint type;

    private void Awake()
    {
        btnCut.onClick.AddListener(OnClickCut);
        btnAdd.onClick.AddListener(OnClickAdd);
        iptValue.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDestroy()
    {
        btnCut.onClick.RemoveListener(OnClickCut);
        btnAdd.onClick.RemoveListener(OnClickAdd);
        iptValue.onValueChanged.RemoveListener(OnValueChanged);
    }

    public void Init(int p, ePoint t)
    {
        point = p;
        type = t;
        UpdateText();
    }

    private void UpdateText()
    {
        iptValue.text = point.ToString();
    }

    private void OnClickCut()
    {
        point -= 1;
        UpdateText();
    }

    private void OnClickAdd()
    {
        point += 1;
        UpdateText();
    }

    private void OnValueChanged(string s)
    {
        point = int.Parse(s);
        UpdateText();
        EventManager.RunEvent(EventId.OnPointChanged, new object[] { point, type });
    }
}