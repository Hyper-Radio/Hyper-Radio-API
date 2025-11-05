using System.Diagnostics;

namespace Hyper_Radio_API.Services.UploadServices;

public class HlsConverterService
{
    
    //Configuration DI 
        private readonly string _ffmpegPath;

        public HlsConverterService(IConfiguration config)
        {
            _ffmpegPath = config["FFmpeg:ExecutablePath"];
            if (string.IsNullOrEmpty(_ffmpegPath))
                throw new Exception("FFmpeg path not configured");
        }

        
        //This method is for runnign the FFMPEG Conversion on an input, taking in inputFile path and an outputDir(folder that will be in blob)
        public async Task ConvertToHlsAsync(string inputFile, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            var args = $"-i \"{inputFile}\" -codec: copy -start_number 0 -hls_time 10 -hls_list_size 0 -f hls \"{Path.Combine(outputDir, "playlist.m3u8")}\"";

            var psi = new ProcessStartInfo
            {
                FileName = _ffmpegPath,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi) ?? throw new Exception("FFmpeg failed to start");
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                var err = await process.StandardError.ReadToEndAsync();
                throw new Exception($"FFmpeg failed: {err}");
            }
        }
    }

