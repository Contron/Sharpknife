using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a sound service to play sounds.
	/// </summary>
	public class SoundService
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
		/// Gets the instance of the sound service.
		/// </summary>
		public static SoundService Instance
		{
			get
			{
				return SoundService.instance;
			}
		}

		private static readonly SoundService instance = new SoundService();
	}
}
