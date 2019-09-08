using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{
    protected Transform _GoTransform;
    protected GameObject _GOInstance;
    protected string _name;
    protected bool _isVisible;

    protected Vector3 _position;
    protected Vector3 _scale;
    protected Quaternion _rotanion;

    protected Material _material;
    protected Color __color;

    protected Rigidbody _rigidbody;

    protected Camera _mainCamera;

    protected Animator _animator;

    #region function 
    protected virtual void Awake()
    {
        _GOInstance = gameObject;
        _GoTransform = _GOInstance.transform;
        _name = _GOInstance.name;

        if(GetComponent<Rigidbody>())
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        if (GetComponent<Animator>())
        {
            _animator = GetComponent<Animator>();
        }
        if (GetComponent<Renderer>())
        {
            _material = GetComponent<Renderer>().material;
        }
        _mainCamera = Camera.main;

    }
    #endregion

    #region свойства

    public GameObject InstanceObject
    {
        get { return _GOInstance; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            InstanceObject.name = _name;
        }
    }

    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            _isVisible = value;
            if (_GOInstance.GetComponent<MeshRenderer>())
            {
                _GOInstance.GetComponent<MeshRenderer>().enabled = _isVisible;
            }
        }
    }

    public Vector3 Position
    {
        get
        {
            if (_GOInstance)
            {
                _position = _GoTransform.position;
            }
            return _position;
        }
        set
        {
            _position = value;
            if (_GOInstance)
            {
                _GoTransform.position = _position;
            }
        }
    }

    public Vector3 Scale
    {
        get
        {
            if (_GOInstance)
            {
                _scale = _GoTransform.localScale;
            }
            return _scale;
        }
        set
        {
            _scale = value;
            if (_GOInstance)
            {
                _GoTransform.localScale = _scale;
            }
        }
    }

    public Quaternion Rotation
    {
        get
        {
            if (_GOInstance)
            {
                _rotanion = _GoTransform.rotation;
            }
            return _rotanion;
        }
        set
        {
            _rotanion = value;
            if (_GOInstance)
            {
                _GoTransform.rotation = _rotanion;
            }
        }
    }

    public Material GetMaterial
    {
        get { return _material; }
    }

    public Rigidbody GetRigidbody
    {
        get { return _rigidbody; }
    }

    public Animator  Anim
    {
        get { return _animator; }
    }

    public Camera MainCam
    {
        get { return _mainCamera; }
    }

    public int ChildCount
    {
        get
        {
            return _GoTransform.childCount;
        }
    }
    #endregion
}
