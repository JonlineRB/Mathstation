using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for MathCaller scripts.
// Requires a method that calls the math editor
// Requires a method that processes successful math solving
public interface MathCaller
{
    void CallMathEditor();
    void MathSuccess();
}
