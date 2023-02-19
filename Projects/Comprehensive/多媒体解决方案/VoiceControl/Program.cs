using System;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace VoiceControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (
               SpeechRecognitionEngine recognizer =
                 new SpeechRecognitionEngine(
                   new System.Globalization.CultureInfo("zh-CN")))
            {
                Choices choices = new Choices(new string[] { "上", "下", "上一页", "下一页" });
                GrammarBuilder gb = new GrammarBuilder(choices);

                // Create and load a dictation grammar.  
                recognizer.LoadGrammar(new Grammar(gb));

                // Add a handler for the speech recognized event.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.  
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open.  
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        public static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
            if (e.Result.Text.IndexOf("上") != -1 || e.Result.Text.IndexOf("返回") != -1)
                SendKeys.SendWait("{UP}");
            else if (e.Result.Text.IndexOf("下") != -1 || e.Result.Text.IndexOf("前进") != -1)
                SendKeys.SendWait("{DOWN}");
        }
    }
}
