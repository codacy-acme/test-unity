using UnityEngine;

/// <summary>
/// Demonstrates the Roslyn issue: Avoid Null Propagation on Unity Objects.
/// The ?. operator does not behave correctly with Unity Objects because Unity
/// overrides the == operator, so a "destroyed" object is not truly null in C# terms,
/// and null propagation bypasses Unity's custom null check.
/// </summary>
public class NullPropagationIssue : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Transform _target;

    void Update()
    {
        // Issue: ?. bypasses Unity's overloaded == null check
        _rigidbody?.Sleep();

        // Issue: null propagation on Unity Object in conditional expression
        var velocity = _rigidbody?.velocity ?? Vector3.zero;

        // Issue: chained null propagation on Unity Objects
        var position = _target?.transform?.position;

        // Issue: null propagation when invoking a method on a Unity Object
        _audioSource?.Play();

        Debug.Log($"Velocity: {velocity}, Position: {position}");
    }
}
