using System.Drawing;
using FinancialBot.Application.Telegram.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.ImageSharp;

namespace FinancialBot.Application.Telegram.Services;

public class QrReaderService : IQrReader
{
    public async Task<string> ScanAsync(Stream imageStream)
    {
        Image<Rgba32> image = await SixLabors.ImageSharp.Image.LoadAsync<Rgba32>(imageStream);
        return ReadQrCode(image);
    }

    public string Scan(Stream imageStream)
    {
        Image<Rgba32> image =  SixLabors.ImageSharp.Image.Load<Rgba32>(imageStream);
        return ReadQrCode(image);
    }

    private string ReadQrCode(Image<Rgba32> image)
    {
        var luminanceSource = new ImageSharpLuminanceSource<Rgba32>(image);

        var bitmap = new BinaryBitmap(new HybridBinarizer(luminanceSource));
        var reader = new QRCodeReader();
        var result = reader.decode(bitmap);
        return result?.Text ?? string.Empty;
    }
}