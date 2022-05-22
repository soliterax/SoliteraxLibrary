namespace SoliteraxLibrary
{
    class Faktoriyel
    {

        public int faktoriyel_hesapla(int sayi)
        {
            int i = 1;
            sayi++;
            int toplam = 1;
            while (i < sayi)
            {

                toplam *= i;
                i++;

            }
            return toplam;

        }

    }
}
