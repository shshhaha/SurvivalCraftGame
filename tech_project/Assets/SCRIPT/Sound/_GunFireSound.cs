using UnityEngine;

namespace sound.gunFireSound
{
    public class _GunFireSound : MonoBehaviour
    {
        public static _GunFireSound instance;

        [Header("#GunSFX")]
        public AudioClip[] gunSfxClip;
        public static float gunSfxVolume = 0.5f;
        public int channels;
        AudioSource []gunSfx;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum GunSfx {
            GrenadeEx,//0
            GrenadeTR,
            MachineGun,
            Uzi,
            AK12,
            M4,
            DMR,
            RPG,//7
            RpgReload,
            ShotGunFire,
            ShotGunReloadM4,
            ShotGunReloadDoubleStart,
            ShotGunReloadDoubleEnd,
            }
        void Awake(){
            instance = this;
            Init();
        }

        public void Init()
        {
            //효과음 플레이어 초기화
            GameObject sfxObject = new GameObject("_GunSound");
            sfxObject.transform.parent = transform;
            gunSfx = new AudioSource[channels];

            for (int i = 0; i < gunSfx.Length; i++)
            {
                gunSfx[i] = sfxObject.AddComponent<AudioSource>();
                gunSfx[i].playOnAwake = false;
                gunSfx[i].volume = gunSfxVolume;
            }
        }

        public void PlayGunSFX(GunSfx sfx){
            for(int i = 0; i < gunSfx.Length; i++){
                int loopIndex = (i + channelIndex)%gunSfx.Length;
                
                if(gunSfx[loopIndex].isPlaying)
                    continue;

                    channelIndex = loopIndex;
                    gunSfx[loopIndex].clip = gunSfxClip[(int)sfx];
                    gunSfx[loopIndex].Play();
                    break;
            }        
        }
        public void StopGunSFX(GunSfx sfx){
            for(int i = 0; i < gunSfx.Length; i++){
                if(gunSfx[i].clip == gunSfxClip[(int)sfx] && gunSfx[i].isPlaying){
                    gunSfx[i].Stop();
                    break;
                }
            }
        }
    }
}
