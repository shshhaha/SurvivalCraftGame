using UnityEngine;
namespace sound.MainTitleBGM
{
    public class MainTitleBGM : MonoBehaviour
    {
        public static MainTitleBGM instance;

        [Header("#BGM")]
        public AudioClip[] BGMClip;
        public static float BGMVolume = 0.4f;
        public int channels;
        AudioSource []BGM;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum BGMList {
            MainTitleBGM1,
        }
        void Awake(){
            instance = this;
            Init();
        }

        public void Init()
        {
            //효과음 플레이어 초기화
            GameObject bgmObject = new GameObject("BGM");
            bgmObject.transform.parent = transform;
            BGM = new AudioSource[channels];

            for (int i = 0; i < BGM.Length; i++)
            {
                BGM[i] = bgmObject.AddComponent<AudioSource>();
                BGM[i].playOnAwake = false;
                BGM[i].volume = BGMVolume;
            }
        }

        public void PlayBGM(BGMList bgm){
            for(int i = 0; i < BGM.Length; i++){
                int loopIndex = (i + channelIndex)%BGM.Length;
                
                if(BGM[loopIndex].isPlaying)
                    continue;

                    channelIndex = loopIndex;
                    BGM[loopIndex].clip = BGMClip[(int)bgm];
                    BGM[loopIndex].Play();
                    break;
            }        
        }
        public void StopBGM(BGMList bgm){
            for(int i = 0; i < BGM.Length; i++){
                if(BGM[i].clip == BGMClip[(int)bgm] && BGM[i].isPlaying){
                    BGM[i].Stop();
                    break;
                }
            }
        }

        public bool IsBGMPlaying(BGMList bgm)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                if (BGM[i].clip == BGMClip[(int)bgm] && BGM[i].isPlaying)
                {
                    return true;
                }
            }
            return false;
        }

        public void PlayBGMLoop(BGMList bgm)
        {
            for(int i = 0; i < BGM.Length; i++)
            {
                int loopIndex = (i + channelIndex) % BGM.Length;
        
                if(BGM[loopIndex].isPlaying)
                    continue;
        
                channelIndex = loopIndex;
                BGM[loopIndex].clip = BGMClip[(int)bgm];
                BGM[loopIndex].loop = true; // loop property set to true
                BGM[loopIndex].Play();
                break;
            }
        }

    }
}

