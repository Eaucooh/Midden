# 简易视频播放器源码

## 源码特点

一款视频播放器源码，视频控制：播放、暂停、停止、后退、快进、跳转、适合初学者

## 菜单功能

创建MediaElement媒体控件
```csharp
MediaElement mediaElement = new MediaElement();
```
设置视频路径
```csharp
mediaElement.Source = new Uri(视频路径, UriKind.Relative);
```
当不播放音频或视频时触发事件
```csharp
mediaElement.MediaEnded += new RoutedEventHandler(mediaElement_MediaEnded);
private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
{
    mediaElement.Stop();
}
```
当播放音频或视频或是存在播放文件时触发事件，一般用于获取总时长
```csharp
mediaElement.MediaOpened += new RoutedEventHandler(mediaElement_MediaOpened);
private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
{
    duration = mediaElement.NaturalDuration.HasTimeSpan ? mediaElement.NaturalDuration.TimeSpan : TimeSpan.FromMilliseconds(0);
}
```
视频总时长
```csharp
duration = mediaElement.NaturalDuration.HasTimeSpan ? mediaElement.NaturalDuration.TimeSpan : TimeSpan.FromMilliseconds(0);
```
暂停
```csharp
mediaElement.Pause();
```
停止
```csharp
mediaElement.Stop();
```
静音
```csharp
mediaElement.IsMuted = false;
```
有声
```csharp
mediaElement.IsMuted = true;
```
设置后退播放10秒钟
```csharp
mediaElement.Position = mediaElement.Position - TimeSpan.FromSeconds(10);
```
设置快进播放10秒钟
```csharp
mediaElement.Position = mediaElement.Position + TimeSpan.FromSeconds(10);
```
设置跳转到指定秒数播放视频
```csharp
mediaElement.Position = new TimeSpan((new DateTime(0, 0, 0, 0, 0, 0)).Ticks);
mediaElement.Play();
```
获取当前视频的时间
```csharp
string b = mediaElement.Position.ToString().Substring(0, 8);
```
当前转为计数器
```csharp
string[] videotime = b.Split(':');
int totime = int.Parse(videotime[0]) * 3600 + int.Parse(videotime[1]) * 60 + int.Parse(videotime[2]);
text.Text = totime.ToString();
```
自定义计数器
```csharp
text.Text = string.Format("{0}{1:00}:{2:00}:{3:00}", "播放进度：", mediaElement.Position.Hours, mediaElement.Position.Minutes, mediaElement.Position.Seconds);
```

## 注意事项
开发环境为Visual Studio 2013，使用.net 4.0开发。


