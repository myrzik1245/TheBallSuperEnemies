using UnityEngine;

public class PatrolPoint : MonoBehaviour, IReadOnlyPosition
{
    public Vector3 Value => transform.position;
}
