using UnityEngine;
namespace sound.sfx
{
    public class _SFX : MonoBehaviour
    {
        public static _SFX instance;

        [Header("#SFX")]
        public AudioClip[] _SFXClip;
        public static float SfxVolume = 0.5f;
        public int channels;
        AudioSource []SfxPlayers;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum Sfx {
            AmmoShell,
            BulletCollide,
            }
        void Awake(){
            instance = this;
            Init();
        }

        public void Init()
        {
            //효과음 플레이어 초기화
            GameObject sfxObject = new GameObject("_SFX");
            sfxObject.transform.parent = transform;
            SfxPlayers = new AudioSource[channels];

            for (int i = 0; i < SfxPlayers.Length; i++)
            {
                SfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
                SfxPlayers[i].playOnAwake = false;
                SfxPlayers[i].volume = SfxVolume;
            }
        }

        public void PlaySFX(Sfx sfx){
            for(int i = 0; i < SfxPlayers.Length; i++){
                int loopIndex = (i + channelIndex)%SfxPlayers.Length;
                
                if(SfxPlayers[loopIndex].isPlaying)
                    continue;

                    channelIndex = loopIndex;
                    SfxPlayers[loopIndex].clip = _SFXClip[(int)sfx];
                    SfxPlayers[loopIndex].Play();
                    break;
            }        
        }
        public void StopSFX(Sfx sfx){
            for(int i = 0; i < SfxPlayers.Length; i++){
                if(SfxPlayers[i].clip == _SFXClip[(int)sfx] && SfxPlayers[i].isPlaying){
                    SfxPlayers[i].Stop();
                    break;
                }
            }
        }
    }
}