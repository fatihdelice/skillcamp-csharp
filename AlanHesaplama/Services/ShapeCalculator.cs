using AlanHesaplama.Enums;

namespace AlanHesaplama.Services
{
    public class ShapeCalculator
    {
        public double AlanHesapla(ShapeType sekil, double[] kenarlar)
        {
            switch (sekil)
            {
                case ShapeType.Daire:
                    return Math.PI * Math.Pow(kenarlar[0], 2);

                case ShapeType.Ucgen:
                    double yariCevre =
                        (kenarlar[0] + kenarlar[1] + kenarlar[2]) / 2;

                    return Math.Sqrt(
                        yariCevre *
                        (yariCevre - kenarlar[0]) *
                        (yariCevre - kenarlar[1]) *
                        (yariCevre - kenarlar[2])
                    );

                case ShapeType.Kare:
                    return Math.Pow(kenarlar[0], 2);

                case ShapeType.Dikdortgen:
                    return kenarlar[0] * kenarlar[1];

                default:
                    throw new ArgumentException(
                        "Bu sekil icin alan hesaplanamaz!"
                    );
            }
        }

        public double CevreHesapla(ShapeType sekil, double[] kenarlar)
        {
            switch (sekil)
            {
                case ShapeType.Daire:
                    return 2 * Math.PI * kenarlar[0];

                case ShapeType.Ucgen:
                    return kenarlar[0] + kenarlar[1] + kenarlar[2];

                case ShapeType.Kare:
                    return 4 * kenarlar[0];

                case ShapeType.Dikdortgen:
                    return 2 * (kenarlar[0] + kenarlar[1]);

                default:
                    throw new ArgumentException(
                        "Bu sekil icin cevre hesaplanamaz!"
                    );
            }
        }

        public double HacimHesapla(ShapeType sekil, double[] kenarlar)
        {
            switch (sekil)
            {
                case ShapeType.Kup:
                    return Math.Pow(kenarlar[0], 3);

                case ShapeType.DikdortgenlerPrizmasi:
                    return kenarlar[0] * kenarlar[1] * kenarlar[2];

                default:
                    throw new ArgumentException(
                        "Bu sekil icin hacim hesaplanamaz!"
                    );
            }
        }

        public bool HesaplamaDestekleniyor(
            ShapeType sekil,
            MeasurementType olcu)
        {
            if (olcu == MeasurementType.Hacim)
            {
                return sekil == ShapeType.Kup ||
                       sekil == ShapeType.DikdortgenlerPrizmasi;
            }

            return sekil == ShapeType.Daire ||
                   sekil == ShapeType.Ucgen ||
                   sekil == ShapeType.Kare ||
                   sekil == ShapeType.Dikdortgen;
        }
    }
}