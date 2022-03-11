using SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Contract
{
	/// <summary>
	/// Интерфейс контракта по управлению приложением
	/// </summary>
	public interface IServerApiContract
	{
		//#region Basics [2000-2070]

		//[TntMessage(2005)] bool SetGack(byte[] zippedGackFolder, string name);
		//[TntMessage(2010)] FilePdu GetGack();
		//[TntMessage(2015)] ProjectInfo GetGackInfo();
		//[TntMessage(2020)] SystemInfo GetSystemInfo();
		//[TntMessage(2025)] Action<int> ProjectStateChanged { get; set; }
		void RestartApplicationAndForget();
		bool RestartApplicationAndThrow();
		//[TntMessage(2040)] bool SetNetworkSettings(NetworkSettings settings);
		//[TntMessage(2045)] NetworkSettings GetNetworkSettings();
		//[TntMessage(2050)] ConnectionSettings GetConnectionSettings();
		LoginResult TryLogIn(string userName, string password);
		//[TntMessage(2060)] Permissions GetPermissions();
		//[TntMessage(2065)] DeviceMetrics GetMetrics(DeviceMetricsType metricsType);
		
		//#endregion

		//#region Logger  [2069-2075]

		//[TntMessage(2069)] bool DropLogs();
		//[TntMessage(2070)] FilePdu GetLogArchive();
		//[TntMessage(2071)] DumpInformationPdu RunTcpDump(DumpArgumentsPdu arguments);
		//[TntMessage(2072)] DumpInformationPdu StopTcpDump();
		//[TntMessage(2073)] DumpInformationPdu GetTcpDumpStatus();

		//#endregion
		
		//#region Software Update [2075-2099]

		//[TntMessage(2075)] UpdatePermission TryGetPermissionToUpdate(SoftwareVersion version, SoftwareFileInfo info);

		//[TntMessage(2080)] SavePartResult TrySendPartOfUpdate(PartOfUpdate partOfUpdate);
		
		//[TntMessage(2085)] VerifyResult TryVerifySoftwarePackage();

		//[TntMessage(2090)] RollBackResult TryRollBackUpdate();

		//#endregion
		
		//#region Parameterization [2100-2199]

		//[TntMessage(2110)] SetParametersResult SetParameters(ParametersContainer settings);
		//[TntMessage(2115)] ParametersContainer  GetParameters();

		//#endregion
		
		//#region File sources [2200-2299]

		//[TntMessage(2210)] CoreFilesListDto GetAllFileSourceInfos();
		//[TntMessage(2211)] CoreFilesListDto GetAllFileSourceInfos(CoreFilesFilterDto filterDto);
		//[TntMessage(2212)] CoreFilePortionDto InitializeDownload(string blockPath, string fileId);
		//[TntMessage(2214)] CoreFilePortionDto GetNextPortion(int downloadId);
		//[TntMessage(2216)] bool CancelFileOperation(int id); 
		//[TntMessage(2218)] bool ClearFile(string blockPath, string fileId);
		
		//[TntMessage(2220)] UploadPortionResultDto InitializeUpload(CoreFilePortionDto filePortion);
		//[TntMessage(2222)] UploadPortionResultDto SetNextPortion(CoreFilePortionDto filePortion);


		//#endregion

		//#region Linux System Time [2300-2350] 

		//[TntMessage(2300)] TimeSettingResult SetLinuxSystemTime(TimeSetting setting);
		//[TntMessage(2302)] TimeSettingResult GetLinuxSystemTime(TimeSetting setting);

		//#endregion

		//#region OEM [2350-2365]

		//[TntMessage(2350)] RequestKeyPdu GetRequestKey();
		//[TntMessage(2352)] ResponseKeyResultPdu SetResponseKey(ResponseKeyPdu key);
		//[TntMessage(2354)] LicenseInfoPdu GetLicenseInformation();

		//#endregion


		//[TntMessage(2370)] GetWorkModePdu GetCoreRunMode();

		//[TntMessage(2372)] SetResultRunModePdu SetCoreRunMode(SetWorkModePdu workModePdu);
		
	}
}
