using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{

    public abstract void OnShoot(Transform emitter, bool rapid);

}
