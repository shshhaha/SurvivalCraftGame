using UnityEngine;
namespace sound.uiSound
{
    public class _UiSound : MonoBehaviour
    {
        public static _UiSound instance;

        [Header("#UiSFX")]
        public AudioClip[] uiSfxClip;
        public static float uiSfxVolume = 1f;
        public int channels;
        AudioSource []uiSfxPlayers;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum UiSfx {
            ItemPickUp,
            OpenInventory,
            CloseInventory,
            Click
            }
        void Awake(){
            instance = this;
            Init();
        }

        public void Init()
        {
            //효과음 플레이어 초기화
            GameObject sfxObject = new GameObject("_UiSound");
            sfxObject.transform.parent = transform;
            uiSfxPlayers = new AudioSource[channels];

            for (int i = 0; i < uiSfxPlayers.Length; i++)
            {
                uiSfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
                uiSfxPlayers[i].playOnAwake = false;
                uiSfxPlayers[i].volume = uiSfxVolume;
            }
        }

        public void PlayUiSFX(UiSfx sfx){
            for(int i = 0; i < uiSfxPlayers.Length; i++){
                int loopIndex = (i + channelIndex)%uiSfxPlayers.Length;
                
                if(uiSfxPlayers[loopIndex].isPlaying)
                    continue;

                    channelIndex = loopIndex;
                    uiSfxPlayers[loopIndex].clip = uiSfxClip[(int)sfx];
                    uiSfxPlayers[loopIndex].Play();
                    break;
            }        
        }
        public void StopUiSFX(UiSfx sfx){
            for(int i = 0; i < uiSfxPlayers.Length; i++){
                if(uiSfxPlayers[i].clip == uiSfxClip[(int)sfx] && uiSfxPlayers[i].isPlaying){
                    uiSfxPlayers[i].Stop();
                    break;
                }
            }
        }
    }
}