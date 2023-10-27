# libvlc player for Unity
Minimalistic libvlc player to be used inside Unity. (Mainly for playing rtmp/rtsp streams)

Note that the wrapper is partial and doesn't include options that assets in the
Asset store or https://code.videolan.org/videolan/vlc-unity/ offers.

### Requirements
-Unity 2021.3.17f1+ (might work with other ones, just not tested with)

-Win64 build target

-libvlc 3.0.19 (win64) (again, might work with other ones)

## Getting Started
1. Clone

2. Download or build libvlc (https://artifacts.videolan.org/vlc/release-win64/) and copy the contents into 'Assets/Plugins/x86_64/VLC/'

	The hierarchy of the 'Assets/Plugins/x86_64/VLC/' -folder should look like this:

		*/hrtfs

		*/locale

		*/lua

		*/plugins

		*/sdk

		*/skins

		*axvlx.dll

		*libvlc.dll

		*libvlccore.dll

Note! It is important to keep the libvlc's root folder named 'VLC' as in the cloned project.

3. Open Scenes/SampleScene or drop a VLCPlayerMono.cs to a gameobject and set a target RawImage.

Press play. (some url's will take a while to load before playing; i.e. rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov)

## VLC Player Mono
Monobehaviour component that plays a video and outputs the texture to a RawImage

### Raw Image
Render target

### Url
URL of the playable video/stream (eg. rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov)

### Width / Height
Width and height of the video to be played, configures the internal VLC-libraries to use these
dimensions. Can be left to 0 to automatically detect the dimensions and use them instead.

### Autoscale RawImage
Automatically scales the target rawimage to the aspect ratio of the video.
(Currently only tweaks the height to match the aspect ratio)

## Acknowledgments

* https://www.videolan.org/developers/vlc/doc/doxygen/html/group__libvlc.html

