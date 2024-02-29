using FinancialBot.Application.Common.Services.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.Common;
using ZXing.ImageSharp;
using ZXing.QrCode;

namespace FinancialBot.Application.Common.Services;

public class QrReaderService : IQrReader
{
    public async Task<string> ScanAsync(Stream imageStream)
    {
        var image = await Image.LoadAsync<Rgba32>(imageStream);
        return ReadQrCode(image);
    }

    public string Scan(Stream imageStream)
    {
        var image = Image.Load<Rgba32>(imageStream);
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