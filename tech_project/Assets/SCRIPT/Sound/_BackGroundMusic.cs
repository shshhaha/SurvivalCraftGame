using UnityEngine;
namespace sound.backGroundSound
{
    public class _backGroundSound : MonoBehaviour
    {
        public static _backGroundSound instance;

        [Header("#BGM")]
        public AudioClip[] BGMClip;
        public static float BGMVolume = 0.5f;
        public int channels;
        AudioSource []BGM;
        int channelIndex;

        //이곳에 사용할 사운드를 지정
        public enum BGMList {
            wind,
            after20_1,
            after20_2,
            after20_3,
            after20_4,
            GameIntro,
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

        public void StopPlayingAllThisBGMList()
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                if (BGM[i].isPlaying)
                {
                    BGM[i].Stop();
                    break;
                }
            }
        }


        public void PlayBGMLoop(BGMList bgm)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                int loopIndex = (i + channelIndex) % BGM.Length;
        
                if (BGM[loopIndex].isPlaying)
                    continue;
        
                channelIndex = loopIndex;
                BGM[loopIndex].clip = BGMClip[(int)bgm];
                BGM[loopIndex].loop = true; // Set loop to true
                BGM[loopIndex].Play();
                break;
            }
        }

        //정해진 범위 내에서 랜덤으로 BGM을 재생
        public void PlayRandomBGM(int StartIndex, int EndIndex)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                int loopIndex = (i + channelIndex) % BGM.Length;
        
                if (BGM[loopIndex].isPlaying)
                    continue;
        
                channelIndex = loopIndex;
                int randomBgmIndex = Random.Range(StartIndex, EndIndex);
                BGM[loopIndex].clip = BGMClip[randomBgmIndex];
                BGM[loopIndex].loop = true;
                BGM[loopIndex].Play();
                break;
            }
        }


    }
}

