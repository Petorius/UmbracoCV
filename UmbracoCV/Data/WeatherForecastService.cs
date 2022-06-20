using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UmbracoCV.Data
{
    public class WeatherForecastService
    {

        //Should be Rest API call instead - disregard..
        public Task<string> GetForecastAsync(string locationName)
        {
            
            using (WebClient webClient = new WebClient())
            {
                string content = webClient.DownloadString($"http://api.weatherapi.com/v1/current.json?key=f09893e4dde14709b21135320221806&q=" + locationName + "&aqi=yes");

                string regexPattern = $"\"text\": (\".*?\")";
                Regex regex = new Regex(regexPattern);
                string weatherDescription = regex.Matches(content).ToString();

                return Task.FromResult(weatherDescription);
            }
        }
    }
}