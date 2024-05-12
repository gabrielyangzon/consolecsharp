

using System.Security.Cryptography.X509Certificates;

var cert = new X509Certificate2(@"C:\Users\admin\RiderProjects\cert\client.pfx", "1234");
var handler = new HttpClientHandler();
handler.ClientCertificates.Add(cert);
var client = new HttpClient(handler);

var request = new HttpRequestMessage()
{
    RequestUri = new Uri("https://localhost:7033/api/Test"),
    Method = HttpMethod.Get,
};
var response = await client.SendAsync(request);
if (response.IsSuccessStatusCode)
{
    var responseContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent);
}
else
{
    Console.WriteLine(response.ReasonPhrase);
}



//Enumerable.Range(100,5).Reverse().Print();

public static class IEnumerableExtensions
{
    public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
    {
        var arr = source.ToArray();
        Random rnd = new Random();

        
        for (var i = arr.Length-1; i > -1; i--)
        {
            yield return arr[i];    
        }

       
    }

    public static void Print<T>(this IEnumerable<T> source)
    {
        var arr = source.ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
             Console.WriteLine(arr[i]);
        }

    }
}

