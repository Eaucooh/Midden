using System.Speech.Synthesis;

namespace Library.Voice
{
    public class Speech
    {
        private SpeechSynthesizer speecher = new SpeechSynthesizer();

        private int volumn { get; set; }

        private int rate { get; set; }

        public delegate void SpeakCompleted();

        public event SpeakCompleted Completed;

        /// <summary>
        /// 构造函数，生成Speech实例
        /// </summary>
        /// <param name="vol">音量 取值范围：0-100</param>
        /// <param name="rat">语速 取值范围：0-10</param>
        public Speech(int vol, int rat)
        {
            volumn = vol; rate = rat;
            speecher.SpeakCompleted += (x, y) => Completed();
        }

        /// <summary>
        /// 开始异步发言
        /// </summary>
        /// <param name="content">发言内容</param>
        public void Declaim(string content)
        {
            speecher = new SpeechSynthesizer()
            {
                Rate = rate,
                Volume = volumn
            };
            speecher.SpeakAsync(content);
        }

        /// <summary>
        /// 中止发言
        /// </summary>
        public void Abort()
        {
            try
            {
                speecher.SpeakAsyncCancelAll();
            }
            catch (System.Exception) { }
        }

        /// <summary>
        /// 暂停发言
        /// </summary>
        public void Pause() => speecher.Pause();

        /// <summary>
        /// 继续发言
        /// </summary>
        public void Continue() => speecher.Resume();

        /// <summary>
        /// 保存合成的语音
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="content">语音内容</param>
        public void Save(string path, string content)
        {
            Save_Path = path; Save_Content = content;
            new System.Threading.Thread(SaveAsync).Start();
        }

        private string Save_Path, Save_Content = null;

        /// <summary>
        /// 异步保存合成的语音
        /// </summary>
        private void SaveAsync()
        {
            try
            {
                speecher.SetOutputToWaveFile(Save_Path);
                speecher.Speak(new Prompt(Save_Content));
                speecher.SetOutputToDefaultAudioDevice();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 终结对象，释放资源
        /// </summary>
        public void Dispose() => speecher.Dispose();
    }
}
