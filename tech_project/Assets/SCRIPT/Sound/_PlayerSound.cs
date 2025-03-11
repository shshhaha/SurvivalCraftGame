using UnityEngine;
namespace sound.playerSound
{
    public class _PlayerSound : MonoBehaviour
    {
        public static _PlayerSound instance;

        [Header("#PlayerSFX")]
        public AudioClip[] plyerSfxClip;
        public static float playerSfxVolume = 0.5f;
        public int channels;
        AudioSource []playerSfxPlayers;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum PlayerSfx {
            FootSand1,//0
            FootSand2,//1
            FootSand3,//2
            FootSand4,//3
            FootAspalt1,//4
            FootAspalt2,//5
            PlayerHit//6
            }
        void Awake(){
            instance = this;
            Init();
        }

        public void Init()
        {
            //효과음 플레이어 초기화
            GameObject sfxObject = new GameObject("_PlayerSound");
            sfxObject.transform.parent = transform;
            playerSfxPlayers = new AudioSource[channels];

            for (int i = 0; i < playerSfxPlayers.Length; i++)
            {
                playerSfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
                playerSfxPlayers[i].playOnAwake = false;
                playerSfxPlayers[i].volume = playerSfxVolume;
            }
        }

        public void PlayPlayerSFX(PlayerSfx sfx){
            for(int i = 0; i < playerSfxPlayers.Length; i++){
                int loopIndex = (i + channelIndex)%playerSfxPlayers.Length;
                
                if(playerSfxPlayers[loopIndex].isPlaying)
                    continue;

                    channelIndex = loopIndex;
                    playerSfxPlayers[loopIndex].clip = plyerSfxClip[(int)sfx];
                    playerSfxPlayers[loopIndex].Play();
                    break;
            }        
        }
        public void StopPlayerSFX(PlayerSfx sfx){
            for(int i = 0; i < playerSfxPlayers.Length; i++){
                if(playerSfxPlayers[i].clip == plyerSfxClip[(int)sfx] && playerSfxPlayers[i].isPlaying){
                    playerSfxPlayers[i].Stop();
                    break;
                }
            }
        }
    }
}