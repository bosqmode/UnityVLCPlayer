using UnityEngine;

namespace bosqmode.libvlc
{
    public class VLCPlayerMono : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.RawImage m_rawImage;

        [SerializeField]
        private string url = "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";

        [SerializeField]
        [Min(1)]
        [Tooltip("Output resolution width")]
        private int width = 480;

        [SerializeField]
        [Min(1)]
        [Tooltip("Output resolution height")]
        private int height = 256;

        [SerializeField]
        [Tooltip("Mute")]
        private bool mute = true;

        private Texture2D tex;
        private VLCPlayer player;

        private void Start()
        {
            player = new VLCPlayer(width, height, url, !mute);
        }

        private void Update()
        {
            byte[] img;
            if (player != null && player.CheckForImageUpdate(out img))
            {
                if (tex == null)
                {
                    tex = new Texture2D(width, height, TextureFormat.RGB24, false, false);
                    m_rawImage.texture = tex;
                }

                tex.LoadRawTextureData(img);
                tex.Apply(false);
            }
        }

        private void OnDestroy()
        {
            player?.Dispose();
        }
    }
}