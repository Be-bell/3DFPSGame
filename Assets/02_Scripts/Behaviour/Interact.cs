using UnityEngine;

public class Interact : Behaviour
{
    private Camera _camera;

    [Header("Check Item")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] [Range(0f,10f)] private float checkDistance;
    private IInteractable curInteractable;
    private GameObject curInteractGameObject;


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Raycasting();
    }

    private void Raycasting()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, checkDistance, layerMask))
        {
            if (hit.collider.gameObject != curInteractGameObject)
            {
                curInteractGameObject = hit.collider.gameObject;
                curInteractable = hit.collider.GetComponent<IInteractable>();
                //프롬포트에 출력.
                SetPromptText();
            }
        }
        else
        {
            curInteractGameObject = null;
            curInteractable = null;
            UIManager.Instance.itemTMPro.gameObject.SetActive(false);
        }
    }

    private void SetPromptText()
    {
        UIManager.Instance.itemTMPro.gameObject.SetActive(true);
        UIManager.Instance.itemTMPro.text = curInteractable.GetInteractPrompt();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractable>() != null)
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.OnInteract();
        }
    }
}