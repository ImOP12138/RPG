using UnityEngine;

public class MapRotation : MonoBehaviour
{
    
    private Player player;
    private Transform lastTransform;
    public Transform playerTransform; // 人物的Transform组件

    public float rotationAngle = 90f; // 旋转角度
    public float rotationSpeed = 20f; // 旋转速度
    private bool rotated;
                                      
    Vector3 upOffsetRight = new Vector3(-1.5f, -1f, 0f);// 向上移动一段位置,防止旋转后人物掉出地图去
    Vector3 upOffsetLeft = new Vector3(1.5f, -1f, 0f);// 向上移动一段位置,防止旋转后人物掉出地图去


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        lastTransform = transform;
    }

    private void Update()
    {
        
        if (player.IsAreaDetecteed())
        {
            RotateMap();       
        }
    }
    

    private void RotateMap()
    {
        if(player.IsGroundDetecteed())
        {
            if (player.IsWallDetected() )
            {
                

                switch (player.facingDir)
                {
                    case 1:
                        lastTransform=transform;
                        transform.RotateAround(playerTransform.position, Vector3.forward,-90f);
                        transform.Translate(upOffsetRight, Space.World);
                        rotated = true;
                        break;
                    case -1:
                        lastTransform = transform;
                        transform.RotateAround(playerTransform.position, Vector3.forward, 90f);
                        transform.Translate(upOffsetLeft, Space.World);
                        rotated=true;
                        break;
                }
            
            }
            if ( !player.IsGroundEageDetecteed() )
            {
                
                switch (player.facingDir)
                {
                    case 1:
                        lastTransform = transform;
                        transform.RotateAround(playerTransform.position, Vector3.forward, 90f);
                        transform.Translate(upOffsetRight, Space.World);
                        rotated=true;
                        break;
                    case -1:
                        lastTransform = transform;
                        transform.RotateAround(playerTransform.position, Vector3.forward, -90f);
                        transform.Translate(upOffsetLeft, Space.World);
                        rotated=true;
                        break;
                }

            }

        }
        
    }
    private Transform GetLastRotation()
    {
        return lastTransform;
    }
    
    
}
