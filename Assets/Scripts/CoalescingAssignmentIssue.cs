using UnityEngine;

/// <summary>
/// Demonstrates the Roslyn issue: Avoid Coalescing Assignment on Unity Objects.
/// The ??= operator does not behave correctly with Unity Objects because Unity
/// overrides the == operator, so a "destroyed" object is not truly null in C# terms.
/// </summary>
public class CoalescingAssignmentIssue : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;

    void Start()
    {
        // Issue: ??= does not account for Unity's custom null check
        _rigidbody =
        // Issue: ??= does not account for Unity's custom null check
        _rigidbody != null ?
        // Issue: ??= does not account for Unity's custom null check
        _rigidbody : GetComponent<Rigidbody>();

        _audioSource =
        _audioSource != null ? _audioSource : GetComponent<AudioSource>();

        _meshRenderer =
        _meshRenderer != null ? _meshRenderer : GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Issue: ??= in update path on Unity Object
        _rigidbody =
        // Issue: ??= in update path on Unity Object
        _rigidbody != null ?
        // Issue: ??= in update path on Unity Object
        _rigidbody : gameObject.AddComponent<Rigidbody>();
    }
}
