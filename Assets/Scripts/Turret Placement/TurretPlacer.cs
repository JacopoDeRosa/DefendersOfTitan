using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TurretPlacer : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private TurretIdentifier _turret;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _image;
    [SerializeField] private LayerMask _mask;


    private Vector3 _initialPos;
    private Vector2 _offset;

    private PointKeeper _pointKeeper;

    private void Awake()
    {
        _initialPos = transform.position;
        _image.sprite = _turret.Icon;
        _costText.text = _turret.TurretCost.ToString();
        _pointKeeper = FindObjectOfType<PointKeeper>();

    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + _offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _mask))
        {
            if(_pointKeeper.TrySpendPoints(_turret.TurretCost) && hit.transform.TryGetComponent(out TurretHardpoint hardpoint))
            {       
                hardpoint.TryPlaceTurret(_turret);
            }
        }

        transform.position = _initialPos;

    }
}
