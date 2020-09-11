using System;
using System.Runtime.InteropServices;

/// <summary>
/// This is just a partial wrapper.
/// For more information, check: https://www.videolan.org/developers/vlc/doc/doxygen/html/group__libvlc.html
/// </summary>

namespace bosqmode.libvlc
{
    public enum libvlc_state_t
    {
        libvlc_NothingSpecial,
        libvlc_Opening,
        libvlc_Buffering,
        libvlc_Playing,
        libvlc_Paused,
        libvlc_Stopped,
        libvlc_Ended,
        libvlc_Error
    }

    public enum libvlc_track_type_t
    {
        libvlc_track_unknown = -1,
        libvlc_track_audio = 0,
        libvlc_track_video = 1,
        libvlc_track_text = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libvlc_media_track_t
    {
        public uint i_codec;
        public uint i_original_fourcc;
        public int i_id;
        public libvlc_track_type_t i_type;
        public int i_profile;
        public int i_level;
        public IntPtr media;
        public uint i_bitrate;
        public IntPtr psz_language;
        public IntPtr psz_description;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct libvlc_video_track_t
    {
        public uint i_height;
        public uint i_width;
        public uint i_sar_num;
        public uint i_sar_den;
        public uint i_frame_rate_num;
        public uint i_frame_rate_den;
        public uint i_orientation;
        public uint i_projection;
        public IntPtr pose;
        public uint i_multiview;
    }

    public delegate IntPtr LockCB(IntPtr opaque, ref IntPtr planes);
    public delegate void UnlockCB(IntPtr opaque, IntPtr picture, ref IntPtr planes);
    public delegate void DisplayCB(IntPtr opaque, IntPtr picture);

    public static class LibVLCWrapper
    {
        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_get_version();

        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_new(int argc, params string[] args);

        [DllImport("libvlc")]
        internal static extern void libvlc_release(IntPtr libvlc_instance);

        [DllImport("libvlc")]
        internal static extern int libvlc_media_tracks_get(IntPtr media, out IntPtr ppTracks);

        [DllImport("libvlc")]
        internal static extern void libvlc_media_tracks_release(IntPtr tracks, int i_count);

        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_media_player_new(IntPtr libvlc_instance);

        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_media_new_path(IntPtr libvlc_instance, char[] path);

        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_media_new_path(IntPtr libvlc_instance, string path);

        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_media_new_location(IntPtr libvlc_instance, string path);

        [DllImport("libvlc")]
        internal static extern libvlc_state_t libvlc_media_get_state(IntPtr media);

        [DllImport("libvlc")]
        internal static extern libvlc_state_t libvlc_media_player_get_state(IntPtr mediaPlayer);

        [DllImport("libvlc")]
        internal static extern IntPtr libvlc_media_player_new_from_media(IntPtr media);

        [DllImport("libvlc")]
        internal static extern void libvlc_media_player_pause(IntPtr mediaPlayer);

        [DllImport("libvlc")]
        internal static extern int libvlc_media_player_play(IntPtr mediaPlayer);

        [DllImport("libvlc")]
        internal static extern Int64 libvlc_media_get_duration(IntPtr media);

        [DllImport("libvlc")]
        internal static extern Int64 libvlc_media_player_get_time(IntPtr mediaPlayer);

        [DllImport("libvlc")]
        internal static extern void libvlc_media_player_release(IntPtr mediaPlayer);

        [DllImport("libvlc")]
        internal static extern void libvlc_media_release(IntPtr media);

        [DllImport("libvlc")]
        internal static extern void libvlc_media_player_set_media(IntPtr mediaPlayer, IntPtr media);

        [DllImport("libvlc")]
        internal static extern void libvlc_video_set_format(IntPtr mediaPlayer, string chroma, uint width, uint height, uint pitch);

        [DllImport("libvlc")]
        internal static extern void libvlc_video_set_callbacks(IntPtr mediaPlayer, LockCB _lock, UnlockCB _unlock, DisplayCB _display, IntPtr _opaque);

        [DllImport("libvlc")]
        internal static extern bool libvlc_media_player_is_playing(IntPtr mediaPlayer);

        [DllImport("libvlc")]
        internal static extern void libvlc_media_player_set_pause(IntPtr mediaPlayer, int do_pause);
    }

}