namespace Festifact.Web
{
    public class Constants
    {

        public static string Scheme = "https"; // or http
        public static string Port = "5001";
        public static string RestUrl = $"{Scheme}://localhost:{Port}/api/{{0}}/{{1}}";
    }
}
