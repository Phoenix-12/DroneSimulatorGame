using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDroneControllable
{
    void Pitch(float force);
    void Roll(float force);
    void Yaw(float force);
    void Throttle(float force);
}
