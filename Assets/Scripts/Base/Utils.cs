using UnityEngine;

public class Utils
{
    //Camera
    //rotation = new Vector3(35.25f, 45, 0);

    public static GameObject GetClickObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            return hit.transform.gameObject;
        }
        return null;
    }

    public static GameObject GetCenterObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            return hit.transform.gameObject;
        }
        return null;
    }
}