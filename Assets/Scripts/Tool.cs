using UnityEngine;

public class Tool
{
    private static Vector3 CameraStartAngles = new Vector3(35.25f, 45, 0);

    public static GameObject CreateCube()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ResetTransform(go.transform);
        return go;
    }

    public static GameObject CreateRedCube()
    {
        GameObject go = Resources.Load("Prefabs/RedCube") as GameObject;
        ResetTransform(go.transform);
        return go;
    }

    public static void DestroyObject(GameObject go)
    {
        GameObject.Destroy(go);
    }

    private static void ResetTransform(Transform tsf, Transform parent = null)
    {
        tsf.localPosition = Vector3.zero;
        tsf.localEulerAngles = Vector3.zero;
        tsf.localScale = Vector3.one;
        if (parent != null) tsf.SetParent(parent);
    }

    public static void ResetCameraPos(Transform tsf, eDirection e)
    {
        Camera.main.transform.position = GetCameraPoint(tsf, e);
        Camera.main.transform.eulerAngles = CameraStartAngles;
    }

    public static void TurnLeft(eDirection e)
    {
        Vector3 point = GetCenterPoint(e);
        Camera.main.transform.RotateAround(point, Vector3.up, -90);
    }

    public static void TurnRight(eDirection e)
    {
        Vector3 point = GetCenterPoint(e);
        Camera.main.transform.RotateAround(point, Vector3.up, 90);
    }

    public static void RotateScene(Vector3 point, eDirection e, float angle)
    {
        Camera.main.transform.RotateAround(point, Vector3.up, angle);
    }

    private static Vector3 GetCameraPoint(Transform tsf, eDirection e)
    {
        float distance = 5f;
        switch (e)
        {
            case eDirection.forward: return tsf.position + new Vector3(-distance, distance, -distance);
            case eDirection.left: return tsf.position + new Vector3(distance, distance, -distance);
            case eDirection.back: return tsf.position + new Vector3(distance, distance, distance);
            case eDirection.right: return tsf.position + new Vector3(-distance, distance, distance);
        }
        return Vector3.zero;

    }
    public static Vector3 GetCenterPoint(eDirection e)
    {
        float distance = 5f;
        switch (e)
        {
            case eDirection.forward: return Camera.main.transform.position + new Vector3(distance, -distance, distance);
            case eDirection.left: return Camera.main.transform.position + new Vector3(-distance, -distance, distance);
            case eDirection.back: return Camera.main.transform.position + new Vector3(-distance, -distance, -distance);
            case eDirection.right: return Camera.main.transform.position + new Vector3(distance, -distance, -distance);
        }
        return Vector3.zero;
    }
}