using UnityEngine;

public class KeyboarInput : IInput
{
    private const string VerticalAxis = "Vertical";
    private const string HorizontalAxis = "Horizontal";

    public Vector3 Movement => new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));
}
