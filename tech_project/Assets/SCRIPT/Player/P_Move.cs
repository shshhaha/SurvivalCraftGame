using UnityEngine;
using sound.playerSound;
using DTO.PlayerDTO;

public class P_Move : MonoBehaviour
{
    private AutometicAiming autometicAiming = new AutometicAiming();

    [SerializeField]
    private P_AnimationController animationController; // 애니메이션 컨트롤러를 인스펙터에서 넣어준다.

    private PlayerDTO pvo;
    public float speed;
    public float RunBonus = 1.45f;
    private float RunDebuff = 0.8f;
    public FloatingJoystick Movejoy;//움직임 담당 조이스틱
    public Rigidbody rb;
    public FloatingJoystick Rjoy;//회전 담당 조이스틱
    public GameObject player;//플레이어 오브젝트
    public static bool isPlayerRun = false;
    private float BoundaryValueM = 0;
    private float timer;
    private float walkSound = 0.42f;//걷는 소리 간격
    private float runSound = 0.3f;//걷는 소리 간격


    void Start()
    {
        pvo = PlayerDTO.Instance;
        pvo.setTiredFlag(0);
    }
    public void FixedUpdate()
    {
        tiredDebuffRecover();
        //회전
        if (Rjoy.Vertical != 0 || Rjoy.Horizontal != 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(Rjoy.Horizontal, Rjoy.Vertical) * Mathf.Rad2Deg, 0f);
            //BoundaryValueR = Mathf.Abs(Rjoy.Horizontal) + Mathf.Abs(Rjoy.Vertical);
        }
        //이동
        BoundaryValueM = Mathf.Abs(Movejoy.Horizontal) + Mathf.Abs(Movejoy.Vertical);
        Vector3 direction = Vector3.forward * Movejoy.Vertical + Vector3.right * Movejoy.Horizontal;
        if (BoundaryValueM >= 0.36f && BoundaryValueM <= 1)
        {
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            timer += Time.deltaTime;
            if (timer >= walkSound) { WalkSound(int.Parse(Random.Range(1, 3).ToString())); }
            animationController.playerMoveForward();
            pvo.setIsPlayerRun(false);
        }
        else if (BoundaryValueM >= 1)
        {
            if (pvo.getTiredFlag() == 0)
            {
                rb.AddForce(direction * (speed * RunBonus) * Time.fixedDeltaTime, ForceMode.VelocityChange);
                timer += Time.deltaTime;
                if (timer >= runSound) { WalkSound(int.Parse(Random.Range(1, 3).ToString())); }
                animationController.playerRun();
                pvo.setIsPlayerRun(true);
                if (pvo.getCurrentStamina() <= 0) { pvo.setTiredFlag(2); }
            }
            else if (pvo.getTiredFlag() == 2)
            {
                rb.AddForce(direction * (speed * RunDebuff) * Time.fixedDeltaTime, ForceMode.VelocityChange);
                timer += Time.deltaTime;
                if (timer >= walkSound) { WalkSound(int.Parse(Random.Range(1, 3).ToString())); }
                animationController.playerMoveForward();
                pvo.setIsPlayerRun(false);
            }
        }
        else
        {
            animationController.playerIdle();
            autometicAiming.AutoAim(direction, player);
            pvo.setIsPlayerRun(false);
        }


    }

    void WalkSound(int index)
    {
        if (index == 1) { _PlayerSound.instance.PlayPlayerSFX(_PlayerSound.PlayerSfx.FootAspalt1); }
        else if (index == 2) { _PlayerSound.instance.PlayPlayerSFX(_PlayerSound.PlayerSfx.FootAspalt2); }
        timer = 0;
    }

    void tiredDebuffRecover()
    {
        if (pvo.getTiredFlag() == 2)
        {
            if (pvo.getCurrentStamina() >= pvo.getMaxStamina() * 0.19f)
            {
                pvo.setTiredFlag(0);
            }
        }
    }

}