using ZXing;
using ZXing.Common;
using ZXing.ImageSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BarcodeApp.Services
{
    public class BarcodeService
    {
        private readonly string _barcodeDirectory;

        public BarcodeService()
        {
            _barcodeDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Barcodes"
            );

            Directory.CreateDirectory(_barcodeDirectory);
        }

        public string BarkodOlustur(string metin)
        {
            BarcodeWriter<Rgba32> writer = new BarcodeWriter<Rgba32>
            {
                Format = BarcodeFormat.CODE_128,

                Options = new EncodingOptions
                {
                    Width = 400,
                    Height = 150,
                    Margin = 10,
                    PureBarcode = false
                }
            };

            using var barcodeImage = writer.Write(metin);

            string fileName =
                $"Barcode_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";

            string filePath = Path.Combine(
                _barcodeDirectory,
                fileName
            );

            barcodeImage.Save(filePath);

            return filePath;
        }

        public string? BarkodOku(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            using Image<Rgba32> image = Image.Load<Rgba32>(filePath);

            BarcodeReader<Rgba32> reader =
                new BarcodeReader<Rgba32>();

            var result = reader.Decode(image);

            return result?.Text;
        }

        public string BarkodKlasoruGetir()
        {
            return _barcodeDirectory;
        }
    }
}