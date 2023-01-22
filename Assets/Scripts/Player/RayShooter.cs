using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private float _RateOfFire;
    [SerializeField] private AudioSource _shootSound;
    private float _time;

    private Camera _camera;
    private List<GameObject> _deadEnemyList;
    
    public int DeadEnemyCount
    {
        get { return _deadEnemyList.Count; }
    }

    public event UnityAction<int> Enemykilled;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _deadEnemyList = new List<GameObject>();
       
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;                        
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*") ;      
    }

    private void Update()
    {        
        if (Input.GetMouseButton(0))
        {
            if ((_time += Time.deltaTime) > _RateOfFire)
            {
                Shoot();
                _shootSound.Play();
                _time = 0;
            }            
        }
    }

   
    private void Shoot()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);      
        RaycastHit hit;                     
        if (Physics.Raycast(ray, out hit))  
        {
            GameObject hitObject = hit.transform.gameObject;       
            if (hitObject.TryGetComponent(out ReactiveTarget target))
            {
                target.ReactToHit();
                _deadEnemyList.Add(hitObject.gameObject);
                Enemykilled?.Invoke(_deadEnemyList.Count);
            }
            if (hitObject.TryGetComponent(out BossButton bossButton))
            {
                bossButton.On = !bossButton.On;
            }
            if (hitObject.TryGetComponent(out Boss boss))
            {
                boss.Laugh();
            }
            else
            {
                StartCoroutine(SphereIndicator(hit.point));     
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)        
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);        

        Destroy(sphere);
    }
}
