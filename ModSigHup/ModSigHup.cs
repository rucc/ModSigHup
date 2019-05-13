using FreeSWITCH;
using FreeSWITCH.Native;

namespace ModSigHup
{
	public class ModSigHup : IApiPlugin
	{
		public void Execute(ApiContext context)
		{
			Execute();
			context.Stream.Write($"ApiDemo executed");
		}

		public void ExecuteBackground(ApiBackgroundContext context)
		{
			Execute();
			Log.WriteLine(LogLevel.Notice, $"ApiDemo executed");
		}

		public static void Execute()
		{
			var evt = new Event("TRAP", null);
			evt.AddHeader("Trapped-Signal", "HUP");
			evt.Fire();
		}
	}
}
