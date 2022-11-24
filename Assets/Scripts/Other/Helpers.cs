using UnityEngine;
using UnityEngine.UI;

public static class Helpers
{
    public static bool SetActive_Toggle(GameObject go)
    {
        go.SetActive(!go.activeInHierarchy);
        return go.activeInHierarchy;
    }

    public static GameObject SetEnemyFacingDirection(this GameObject go, float direction)
    {
        go.transform.localScale = new Vector3(go.transform.localScale.x * Mathf.Sign(direction),
            go.transform.localScale.y, go.transform.localScale.z);

        return go;
    }


    public static Button GetButton(this GameObject go) => go.GetComponent<Button>();

    public static Button GetButton(this Transform transform) => transform.GetComponent<Button>();

    #region Coloring Debug.Log()
    public static string ToHex(this Color color)
    {
        return string.Format("#{0:X2}{1:X2}{2:X2}", ToByte(color.r), ToByte(color.g), ToByte(color.b));
    }

    private static byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }

    public static string Color(this string text, Color color)
    {
        string output;
        output = string.Format("<color={0}>{1}</color>", color.ToHex(), text);
        return output;
    }
    #endregion
}