using UnityEngine;

public enum eDirection
{
    forward,
    left,
    back,
    right,
}

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }

    private Material redMaterial;//红色材质
    private Material norMaterial;//普通材质
    public eDirection CameraDirection = eDirection.forward;//相机方向

    public GameObject CurCube { get; set; }//当前选中

    public GameManager()
    {
        InitMaterial();
    }

    private void InitMaterial()
    {
        GameObject go = Tool.CreateCube();
        go.SetActive(false);
        MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();
        norMaterial = meshRenderer.material;
        go = Tool.CreateRedCube();
        go.SetActive(false);
        meshRenderer = go.GetComponent<MeshRenderer>();
        redMaterial = meshRenderer.sharedMaterial;
    }

    public Vector3 CreateCube()
    {
        if (CurCube != null) SetMaterial(CurCube, false);
        CurCube = Tool.CreateCube();
        SetMaterial(CurCube, true);
        return CurCube.transform.position;
    }

    public void DelCurCube()
    {
        if (CurCube == null) return;
        Tool.DestroyObject(CurCube);
        CurCube = null;
    }

    public void UnSelectCurCube()
    {
        if (CurCube == null) return;
        SetMaterial(CurCube, false);
        CurCube = null;
    }

    public void UpdateCurCubePos(Vector3 pos)
    {
        if (CurCube == null) return;
        CurCube.transform.position = pos;
    }

    public void OnClickObject(GameObject go)
    {
        if (go == null) return;
        if (CurCube != null) SetMaterial(CurCube, false);
        CurCube = go;
        SetMaterial(CurCube, true);
    }

    public void TurnLeft()
    {
        Tool.TurnLeft(CameraDirection);
        DirectionTurnLeft();
    }

    public void TurnRight()
    {
        Tool.TurnRight(CameraDirection);
        DirectionTurnRight();
    }

    private void DirectionTurnLeft()
    {
        switch (CameraDirection)
        {
            case eDirection.forward: CameraDirection = eDirection.left; break;
            case eDirection.left: CameraDirection = eDirection.back; break;
            case eDirection.back: CameraDirection = eDirection.right; break;
            case eDirection.right: CameraDirection = eDirection.forward; break;
        }
    }

    private void DirectionTurnRight()
    {
        switch (CameraDirection)
        {
            case eDirection.forward: CameraDirection = eDirection.right; break;
            case eDirection.left: CameraDirection = eDirection.forward; break;
            case eDirection.back: CameraDirection = eDirection.left; break;
            case eDirection.right: CameraDirection = eDirection.back; break;
        }
    }

    public void ResetCamera()
    {
        if (CurCube == null) return;
        Tool.ResetCameraPos(CurCube.transform, CameraDirection);
    }

    private void SetMaterial(GameObject go, bool isRed)
    {
        MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();
        meshRenderer.material = isRed ? redMaterial : norMaterial;
    }
}