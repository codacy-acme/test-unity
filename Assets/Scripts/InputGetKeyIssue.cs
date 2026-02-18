using UnityEngine;

/// <summary>
/// Demonstrates the Roslyn issue: Use Input.GetKey Overloads with KeyCode Argument.
/// Input.GetKey(string) should be replaced with Input.GetKey(KeyCode) for type safety
/// and to avoid runtime string parsing.
/// </summary>
public class InputGetKeyIssue : MonoBehaviour
{
    void Update()
    {
        // Issue: using string overload instead of KeyCode overload
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed (string overload)");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift pressed (string overload)");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed (string overload)");
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Escape released (string overload)");
        }
    }
}
