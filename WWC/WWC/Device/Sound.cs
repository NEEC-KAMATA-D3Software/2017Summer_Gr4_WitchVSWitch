using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace WWC.Device
{
    class Sound
    {
        private ContentManager contentManager;

        private Dictionary<string, Song> bgms;
        private Dictionary<string, SoundEffect> soundEffects;
        private Dictionary<string, SoundEffectInstance> seInstances;
        private List<SoundEffectInstance> sePlayList;

        private string currentBGM;

        public Sound(ContentManager content)
        {
            contentManager = content;

            MediaPlayer.IsRepeating = true;

            bgms = new Dictionary<string, Song>();
            soundEffects = new Dictionary<string, SoundEffect>();
            seInstances = new Dictionary<string, SoundEffectInstance>();

            sePlayList = new List<SoundEffectInstance>();

            currentBGM = null;
        }

        private string ErrorMessage(string name)
        {
            return "再生する音データのアセット名(" + name + ")がありません\n"
                +
                "アセット名の確認、Dictionaryに登録されているか確認してください\n";
        }

        #region BGM関連処理
        public void LoadBGM(string name, string filepath = "./")
        {
            if (bgms.ContainsKey(name))
            {
                return;
            }
            bgms.Add(name, contentManager.Load<Song>(filepath + name));
        }

        /// <summary>
        /// BGM stop
        /// </summary>
        /// <returns></returns>
        public bool IsStoppedBGM()
        {
            return (MediaPlayer.State == MediaState.Stopped);
        }

        /// <summary>
        /// BGM play
        /// </summary>
        /// <returns></returns>
        public bool IsPlayingBGM()
        {
            return (MediaPlayer.State == MediaState.Playing);
        }

        /// <summary>
        /// BGM pause
        /// </summary>
        /// <returns></returns>
        public bool IsPausedBGM()
        {
            return (MediaPlayer.State == MediaState.Paused);
        }
        public void StopBGM()
        {
            MediaPlayer.Stop();
            currentBGM = null;
        }

        public void PlayBGM(string name)
        {
            Debug.Assert(bgms.ContainsKey(name), ErrorMessage(name));

            if (currentBGM == name)
            {
                return;
            }

            if (IsPlayingBGM())
            {
                StopBGM();
            }

            MediaPlayer.Volume = 0.5f;

            currentBGM = name;

            MediaPlayer.Play(bgms[currentBGM]);
        }
        /// <summary>
        /// BGMループフラグの変更
        /// </summary>
        public void ChangeBGMLoopFlag(bool loopFlag)
        {
            MediaPlayer.IsRepeating = loopFlag;
        }
        #endregion

        #region　WAV関連
        public void LoadSE(string name, string filepath = "./")
        {
            if (soundEffects.ContainsKey(name))
            {
                return;
            }


            soundEffects.Add(name, contentManager.Load<SoundEffect>(filepath + name));
        }

        public void CreateSEInstance(string name)
        {
            if (seInstances.ContainsKey(name))
            {
                return;
            }

            Debug.Assert(
                soundEffects.ContainsKey(name),
                "先に" + name + "の読み込み処理をしてください");

            seInstances.Add(name, soundEffects[name].CreateInstance());
        }

        public void PlaySE(string name)
        {
            Debug.Assert(soundEffects.ContainsKey(name), ErrorMessage(name));

            soundEffects[name].Play();
        }
        /// <summary>
        /// 単純SE再生
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loopFlag"></param>
        public void PlaySEInstance(string name, bool loopFlag = false)
        {
            Debug.Assert(soundEffects.ContainsKey(name), ErrorMessage(name));

            var data = seInstances[name];
            data.IsLooped = loopFlag;
            data.Play();
            sePlayList.Add(data);
        }
        /// <summary>
        /// sePlayListにある再生中の音を停止
        /// </summary>
        public void StoppedSE()
        {
            foreach (var se in sePlayList)
            {
                if (se.State == SoundState.Playing)
                {
                    se.Stop();
                }
            }
        }
        /// <summary>
        /// sePlayListにある再生中の音を一時停止
        /// </summary>
        /// <param name="name"></param>
        public void PausedSE(string name)
        {
            foreach (var se in sePlayList)
            {
                if (se.State == SoundState.Playing)
                {
                    se.Stop();
                }
            }
        }
        /// <summary>
        /// 停止している音の削除
        /// </summary>
        public void RemoveSE()
        {
            sePlayList.RemoveAll(se => (se.State == SoundState.Stopped));
        }
        #endregion

        /// <summary>
        /// 解放
        /// </summary>
        public void Unload()
        {
            bgms.Clear();
            soundEffects.Clear();
            sePlayList.Clear();
        }
    }
}