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

        public void PindahPosisi() // Method aksi: perpindahan posisi (kontrol tombol keyboard)
        {
            Console.WriteLine($"\n===== {nama} Pindah Posisi =====");
            Console.WriteLine($"Posisi saat ini : {posisiSaatIni}");
            Console.WriteLine("Kontrol: (->) kanan = +2  |  (<-) kiri = -1  |  (Esc) berhenti");

            while (true)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true); // true = tombol tidak ditampilkan ke terminal

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    posisiSaatIni += 2; // arrow kanan -> posisi bertambah 2
                    Console.WriteLine($"-> Kanan  | posisi saat ini : {posisiSaatIni}");
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    posisiSaatIni -= 1; // arrow kiri -> posisi berkurang 1
                    Console.WriteLine($"<- Kiri   | posisi saat ini : {posisiSaatIni}");
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("permainan Berhenti");
                    break; // keluar dari loop perpindahan
                }
                // tombol lain diabaikan
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
            Karakter player1 = new Karakter("Anby", 100, 40, 20, 0);              // posisi awal = 0
            Karakter Musuh = new Karakter("Etherial", 100, 30, 0);                 // posisi awal = 0

            // Simulasi Pertarungan Awal
            player1.Serang(Musuh); 
            Musuh.Serang(player1); 

            // Menampilkan status saat ini sebelum pilihan healing
            Console.WriteLine("\n===== STATUS SEKARANG =====");
            player1.getData();

            // Loop untuk validasi input Y/N yang ngasal
            while (true)
            {
                Console.Write($"\nApakah {player1.nama} ingin menggunakan Potion? (Y/N): ");
                string pilihan = Console.ReadLine().ToUpper().Trim(); // .Trim() menghapus spasi tidak sengaja

                if (pilihan == "Y")
                {
                    player1.PakaiHealing();
                    break; // Keluar dari perulangan karena input valid
                }
                else if (pilihan == "N")
                {
                    Console.WriteLine($"\n{player1.nama} memilih untuk menyimpan Potion.");
                    break; // Keluar dari perulangan karena input valid
                }
                else
                {
                    Console.WriteLine("Pilihan salah! Tolong masukkan hanya huruf 'Y' atau 'N'.");
                }
            }

    
            player1.PindahPosisi();

            // Status Akhir Game
            Console.WriteLine("\n===== STATUS AKHIR =====");
            player1.getData();
            Musuh.getData();
        }
    }
}
