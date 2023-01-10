using System.Diagnostics;
using System.Xml;

public class Program
{
    private static CancellationTokenSource _cts = new CancellationTokenSource();

    static readonly HttpClient _httpClient = new HttpClient()
    {
        MaxResponseContentBufferSize = 1_000_000
    };
    static readonly List<string> s_url = new List<string>()
    {
       "https://www.hepsiburada.com/apple-tv-4k-64gb-mxh02tz-a-p-HBCV0000050HHD?magaza=Hepsiburada",
        "https://www.hepsiburada.com/xiaomi-mi-robot-vacuum-mop-2-robot-supurge-ve-paspas-beyaz-p-HBCV00001OHNU7",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b",
        "https://www.hepsiburada.com/fifine-ampligame-a6v-yayinci-oyuncu-podcast-youtuber-rgb-usb-mikrofon-p-hbcv00002lv30b"
    };


    public async static Task Main(string[] args)
    {
        //zaman uyumsuz işlemleri iptal edebilme
        Console.WriteLine("uygulama başladı");
        Console.WriteLine("Enter tuşuna basılarak işlemi iptal edebilirsiniz");

        Task canselTask = Task.Run(() =>
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Enter tuşuna basarak işlem iptali sağlanabilir.");
            }
            Console.Clear();
            Console.WriteLine("İşlem iptal edildi.");
            _cts.Cancel();
        });

        Task sumPageSize=SumPageSizeAsync();
        await Task.WhenAny(new[] { canselTask, sumPageSize });

        Console.WriteLine("Uygulama Sonlandı");
        Console.ReadKey();

    }

    static async Task SumPageSizeAsync()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        int total = 0;

        foreach (var url in s_url)
        {
            int contentLength = await ProcessUrlAsync(url, _httpClient, _cts.Token);
            total += contentLength;
            await Task.Delay(1000);
        }
        stopwatch.Stop();
        Console.WriteLine($"Url Toplam Content {total: #,#}");
        Console.WriteLine($"Geçen süre: {stopwatch.Elapsed}");
    }

    static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await client.GetAsync(url, cancellationToken); //request oluşturuyor.
        byte[] content = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        Console.WriteLine($"{url} {content.Length}");
        return content.Length;
    }
}