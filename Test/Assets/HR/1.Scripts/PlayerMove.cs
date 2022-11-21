using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float dash = 5f;
    public float rotSpeed = 3f;

    private Vector3 dir = Vector3.zero;

    private bool ground = false;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        CheckGround();

        if (Input.GetButtonDown("Jump") && ground)
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }

        // Rigidbody 컴포넌트의 Drag 값이 0 인 채로 다음 코드를 실행하면
        // rigidbody.force assign attempt for 'Player' is not valid. Input force is { -Infinity, -Infinity, -Infinity }.
        // 라는 오류가 나타난다.
        // 인스펙터창에서 Drag 값을 5 정도로 높여주면 된다.
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashPower = transform.forward * -Mathf.Log(1 / rigidbody.drag) * dash;
            rigidbody.AddForce(dashPower, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {
            // 지금 바라보는 방향의 부호 != 나아갈 방향 부호
            if (Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0, 1, 0);
            }
            // Time.deltaTime만 사용하면 너무 느려서 rotSpeed를 곱해준다.
            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }

    void CheckGround()
    {
        RaycastHit hit;

        // 캐릭터의 발 끝보다 0.2 만큼 높은 위치에서 아랫방향으로 쏜다. 0.4만큼 레이저가 발사된다.
        // 이 길이 안에서 우리가 설정한 레이어가 검출이 되면 그 정보를 hit에 담는다.
        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        {
            ground = true;

            Debug.DrawRay(transform.position + (Vector3.up * 0.2f), Vector3.down * hit.distance, Color.red);
        }
        else
        {
            ground = false;
        }
    }
}
