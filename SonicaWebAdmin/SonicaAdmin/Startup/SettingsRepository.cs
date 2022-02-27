using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using SLog;
using YamlDotNet.Serialization;

namespace Sonica.Admin.Pages.StartupPage
{
    public class AdminSettings
    {
        [YamlMember(Alias = "Port", ApplyNamingConventions = false)]
        public int Port { get; set; }

        [YamlMember(Alias = "MaxWaitExecuteTimeOut", ApplyNamingConventions = false)]
        public int MaxAwaitTimeOutInMs { get; set; }

        [YamlMember(Alias = "FrequencyOfReadingMetrics", ApplyNamingConventions = false)]
        public int MetricFrequenceInMs { get; set; }

        [YamlMember(Alias = "LastIpAddresses", ApplyNamingConventions = false)]
        public List<string> IpAddresses { get; set; }

        public AdminSettings()
        {
            Port                = 17177;
            MaxAwaitTimeOutInMs = 90000;
            MetricFrequenceInMs = 1000;
            IpAddresses         = new List<string>();
        }
        
        public AdminSettings(int port, int maxAwaitTimeOut, int metricFrequence)
        {
            Port                = port;
            MaxAwaitTimeOutInMs = maxAwaitTimeOut;
            MetricFrequenceInMs = metricFrequence;
            IpAddresses         = new List<string>();
        }

        public static AdminSettings UseDefault()
            => new AdminSettings(17177, 90_000, 1000);
    }

    public class SettingsRepository
    {
        private const string DefaultIpAddress = "172.16.29.1";
        private const string SettingsFileName = "Settings";
        
        private readonly AdminSettings _settings;
        
        public SettingsRepository()
        {
            _settings = GetSettings();
        }
        
        public void SetLastIpAddress(IPAddress ipAddress)
        {
            Log.Info(nameof(SettingsRepository), "SetLastIpAddress");
            _settings.IpAddresses.Add(ipAddress.ToString());
            SetSettings(_settings);
        }

        public IPAddress GetLastIpAddress()
        {
            Log.Info(nameof(SettingsRepository), "GetLastIpAddress");

            var lastIpAddress = _settings.IpAddresses.LastOrDefault();
            if (lastIpAddress == null)
                return IPAddress.Parse(DefaultIpAddress);

            return !IPAddress.TryParse(lastIpAddress, out var result) 
                ? IPAddress.Parse(DefaultIpAddress) : result;
        }

        public void SetMainSettings(int port, int maxAwaitTimeOut, int metricFrequence)
        {
            _settings.Port                = port;
            _settings.MaxAwaitTimeOutInMs = maxAwaitTimeOut;
            _settings.MetricFrequenceInMs = metricFrequence;
            SetSettings(_settings);
        }
        
        public void SetSettings(AdminSettings settings)
        {
            using (var streamWriter = new StreamWriter(GetSettingsPath()))
            {
                var serializer = new Serializer();
                serializer.Serialize(streamWriter, settings);
            }
        }

        public AdminSettings GetSettings()
        {
            try
            {
                var settingsLocation = GetSettingsPath();
                if(!File.Exists(settingsLocation))
                    throw new InvalidOperationException($"Settings not found by {settingsLocation}");
            
                Log.Info($"Read settings from {settingsLocation}");
            
                var input = File.ReadAllText(settingsLocation);
                var deserializer = new DeserializerBuilder().Build();
                var serverSettings = deserializer.Deserialize<AdminSettings>(input);
                return serverSettings;
            }
            catch (Exception e)
            {
                Log.Error($"Fail read settings from file. {e}");
                return AdminSettings.UseDefault();
            }
        }
        
        private string GetSettingsPath()
        {
            Log.Info(nameof(SettingsRepository), "GetSettingsPath");
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SettingsFileName);
        }
    }
}
