using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SpeedTestApi.Models
{
    public class TestResult
    {
        [Required]
        [JsonProperty("user")]
        [StringLength(500, MinimumLength = 2)]
        public string User { get; set; }

        [Required]
        [JsonProperty("device")]
        [Range(1, int.MaxValue)]
        public int Device { get; set; }

        [Required]
        [JsonProperty("timestamp")]
        [Range(0, long.MaxValue)]
        public long Timestamp { get; set; }

        [Required]
        [JsonProperty("data")]
        public TestData Data { get; set; }
    }

    public class TestData
    {
        [Required]
        [JsonProperty("speeds")]
        public TestSpeeds Speeds { get; set; }

        [Required]
        [JsonProperty("client")]
        public TestClient Client { get; set; }

        [Required]
        [JsonProperty("server")]
        public TestServer Server { get; set; }
    }

    public class TestSpeeds
    {
        [Required]
        [JsonProperty("download")]
        [Range(0, 3000)]
        public double Download { get; set; }

        [Required]
        [JsonProperty("upload")]
        [Range(0, 3000)]
        public double Upload { get; set; }
    }

    public class TestClient
    {
        [Required]
        [JsonProperty("ip")]
        [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")]
        public string Ip { get; set; }

        [JsonProperty("lat")]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [JsonProperty("isp")]
        [StringLength(500, MinimumLength = 2)]
        public string Isp { get; set; }

        [Required]
        [JsonProperty("country")]
        [RegularExpression(@"^([A-Z]){2}$")]
        public string Country { get; set; }
    }

    public class TestServer
    {
        [Required]
        [JsonProperty("host")]
        [StringLength(500, MinimumLength = 2)]
        public string Host { get; set; }

        [Required]
        [JsonProperty("lat")]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [JsonProperty("lon")]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [JsonProperty("country")]
        [RegularExpression(@"^([A-Z]){2}$")]
        public string Country { get; set; }

        [Required]
        [JsonProperty("distance")]
        [Range(0, 21000000)]
        public double Distance { get; set; }

        [Required]
        [JsonProperty("ping")]
        [Range(0, int.MaxValue)]
        public int Ping { get; set; }

        [Required]
        [JsonProperty("id")]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
    }
}
