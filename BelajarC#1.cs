using System;
using System.Collections.Generic;

namespace KerangkaGame
{
    class Karakter
    {
        public int total, power;

        // Encapsulation
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }
        public int healing { get; private set; }
        public int posisiAwal { get; private set; }   
        public int posisiSaatIni { get; private set; }

        // Constructor
        public Karakter(string nama, int kesehatan, int senjata, int healing = 0, int posisiAwal = 0)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.healing = healing;
            this.posisiAwal = posisiAwal;
            this.posisiSaatIni = posisiAwal; 
        }

        public void Serang(Karakter target) // Interaksi antar objek: Menyerang
        {
            Console.WriteLine($"\n===== {nama} Mulai Serangan =====");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int JumlahSerangan) // Interaksi antar objek: Menerima serangan
        {
            kesehatan -= JumlahSerangan;
            Console.WriteLine($"{nama} menerima serangan sebesar {JumlahSerangan}. Kesehatan sekarang: {kesehatan}");
        }

        public void PakaiHealing() // Method untuk mendeteksi penggunaan Potion/Healing
        {
            Console.WriteLine($"\n===== {nama} Menggunakan Potion =====");
            this.ProsesHealing(this.healing);
        }

        public void ProsesHealing(int JumlahHealing)
        {
            kesehatan += JumlahHealing;
            Console.WriteLine($"{nama} mendapat penyembuhan sebesar {JumlahHealing}. Kesehatan sekarang: {kesehatan}");
        }

        public void PindahPosisi() 
        {
            Console.WriteLine($"\n===== {nama} Pindah Posisi =====");
            Console.WriteLine($"Posisi saat ini : {posisiSaatIni}");
            Console.WriteLine("Kontrol: (->) kanan = +2  |  (<-) kiri = -1  |  (Esc) berhenti");

            while (true)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true); 

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    posisiSaatIni += 2; 
                    Console.WriteLine($"-> Kanan  | posisi saat ini : {posisiSaatIni}");
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    posisiSaatIni -= 1; 
                    Console.WriteLine($"<- Kiri   | posisi saat ini : {posisiSaatIni}");
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("permainan Berhenti");
                    break; 
                }
                
            }
        }

        public void getData()
        {
            Console.WriteLine($"Karakter: {nama} | Kesehatan: {kesehatan} | Posisi: {posisiSaatIni} (awal: {posisiAwal})");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Anby", 100, 40, 20, 0);              
            Karakter Musuh = new Karakter("Etherial", 100, 30, 0);                 

            player1.Serang(Musuh); 
            Musuh.Serang(player1); 

            Console.WriteLine("\n===== STATUS SEKARANG =====");
            player1.getData();

     
            while (true)
            {
                Console.Write($"\nApakah {player1.nama} ingin menggunakan Potion? (Y/N): ");
                string pilihan = Console.ReadLine().ToUpper().Trim(); 

                if (pilihan == "Y")
                {
                    player1.PakaiHealing();
                    break; 
                }
                else if (pilihan == "N")
                {
                    Console.WriteLine($"\n{player1.nama} memilih untuk menyimpan Potion.");
                    break; 
                }
                else
                {
                    Console.WriteLine("Pilihan salah! Tolong masukkan hanya huruf 'Y' atau 'N'.");
                }
            }

    
            player1.PindahPosisi();


            Console.WriteLine("\n===== STATUS AKHIR =====");
            player1.getData();
            Musuh.getData();
        }
    }
}
