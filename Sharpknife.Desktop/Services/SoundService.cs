using System.IO;
using System.Media;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a sound service to play sounds.
	/// </summary>
	public sealed class SoundService
	{
		private SoundService()
		{

		}

		/// <summary>
		/// Plays the sound at the specified path.
		/// </summary>
		/// <param name="path">the path</param>
		public void Play(string path)
		{
			var player = new SoundPlayer();

			using (var stream = File.Open(path, FileMode.Open))
			{
				player.Stream = stream;
				player.Play();
			}
		}

		/// <summary>
		/// Plays the specified system sound.
		/// </summary>
		/// <param name="sound">the sound</param>
		public void Play(SystemSound sound)
		{
			sound.Play();
		}

		/// <summary>
		/// Gets the instance of the sound service.
		/// </summary>
		public static SoundService Instance => SoundService.instance;

		private static readonly SoundService instance = new SoundService();
	}
}
