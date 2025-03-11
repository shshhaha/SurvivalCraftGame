using UnityEngine;

namespace sound.monsterSound
{
    public class _MonsterSound : MonoBehaviour
    {
        public static _MonsterSound instance;

        [Header("#MonsterSFX")]
        public AudioClip[] monsterSfxClip;
        public static float monsterSfxVolume = 0.5f;
        public int channels;
        AudioSource []monsterSfxPlayers;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum MonsterSfx {
            ZombiHit
            }
        void Awake(){
            instance = this;
            Init();
        }

        public void Init()
        {
            //효과음 플레이어 초기화
            GameObject sfxObject = new GameObject("_MonsterSound");
            sfxObject.transform.parent = transform;
            monsterSfxPlayers = new AudioSource[channels];

            for (int i = 0; i < monsterSfxPlayers.Length; i++)
            {
                monsterSfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
                monsterSfxPlayers[i].playOnAwake = false;
                monsterSfxPlayers[i].volume = monsterSfxVolume;
            }
        }

        public void PlayMonsterSFX(MonsterSfx sfx){
            for(int i = 0; i < monsterSfxPlayers.Length; i++){
                int loopIndex = (i + channelIndex)%monsterSfxPlayers.Length;
                
                if(monsterSfxPlayers[loopIndex].isPlaying)
                    continue;

                    channelIndex = loopIndex;
                    monsterSfxPlayers[loopIndex].clip = monsterSfxClip[(int)sfx];
                    monsterSfxPlayers[loopIndex].Play();
                    break;
            }        
        }
        public void StopMonsterSFX(MonsterSfx sfx){
            for(int i = 0; i < monsterSfxPlayers.Length; i++){
                if(monsterSfxPlayers[i].clip == monsterSfxClip[(int)sfx] && monsterSfxPlayers[i].isPlaying){
                    monsterSfxPlayers[i].Stop();
                    break;
                }
            }
        }
    }
}
