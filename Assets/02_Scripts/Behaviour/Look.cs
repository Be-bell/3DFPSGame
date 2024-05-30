using System;
using UnityEngine;

public class Look : Behaviour, ILookable
{

    [Header("Look Field")]
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    [SerializeField][Range(0f, 10f)] private float lookSensitivity;
    [SerializeField][Range(0f, 1f)] private float lookVerticalSensitivity;
    [SerializeField] GameObject Aim;
    private float camCurXRot;
    private Vector2 mouseDelta;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputHandler.OnLookEvent += GetLookDelta;
    }

    private void GetLookDelta(Vector2 vector)
    {
        mouseDelta = vector;
    }

    private void LateUpdate()
    {
        LookAt(mouseDelta);
    }

    public void LookAt(Vector2 direction)
    {
        camCurXRot += direction.y * lookVerticalSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        transform.eulerAngles += new Vector3(0, direction.x * lookSensitivity, 0);
        Aim.transform.position = new Vector3(Aim.transform.position.x, camCurXRot, Aim.transform.position.z);
    }
}