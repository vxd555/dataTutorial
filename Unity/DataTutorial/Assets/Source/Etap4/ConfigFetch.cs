using System;
using System.Collections.Generic;
using UnityEditor;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

public class ConfigFetch : EditorWindow
{
	public string adress = "https://docs.google.com/spreadsheets/d/";
	public string sheetID = "1_SA-atxoZx1r8a3kMdEc0NReqhFMkarsSHEMhrXXd9w";

	private static SheetsService service = null;
	private Queue<Action> dispatchedActions = new();
	private static Dictionary<Spreadsheet, List<Sheet>> googleTabs = null;
	private static List<string> tabNames = null;



	[MenuItem("Tools/Config Fetch")]
	private static void OpenWindow()
	{
		var wnd = GetWindow<ConfigFetch>("Config Fetch");
		wnd.Show();
	}

	private void FetchNewTabsFromSheet(Task<Spreadsheet> task)
	{
		string sheetID = task.Result.SpreadsheetId;
		List<Sheet> sheets = null;
		if(!googleTabs.TryGetValue(task.Result, out sheets))
			googleTabs.Add(task.Result, sheets = new List<Sheet>());
		sheets.AddRange(task.Result.Sheets);

		tabNames.AddRange(task
			.Result
			.Sheets
			.Select(s => $"{s.Properties.Title}")
		);

		Debug.Log(tabNames.ToArray().ToString());
	}

	/*private void GenerateJSON(CCCEntry entry, Action onComplete = null)
	{
		if(googleTabs == null)
		{
			ForceDownloadSheetData(() => {
				GenerateJSON(entry, onComplete);
			});
			return;
		}

		EditorUtility.DisplayProgressBar(
			"Downloading...",
			$"Downloading data of {entry.tabName}...",
			0.3f
		);

		var split = entry.tabName.Split("/", 2);
		var cat = split[0].ToLower();
		var name = split[1];

		var entryToProcess = entry;
		var completeAction = onComplete;
		service.Spreadsheets.Values
			.Get(sheetID, name)
			.ExecuteAsync()
			.ContinueWith(t => dispatchedActions.Enqueue(() =>
				ProcessEntry(t, entryToProcess, sheetID, completeAction)
			));
	}*/

	private void ForceDownloadSheetData(Action onComplete = null)
	{
		service = null;
		googleTabs = null;
		DownloadSheetData(onComplete);
	}

	private void DownloadSheetData(Action onComplete = null)
	{
		dispatchedActions.Enqueue(() => {
			EditorUtility.DisplayProgressBar(
				"Downloading...",
				$"Downloading metadata from Google Sheets...",
				0.0f
			);
		});
		if(service == null)
			service = GetSheetsService();

		googleTabs = new();
		tabNames = new();

		dispatchedActions.Enqueue(() => {
			EditorUtility.DisplayProgressBar(
				"Downloading...",
				$"Downloading metadata from Google Sheets...",
				0.2f
			);
		});

		var sprd = service?.Spreadsheets;
		if(sprd == null)
		{
			Debug.LogError("Google services error!");
			EditorUtility.ClearProgressBar();
			return;
		}
		sprd
			.Get(sheetID)
			.ExecuteAsync()
			.ContinueWith(_t => FetchNewTabsFromSheet(_t))
			.ContinueWith(t => {
				Debug.Log("[Google] Sheet downloaded!");
				dispatchedActions.Enqueue(() => {
					EditorUtility.DisplayProgressBar(
						"Downloading...",
						$"Downloading metadata from Google Sheets: Static...",
						0.6f
					);
				});
			});
	}

	private static SheetsService GetSheetsService()
	{
		using(var stream = new FileStream("Assets/google-credentials.json", FileMode.Open, FileAccess.Read))
		{
			var serviceInitializer = new BaseClientService.Initializer
			{
				HttpClientInitializer = GoogleCredential.FromStream(stream).CreateScoped(
					new[] { SheetsService.Scope.Spreadsheets }
				)
			};
			return new SheetsService(serviceInitializer);
		}
	}
}
